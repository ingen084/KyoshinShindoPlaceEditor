using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace KyoshinShindoPlaceEditor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private List<ObservationPoint> _points;
		private Point2 _mapLeftUpMapPosition = new Point2(13 * 2 * MercatorProjection.TileSize, 5 * 2 * MercatorProjection.TileSize);

		private Point _prevPos;
		private Panel _mapPoint;

		private double _monitorZoom = 1;

		private double MonitorZoom
		{
			get => _monitorZoom;
			set
			{
				if (value == _monitorZoom)
					return;

				interpolatedPictureBox4.Width = interpolatedPictureBox3.Width = interpolatedPictureBox2.Width = (int)(352 * value);
				interpolatedPictureBox4.Height = interpolatedPictureBox3.Height = interpolatedPictureBox2.Height = (int)(400 * value);
				interpolatedPictureBox3.Location = Point.Empty;

				_monitorZoom = value;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Text += " - " + Assembly.GetExecutingAssembly().GetName().Version;

			interpolatedPictureBox3.ImageLocation = "base_map_w.gif";

			interpolatedPictureBox4.MouseDown += (s2, e2) =>
			{
				if (e2.Button != MouseButtons.Right)
					return;
				_prevPos = e2.Location;
			};
			interpolatedPictureBox4.MouseMove += (s2, e2) =>
			{
				if (e2.Button != MouseButtons.Right)
					return;
				interpolatedPictureBox3.Location = new Point(
					interpolatedPictureBox3.Location.X + (e2.Location.X - _prevPos.X),
					interpolatedPictureBox3.Location.Y + (e2.Location.Y - _prevPos.Y)
					);
			};
			interpolatedPictureBox1.MouseDown += (s2, e2) =>
			{
				if (e2.Button == MouseButtons.Right)
					_prevPos = e2.Location;
			};
			interpolatedPictureBox1.MouseMove += (s2, e2) =>
			{
				if (e2.Button != MouseButtons.Right)
					return;
				interpolatedPictureBox1.Location = new Point(
					interpolatedPictureBox1.Location.X + (e2.Location.X - _prevPos.X),
					interpolatedPictureBox1.Location.Y + (e2.Location.Y - _prevPos.Y)
					);

				if (_mapPoint == null)
					return;
				_mapPoint.Location = new Point(
					_mapPoint.Location.X + (e2.Location.X - _prevPos.X),
					_mapPoint.Location.Y + (e2.Location.Y - _prevPos.Y)
					);
			};

			interpolatedPictureBox1.Interpolation = InterpolationMode.NearestNeighbor;
			interpolatedPictureBox2.Interpolation = InterpolationMode.NearestNeighbor;
			interpolatedPictureBox3.Interpolation = InterpolationMode.NearestNeighbor;
			interpolatedPictureBox4.Interpolation = InterpolationMode.NearestNeighbor;
			interpolatedPictureBox3.Controls.Add(interpolatedPictureBox2);
			interpolatedPictureBox2.Controls.Add(interpolatedPictureBox4);

			UpdateImage();

			if (!File.Exists("ShindoObsPoints.pbf"))
			{
				_points = new List<ObservationPoint>();

				using (var reader = new StreamReader("sitepub_kik_sj.csv", Encoding.GetEncoding("Shift-JIS")))
					while (reader.Peek() >= 0)
					{
						var strings = reader.ReadLine().Split(',');
						_points.Add(new ObservationPoint(ObservationPointType.KiK_NET, strings[0], strings[13] == "suspension", strings[1], strings[7], new Location(float.Parse(strings[3]), float.Parse(strings[4]))));
					}
				using (var reader = new StreamReader("sitepub_knet_sj.csv", Encoding.GetEncoding("Shift-JIS")))
					while (reader.Peek() >= 0)
					{
						var strings = reader.ReadLine().Split(',');
						_points.Add(new ObservationPoint(ObservationPointType.K_net, strings[0], strings[13] == "suspension", strings[1], strings[7], new Location(float.Parse(strings[3]), float.Parse(strings[4]))));
					}
			}
			else
				using (var stream = new FileStream("ShindoObsPoints.pbf", FileMode.Open))
					_points = Serializer.Deserialize<List<ObservationPoint>>(stream);

			UpdateListValue();
		}

		private void UpdateImage()
		{
			var startTime = DateTime.Now.AddSeconds(-2);
			interpolatedPictureBox2.ImageLocation = "http://www.kmoni.bosai.go.jp/new/data/map_img/RealTimeImg/jma_s/" + startTime.ToString("yyyyMMdd") + "/" + startTime.ToString("yyyyMMddHHmmss") + ".jma_s.gif";
		}

		private void UpdateListValue()
		{
			string oldText = Text;
			Text = "[データ更新中] " + Text;
			Enabled = false;
			Cursor = Cursors.WaitCursor;

			int? lastSelectedIndex = null;
			if (listView1.SelectedItems.Count >= 1)
				lastSelectedIndex = listView1.SelectedItems[0].Index;

			listView1.BeginUpdate();

			listView1.Items.Clear();

			_points.Sort();

			if (_points != null && _points.Any())
				listView1.Items.AddRange(_points.Select(p => new ListViewItem(new string[] { p.Code, p.Type.ToNaturalString(), p.IsSuspended ? "はい" : "いいえ", p.Name, p.Region, p.Location.ToString(), p.Point == null ? "未設定" : p.Point.ToString() })).ToArray());

			if (!checkBox2.Checked)
			{
				Bitmap canvas = new Bitmap(352, 400);
				foreach (var point in _points.Where(p => p.Point != null))
				{
					Color color = Color.Black;

					switch (point.Type)
					{
						case ObservationPointType.KiK_NET:
							color = Color.Red;
							break;

						case ObservationPointType.K_net:
							color = Color.Orange;
							break;
					}

					if (point.IsSuspended)
						color = Color.Gray;

					canvas.SetPixel((int)((Point2)point.Point).X, (int)((Point2)point.Point).Y, color);
				}
				interpolatedPictureBox4.Image = canvas;
			}
			else
				interpolatedPictureBox4.Image = null;

			listView1.EndUpdate();

			if (lastSelectedIndex != null)
			{
				listView1.Items[(int)lastSelectedIndex].Selected = true;
				listView1.EnsureVisible((int)lastSelectedIndex);
			}

			Enabled = true;
			Cursor = Cursors.Default;
			Text = oldText;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
				return;

			System.Diagnostics.Debug.WriteLine(listView1.SelectedItems[0].Text);

			if (_mapPoint != null && splitContainer2.Panel2.Controls.Contains(_mapPoint))
				splitContainer2.Panel2.Controls.Remove(_mapPoint);

			_mapPoint = new Panel()
			{
				BackColor = Color.Red,
				Size = new Size(3, 3), //3
				Location = (MercatorProjection.LatLngToPixel(_points.First(p => p.Code == listView1.SelectedItems[0].Text).Location, 5) - _mapLeftUpMapPosition - 1 + interpolatedPictureBox1.Location),
			};

			splitContainer2.Panel2.Controls.Add(_mapPoint);
			splitContainer2.Panel2.Controls.SetChildIndex(_mapPoint, 0);
			//interpolatedPictureBox1.Hide();
		}

		#region

		private void button2_Click(object sender, EventArgs e)
		{
			MonitorZoom = 1;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MonitorZoom = 2;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MonitorZoom = 3;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			MonitorZoom = 4;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			MonitorZoom = 5;
		}

		#endregion

		private void interpolatedPictureBox2_MouseDown(object sender, MouseEventArgs e)
		{
			var clientpos = ((Point2)e.Location / MonitorZoom).Floor();
			System.Diagnostics.Debug.WriteLine(clientpos);

			if (e.Button == MouseButtons.Middle && _points.Any(p => p.Point == clientpos))
			{
				var code = _points.First(p => p.Point == clientpos).Code;
				System.Diagnostics.Debug.WriteLine(_points.First(p => p.Point == clientpos).Code);

				var item = listView1.Items.Cast<ListViewItem>().First(i => i.Text == code);

				foreach (ListViewItem i in listView1.Items)
					i.Selected = false;

				item.Selected = true;
				listView1.Focus();
				listView1.EnsureVisible(item.Index);
				return;
			}

			if (e.Button != MouseButtons.Left)
				return;

			if (listView1.SelectedItems.Count == 0)
				return;

			_points.First(p => p.Code == listView1.SelectedItems[0].Text).Point = clientpos;

			UpdateListValue();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var stream = new FileStream("ShindoObsPoints.pbf", FileMode.Create))
				Serializer.Serialize(stream, _points);
			UpdateListValue();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			UpdateImage();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (!File.Exists("Kansokuten.dat"))
			{
				MessageBox.Show("Kansokuten.datが見つかりません。", null);
				return;
			}
			var addedCount = 0;
			var addId = 0;
			var replaceCount = 0;

			using (var reader = new StreamReader("Kansokuten.dat", Encoding.GetEncoding("Shift-JIS")))
			{
				if (!reader.ReadLine().StartsWith("v5 Kyoshin Monitor Base Data for EqWatch"))
				{
					MessageBox.Show("対応していないEqWatchファイルのバージョンです。", null);
					return;
				}
				while (reader.Peek() >= 0)
				{
					var strings = reader.ReadLine().Split(',');

					//あるとき!
					if (_points.Any(p => p.Type == strings[2].ToObservationPointType() && p.Name == strings[3] && (strings[4] == "その他" || p.Region.StartsWith(strings[4]))))
					{
						var point = _points.First(p => p.Type == strings[2].ToObservationPointType() && p.Name == strings[3] && (strings[4] == "その他" || p.Region.StartsWith(strings[4])));
						point.IsSuspended = strings[0] == "0";
						point.Point = new Point2(int.Parse(strings[9]) + int.Parse(strings[11]), int.Parse(strings[10]) + int.Parse(strings[12]));
						replaceCount++;
					}
					//ないとき…
					else
					{
						while (_points.Any(p => p.Code == $"_EQW{addId}"))
							addId++;

						_points.Add(new ObservationPoint(strings[2].ToObservationPointType(), $"_EQW{addId}", strings[0] == "0", strings[3], strings[4], new Location(float.Parse(strings[8]), float.Parse(strings[7])), new Point2(int.Parse(strings[9]) + int.Parse(strings[11]), int.Parse(strings[10]) + int.Parse(strings[12]))));
						addedCount++;
						addId++;
					}
				}
			}
			UpdateListValue();
			MessageBox.Show($"レポート\n置き換え:{replaceCount}件\n追加:{addedCount}件", "処理終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				interpolatedPictureBox3.ImageLocation = "";
			else
				interpolatedPictureBox3.ImageLocation = "base_map_w.gif";
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				interpolatedPictureBox4.Image = null;
			else
				UpdateListValue();
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
				return;
			e.Cancel = true;
		}

		private void toggleSuspendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var point = _points.FirstOrDefault(p => p.Code == listView1.SelectedItems[0].Text);
			if (point == null)
				return;
			if (point.IsSuspended)
				point.IsSuspended = false;
			else
				point.IsSuspended = true;
			UpdateListValue();
		}

		private void removePointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var point = _points.FirstOrDefault(p => p.Code == listView1.SelectedItems[0].Text);
			if (point == null)
				return;

			point.Point = null;

			UpdateListValue();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			MessageBox.Show(@"**操作方法**
右リストの項目を選択した状態で右クリック	ポインタの位置に参照地点を上書きします。
左ドラッグ	地図移動	※だいぶ手抜き実装なので画面外に出してしまわないように気をつけてください。
中(ホイールボタン)クリック	ポインタが参照地点上である場合はその地点が右リストから選択されます。", "操作方法");
		}
	}
}