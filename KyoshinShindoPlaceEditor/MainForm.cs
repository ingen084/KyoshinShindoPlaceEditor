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
	public partial class MainForm : Form
	{
		public MainForm()
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

		private void MainForm_Load(object sender, EventArgs e)
		{
			Text += " - " + Assembly.GetExecutingAssembly().GetName().Version;

			importFromNiedToolStripMenuItem.Click += (s2, e2) => ImportNiedData();
			importFromEqWatchToolStripMenuItem.Click += (s2, e2) => ImportEqWatchData();

			loadPbfToolStripMenuItem.Click += (s2, e2) => LoadFromPbf(Properties.Settings.Default.PbfFilename);
			loadCsvToolStripMenuItem.Click += (s2, e2) => LoadFromCsv(Properties.Settings.Default.CsvFilename);

			savePbfToolStripMenuItem.Click += (s2, e2) => SaveToPbf(Properties.Settings.Default.PbfFilename);
			saveCsvToolStripMenuItem.Click += (s2, e2) => SaveToCsv(Properties.Settings.Default.CsvFilename);

			loadAsPbfToolStripMenuItem.Click += (s2, e2) =>
			{
				var ofd = new OpenFileDialog()
				{
					FileName = Properties.Settings.Default.PbfFilename,
					Filter = "pbfファイル(*.pbf)|*.pbf|すべてのファイル(*.*)|*.*",
					FilterIndex = 1,
					Title = "読み込むpbfファイルを選択してください",
					RestoreDirectory = true
				};
				if (ofd.ShowDialog() != DialogResult.OK)
					return;
				LoadFromPbf(ofd.FileName);
			};
			loadAsCsvToolStripMenuItem.Click += (s2, e2) =>
			{
				var ofd = new OpenFileDialog()
				{
					FileName = Properties.Settings.Default.CsvFilename,
					Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*",
					FilterIndex = 1,
					Title = "読み込むcsvファイルを選択してください",
					RestoreDirectory = true
				};
				if (ofd.ShowDialog() != DialogResult.OK)
					return;
				LoadFromCsv(ofd.FileName);
			};

			saveAsPbfToolStripMenuItem.Click += (s2, e2) =>
			{
				var sfd = new SaveFileDialog()
				{
					FileName = Properties.Settings.Default.PbfFilename,
					Filter = "pbfファイル(*.pbf)|*.pbf|すべてのファイル(*.*)|*.*",
					FilterIndex = 1,
					Title = "保存するpbfファイルを選択してください",
					RestoreDirectory = true
				};
				if (sfd.ShowDialog() != DialogResult.OK)
					return;
				SaveToPbf(sfd.FileName, false);
			};
			saveAsCsvToolStripMenuItem.Click += (s2, e2) =>
			{
				var sfd = new SaveFileDialog()
				{
					FileName = Properties.Settings.Default.CsvFilename,
					Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*",
					FilterIndex = 1,
					Title = "保存するcsvファイルを選択してください",
					RestoreDirectory = true
				};
				if (sfd.ShowDialog() != DialogResult.OK)
					return;
				SaveToCsv(sfd.FileName, false);
			};

			aboutToolStripMenuItem.Click += (s2, e2) => new AboutForm().ShowDialog();

			interpolatedPictureBox3.ImageLocation = "http://www.kmoni.bosai.go.jp/new/data/map_img/CommonImg/base_map_w.gif";

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

			_points = new List<ObservationPoint>();

			UpdateListValue();
		}

		private void UpdateImage()
		{
			var startTime = DateTime.Now.AddSeconds(-2);
			interpolatedPictureBox2.ImageLocation = "http://www.kmoni.bosai.go.jp/new/data/map_img/RealTimeImg/jma_s/" + startTime.ToString("yyyyMMdd") + "/" + startTime.ToString("yyyyMMddHHmmss") + ".jma_s.gif";
		}

		private void UpdateListValue()
		{
			_points = _points ?? new List<ObservationPoint>();

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
						case ObservationPointType.KiK_net:
							color = Color.Red;
							break;

						case ObservationPointType.K_NET:
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

		private void ListViewSelectedIndexChanged(object sender, EventArgs e)
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
		}

		#region ZoomChange

		private void KyoshinZoomChange_1(object sender, EventArgs e) => MonitorZoom = 1;
		private void KyoshinZoomChange_2(object sender, EventArgs e) => MonitorZoom = 2;
		private void KyoshinZoomChange_3(object sender, EventArgs e) => MonitorZoom = 3;
		private void KyoshinZoomChange_4(object sender, EventArgs e) => MonitorZoom = 4;
		private void KyoshinZoomChange_5(object sender, EventArgs e) => MonitorZoom = 5;

		#endregion

		private void InterpolatedPictureBox2_MouseDown(object sender, MouseEventArgs e)
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

		#region Save
		private void SaveToPbf(string path, bool checkDialog = true)
		{
			if (checkDialog && MessageBox.Show(path + "に保存してもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;
			try
			{
				using (var stream = new FileStream(path, FileMode.Create))
					Serializer.Serialize(stream, _points);
				UpdateListValue();
			}
			catch (Exception ex)
			{
				MessageBox.Show("pbf保存に失敗しました。\n" + ex, null);
			}
		}

		private void SaveToCsv(string path, bool checkDialog = true)
		{
			if (checkDialog && MessageBox.Show(path + "に保存してもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;
			try
			{
				using (var stream = new StreamWriter(path))
					foreach (var point in _points)
						stream.WriteLine($"{(int)point.Type},{point.Code},{point.IsSuspended},{point.Name},{point.Region},{point.Location.Latitude},{point.Location.Longitude},{point.Point?.X.ToString() ?? ""},{point.Point?.Y.ToString() ?? ""}");
				UpdateListValue();
			}
			catch (Exception ex)
			{
				MessageBox.Show("csv保存に失敗しました。\n" + ex, null);
			}
		}
		#endregion

		#region Load
		private void LoadFromPbf(string path)
		{
			if (!File.Exists(path))
			{
				MessageBox.Show(path + "が見つかりません。", null);
				return;
			}

			if (_points.Any() && MessageBox.Show("現状読み込まれているデータはすべて上書きされます。読み込んでもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;
			try
			{
				using (var stream = new FileStream(path, FileMode.Open))
					_points = Serializer.Deserialize<List<ObservationPoint>>(stream) ?? new List<ObservationPoint>();
			}
			catch (Exception ex)
			{
				MessageBox.Show("pbf読み込みに失敗しました。\n" + ex, null);
			}

			UpdateListValue();
		}

		private void LoadFromCsv(string path)
		{
			if (!File.Exists(path))
			{
				MessageBox.Show(path + "が見つかりません。", null);
				return;
			}

			if (_points.Any() && MessageBox.Show("現状読み込まれているデータはすべて上書きされます。読み込んでもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;

			var addedCount = 0;
			var errorCount = 0;

			_points = new List<ObservationPoint>();

			try
			{
				using (var reader = new StreamReader(path))
					while (reader.Peek() >= 0)
						try
						{
							var strings = reader.ReadLine().Split(',');

							var point = new ObservationPoint()
							{
								Type = (ObservationPointType)int.Parse(strings[0]),
								Code = strings[1],
								IsSuspended = bool.Parse(strings[2]),
								Name = strings[3],
								Region = strings[4],
								Location = new Location(float.Parse(strings[5]), float.Parse(strings[6])),
								Point = null
							};
							if (!string.IsNullOrWhiteSpace(strings[7]) && !string.IsNullOrWhiteSpace(strings[8]))
								point.Point = new Point2(int.Parse(strings[7]), int.Parse(strings[8]));
							_points.Add(point);
							addedCount++;
						}
						catch
						{
							errorCount++;
						}

				UpdateListValue();
				MessageBox.Show($"レポート\n成功:{addedCount}件\n失敗:{errorCount}件", "処理終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("csv読み込みに失敗しました。\n" + ex, null);
				UpdateListValue();
			}
		}
		#endregion

		#region Import
		private void ImportEqWatchData()
		{
			if (!File.Exists("Kansokuten.dat"))
			{
				MessageBox.Show("Kansokuten.datが見つかりません。", null);
				return;
			}

			if (_points.Any() && MessageBox.Show("インポート元に含まれているデータがすべて上書きされます。インポートしてもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;

			var addedCount = 0;
			var addId = 0;
			var replaceCount = 0;
			var errorCount = 0;

			try
			{
				using (var reader = new StreamReader("Kansokuten.dat", Encoding.GetEncoding("Shift-JIS")))
				{
					if (!reader.ReadLine().StartsWith("v5 Kyoshin Monitor Base Data for EqWatch"))
					{
						MessageBox.Show("対応していないEqWatchファイルのバージョンです。", null);
						return;
					}
					while (reader.Peek() >= 0)
					{
						try
						{
							var strings = reader.ReadLine().Split(',');

							var point = _points.FirstOrDefault(p => p.Type == strings[2].ToObservationPointType() && p.Name == strings[3] && (strings[4] == "その他" || p.Region.StartsWith(strings[4])));
							//あるとき!
							if (point != null)
							{
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
						catch
						{
							errorCount++;
						}
					}
				}
				UpdateListValue();
				MessageBox.Show($"レポート\n置き換え:{replaceCount}件\n追加:{addedCount}件\n失敗:{errorCount}件", "処理終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("EqWatchデータのインポートに失敗しました。\n" + ex, null);
				UpdateListValue();
			}
		}

		private void ImportNiedData()
		{
			if (!File.Exists("sitepub_kik_sj.csv"))
			{
				MessageBox.Show("sitepub_kik_sj.csvが見つかりません。", null);
				return;
			}
			if (!File.Exists("sitepub_knet_sj.csv"))
			{
				MessageBox.Show("sitepub_knet_sj.csvが見つかりません。", null);
				return;
			}

			if (_points.Any() && MessageBox.Show("登録されていない地点情報が追加で登録されます。インポートしてもよろしいですか？", "確認", MessageBoxButtons.YesNo) == DialogResult.No)
				return;

			var addedCount = 0;
			var errorCount = 0;

			try
			{
				using (var reader = new StreamReader("sitepub_kik_sj.csv", Encoding.GetEncoding("Shift-JIS")))
					while (reader.Peek() >= 0)
					{
						try
						{
							var strings = reader.ReadLine().Split(',');

							//発見したら帰る
							if (_points.Any(p => p.Type == ObservationPointType.KiK_net && p.Code == strings[0] && p.Name == strings[1] && p.Region == strings[7]))
								continue;

							_points.Add(new ObservationPoint(ObservationPointType.KiK_net, strings[0], strings[13] == "suspension", strings[1], strings[7], new Location(float.Parse(strings[3]), float.Parse(strings[4]))));
							addedCount++;
						}
						catch
						{
							errorCount++;
						}
					}
				using (var reader = new StreamReader("sitepub_knet_sj.csv", Encoding.GetEncoding("Shift-JIS")))
					while (reader.Peek() >= 0)
					{
						try
						{
							var strings = reader.ReadLine().Split(',');

							//発見したら帰る
							if (_points.Any(p => p.Type == ObservationPointType.K_NET && p.Code == strings[0] && p.Name == strings[1] && p.Region == strings[7]))
								continue;

							_points.Add(new ObservationPoint(ObservationPointType.K_NET, strings[0], strings[13] == "suspension", strings[1], strings[7], new Location(float.Parse(strings[3]), float.Parse(strings[4]))));
							addedCount++;
						}
						catch
						{
							errorCount++;
						}
					}

				UpdateListValue();
				MessageBox.Show($"レポート\n置き換え:非対応\n追加:{addedCount}件\n失敗:{errorCount}件", "処理終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("NIED観測点データのインポートに失敗しました。\n" + ex, null);
				UpdateListValue();
			}
		}
		#endregion

		private void RefleshKyoshinImage(object sender, EventArgs e)
		{
			UpdateImage();
		}

		private void BackgroundMapChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				interpolatedPictureBox3.ImageLocation = "";
			else
				interpolatedPictureBox3.ImageLocation = "http://www.kmoni.bosai.go.jp/new/data/map_img/CommonImg/base_map_w.gif";
		}

		private void PointMapChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				interpolatedPictureBox4.Image = null;
			else
				UpdateListValue();
		}

		private void ContextMenuOpening(object sender, CancelEventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
				return;
			e.Cancel = true;
		}

		private void ToggleSuspendToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void RemovePointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var point = _points.FirstOrDefault(p => p.Code == listView1.SelectedItems[0].Text);
			if (point == null)
				return;

			point.Point = null;

			UpdateListValue();
		}

		private void ShowMapUsage(object sender, EventArgs e)
		{
			MessageBox.Show(@"**操作方法**
画像更新ボタンを押すと現在の時間の強震モニタの画像に更新されます。
右リストの項目を選択した状態で右クリック	ポインタの位置に参照地点を上書きします。
左ドラッグ	地図移動	※だいぶ手抜き実装なので画面外に出してしまわないように気をつけてください。
中(ホイールボタン)クリック	ポインタが参照地点上である場合はその地点が右リストから選択されます。", "操作方法");
		}
	}
}