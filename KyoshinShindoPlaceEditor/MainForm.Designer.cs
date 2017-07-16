namespace KyoshinShindoPlaceEditor
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.button9 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.interpolatedPictureBox4 = new KyoshinShindoPlaceEditor.InterpolatedPictureBox();
			this.interpolatedPictureBox2 = new KyoshinShindoPlaceEditor.InterpolatedPictureBox();
			this.interpolatedPictureBox3 = new KyoshinShindoPlaceEditor.InterpolatedPictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.interpolatedPictureBox1 = new KyoshinShindoPlaceEditor.InterpolatedPictureBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.CodeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PrefColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LocationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PointColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toggleSuspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromNiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromEqWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectKyoshinSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.surfaceShindoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.boreholeShindoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
			this.splitContainer1.Size = new System.Drawing.Size(1084, 711);
			this.splitContainer1.SplitterDistance = 360;
			this.splitContainer1.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.button9);
			this.splitContainer2.Panel1.Controls.Add(this.label5);
			this.splitContainer2.Panel1.Controls.Add(this.button7);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Panel1.Controls.Add(this.button6);
			this.splitContainer2.Panel1.Controls.Add(this.label4);
			this.splitContainer2.Panel1.Controls.Add(this.button5);
			this.splitContainer2.Panel1.Controls.Add(this.label3);
			this.splitContainer2.Panel1.Controls.Add(this.button4);
			this.splitContainer2.Panel1.Controls.Add(this.checkBox2);
			this.splitContainer2.Panel1.Controls.Add(this.button3);
			this.splitContainer2.Panel1.Controls.Add(this.checkBox1);
			this.splitContainer2.Panel1.Controls.Add(this.button2);
			this.splitContainer2.Panel1.Controls.Add(this.interpolatedPictureBox4);
			this.splitContainer2.Panel1.Controls.Add(this.interpolatedPictureBox2);
			this.splitContainer2.Panel1.Controls.Add(this.interpolatedPictureBox3);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.label2);
			this.splitContainer2.Panel2.Controls.Add(this.interpolatedPictureBox1);
			this.splitContainer2.Size = new System.Drawing.Size(360, 711);
			this.splitContainer2.SplitterDistance = 446;
			this.splitContainer2.TabIndex = 0;
			// 
			// button9
			// 
			this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button9.Location = new System.Drawing.Point(454, 3);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(22, 23);
			this.button9.TabIndex = 3;
			this.button9.Text = "?";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.ShowMapUsage);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Gray;
			this.label5.Location = new System.Drawing.Point(213, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 2;
			this.label5.Text = "■休止中";
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(282, 3);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 4;
			this.button7.Text = "画像更新";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.RefleshKyoshinImage);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 425);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "拡大";
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button6.Location = new System.Drawing.Point(147, 420);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(26, 23);
			this.button6.TabIndex = 2;
			this.button6.Text = "5x";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.KyoshinZoomChange_5);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Orange;
			this.label4.Location = new System.Drawing.Point(161, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 12);
			this.label4.TabIndex = 2;
			this.label4.Text = "■K-net";
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Location = new System.Drawing.Point(122, 420);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(26, 23);
			this.button5.TabIndex = 2;
			this.button5.Text = "4x";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.KyoshinZoomChange_4);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(93, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "■KiK-NET";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Location = new System.Drawing.Point(97, 420);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(26, 23);
			this.button4.TabIndex = 2;
			this.button4.Text = "3x";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.KyoshinZoomChange_3);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(3, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(108, 16);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "取得座標非表示";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.PointMapChanged);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Location = new System.Drawing.Point(72, 420);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(26, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "2x";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.KyoshinZoomChange_2);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(3, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(84, 16);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "背景非表示";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.BackgroundMapChanged);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(47, 420);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(26, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "1x";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.KyoshinZoomChange_1);
			// 
			// interpolatedPictureBox4
			// 
			this.interpolatedPictureBox4.BackColor = System.Drawing.Color.Transparent;
			this.interpolatedPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.interpolatedPictureBox4.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Default;
			this.interpolatedPictureBox4.Location = new System.Drawing.Point(0, 0);
			this.interpolatedPictureBox4.Name = "interpolatedPictureBox4";
			this.interpolatedPictureBox4.Size = new System.Drawing.Size(352, 400);
			this.interpolatedPictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.interpolatedPictureBox4.TabIndex = 0;
			this.interpolatedPictureBox4.TabStop = false;
			this.interpolatedPictureBox4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterpolatedPictureBox2_MouseDown);
			// 
			// interpolatedPictureBox2
			// 
			this.interpolatedPictureBox2.BackColor = System.Drawing.Color.Transparent;
			this.interpolatedPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.interpolatedPictureBox2.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Default;
			this.interpolatedPictureBox2.Location = new System.Drawing.Point(0, 0);
			this.interpolatedPictureBox2.Name = "interpolatedPictureBox2";
			this.interpolatedPictureBox2.Size = new System.Drawing.Size(352, 400);
			this.interpolatedPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.interpolatedPictureBox2.TabIndex = 0;
			this.interpolatedPictureBox2.TabStop = false;
			this.interpolatedPictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterpolatedPictureBox2_MouseDown);
			// 
			// interpolatedPictureBox3
			// 
			this.interpolatedPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.interpolatedPictureBox3.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Default;
			this.interpolatedPictureBox3.Location = new System.Drawing.Point(0, 0);
			this.interpolatedPictureBox3.Name = "interpolatedPictureBox3";
			this.interpolatedPictureBox3.Size = new System.Drawing.Size(352, 400);
			this.interpolatedPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.interpolatedPictureBox3.TabIndex = 0;
			this.interpolatedPictureBox3.TabStop = false;
			this.interpolatedPictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InterpolatedPictureBox2_MouseDown);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(200, 249);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "© OpenStreetMap contributors";
			// 
			// interpolatedPictureBox1
			// 
			this.interpolatedPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("interpolatedPictureBox1.Image")));
			this.interpolatedPictureBox1.Interpolation = System.Drawing.Drawing2D.InterpolationMode.Default;
			this.interpolatedPictureBox1.Location = new System.Drawing.Point(-344, -520);
			this.interpolatedPictureBox1.Name = "interpolatedPictureBox1";
			this.interpolatedPictureBox1.Size = new System.Drawing.Size(1024, 1024);
			this.interpolatedPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.interpolatedPictureBox1.TabIndex = 0;
			this.interpolatedPictureBox1.TabStop = false;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CodeColumn,
            this.TypeColumn,
            this.SuspendColumn,
            this.NameColumn,
            this.PrefColumn,
            this.LocationColumn,
            this.PointColumn});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 24);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(720, 687);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListViewSelectedIndexChanged);
			// 
			// CodeColumn
			// 
			this.CodeColumn.Text = "観測点コード";
			this.CodeColumn.Width = 80;
			// 
			// TypeColumn
			// 
			this.TypeColumn.Text = "種類";
			// 
			// SuspendColumn
			// 
			this.SuspendColumn.Text = "休止中?";
			this.SuspendColumn.Width = 55;
			// 
			// NameColumn
			// 
			this.NameColumn.Text = "観測点名";
			this.NameColumn.Width = 100;
			// 
			// PrefColumn
			// 
			this.PrefColumn.Text = "大まかな地域";
			this.PrefColumn.Width = 100;
			// 
			// LocationColumn
			// 
			this.LocationColumn.Text = "観測点地理座標";
			this.LocationColumn.Width = 160;
			// 
			// PointColumn
			// 
			this.PointColumn.Text = "強震モニタ上での座標";
			this.PointColumn.Width = 120;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleSuspendToolStripMenuItem,
            this.removePointToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(254, 48);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuOpening);
			// 
			// toggleSuspendToolStripMenuItem
			// 
			this.toggleSuspendToolStripMenuItem.Name = "toggleSuspendToolStripMenuItem";
			this.toggleSuspendToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
			this.toggleSuspendToolStripMenuItem.Text = "休止状態を切り替える(&T)";
			this.toggleSuspendToolStripMenuItem.Click += new System.EventHandler(this.ToggleSuspendToolStripMenuItem_Click);
			// 
			// removePointToolStripMenuItem
			// 
			this.removePointToolStripMenuItem.Name = "removePointToolStripMenuItem";
			this.removePointToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
			this.removePointToolStripMenuItem.Text = "強震モニタ上での座標情報を削除(&R)";
			this.removePointToolStripMenuItem.Click += new System.EventHandler(this.RemovePointToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.importToolStripMenuItem,
            this.selectKyoshinSourceToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(720, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.fileToolStripMenuItem.Text = "ファイル(&F)";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.loadToolStripMenuItem.Text = "読み込む(&L)";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveToolStripMenuItem.Text = "保存(&S)";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.saveAsToolStripMenuItem.Text = "場所を指定して保存(&A)";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.exitToolStripMenuItem.Text = "終了(&E)";
			// 
			// importToolStripMenuItem
			// 
			this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromNiedToolStripMenuItem,
            this.importFromEqWatchToolStripMenuItem});
			this.importToolStripMenuItem.Name = "importToolStripMenuItem";
			this.importToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.importToolStripMenuItem.Text = "インポート(&I)";
			// 
			// importFromNiedToolStripMenuItem
			// 
			this.importFromNiedToolStripMenuItem.Name = "importFromNiedToolStripMenuItem";
			this.importFromNiedToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.importFromNiedToolStripMenuItem.Text = "&NIEDの観測点情報";
			// 
			// importFromEqWatchToolStripMenuItem
			// 
			this.importFromEqWatchToolStripMenuItem.Name = "importFromEqWatchToolStripMenuItem";
			this.importFromEqWatchToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.importFromEqWatchToolStripMenuItem.Text = "&EqWatchのKansokuten.dat";
			// 
			// selectKyoshinSourceToolStripMenuItem
			// 
			this.selectKyoshinSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surfaceShindoStripMenuItem,
            this.boreholeShindoStripMenuItem});
			this.selectKyoshinSourceToolStripMenuItem.Name = "selectKyoshinSourceToolStripMenuItem";
			this.selectKyoshinSourceToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
			this.selectKyoshinSourceToolStripMenuItem.Text = "モニタ画像の取得元選択";
			// 
			// surfaceShindoStripMenuItem
			// 
			this.surfaceShindoStripMenuItem.Checked = true;
			this.surfaceShindoStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.surfaceShindoStripMenuItem.Name = "surfaceShindoStripMenuItem";
			this.surfaceShindoStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.surfaceShindoStripMenuItem.Text = "リアルタイム震度(地表)(&S)";
			// 
			// boreholeShindoStripMenuItem
			// 
			this.boreholeShindoStripMenuItem.Name = "boreholeShindoStripMenuItem";
			this.boreholeShindoStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.boreholeShindoStripMenuItem.Text = "リアルタイム震度(地中)(&U)";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.helpToolStripMenuItem.Text = "ヘルプ(&H)";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.aboutToolStripMenuItem.Text = "このアプリケーションについて(&A)";
			// 
			// sortToolStripMenuItem
			// 
			this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
			this.sortToolStripMenuItem.Size = new System.Drawing.Size(175, 20);
			this.sortToolStripMenuItem.Text = "観測点コードに順に並び替える(&S)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 711);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainForm";
			this.Text = "KyoshinShindoPlaceEditor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.interpolatedPictureBox1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private InterpolatedPictureBox interpolatedPictureBox1;
		private InterpolatedPictureBox interpolatedPictureBox2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader CodeColumn;
		private System.Windows.Forms.ColumnHeader NameColumn;
		private System.Windows.Forms.ColumnHeader PrefColumn;
		private System.Windows.Forms.ColumnHeader LocationColumn;
		private System.Windows.Forms.ColumnHeader PointColumn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private InterpolatedPictureBox interpolatedPictureBox3;
		private InterpolatedPictureBox interpolatedPictureBox4;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader TypeColumn;
		private System.Windows.Forms.ColumnHeader SuspendColumn;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toggleSuspendToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ToolStripMenuItem removePointToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectKyoshinSourceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem surfaceShindoStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem boreholeShindoStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importFromNiedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importFromEqWatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
	}
}

