
namespace WordConnectionsViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tlp_MainTable = new System.Windows.Forms.TableLayoutPanel();
            this.gb_viewType = new System.Windows.Forms.GroupBox();
            this.cb_viewType = new System.Windows.Forms.ComboBox();
            this.pb_MainGraphicPanel = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tlp_loadJSON = new System.Windows.Forms.TableLayoutPanel();
            this.cb_jsonPathList = new System.Windows.Forms.ComboBox();
            this.btn_Load_JSON_File = new System.Windows.Forms.Button();
            this.gbox_connections = new System.Windows.Forms.GroupBox();
            this.lv_connections = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SaveGraphToImage = new System.Windows.Forms.Button();
            this.tabControl_Settings = new System.Windows.Forms.TabControl();
            this.tabPage_NodeSettings = new System.Windows.Forms.TabPage();
            this.tlp_nodeSettings = new System.Windows.Forms.TableLayoutPanel();
            this.lb_NodeSize = new System.Windows.Forms.Label();
            this.nud_nodeSize = new System.Windows.Forms.NumericUpDown();
            this.lb_textStyle = new System.Windows.Forms.Label();
            this.cb_FontStyle = new System.Windows.Forms.ComboBox();
            this.lb_TextColor = new System.Windows.Forms.Label();
            this.pb_nodeColor = new System.Windows.Forms.PictureBox();
            this.pb_nodeTextColor = new System.Windows.Forms.PictureBox();
            this.nud_FontSize = new System.Windows.Forms.NumericUpDown();
            this.lb_nodeColor = new System.Windows.Forms.Label();
            this.lb_font = new System.Windows.Forms.Label();
            this.cb_fonts = new System.Windows.Forms.ComboBox();
            this.tabPage_EdgeSettings = new System.Windows.Forms.TabPage();
            this.tlp_edgesColors = new System.Windows.Forms.TableLayoutPanel();
            this.lb_edgesWeight = new System.Windows.Forms.Label();
            this.pb_color4 = new System.Windows.Forms.PictureBox();
            this.lb_value1 = new System.Windows.Forms.Label();
            this.lb_value4 = new System.Windows.Forms.Label();
            this.pb_color3 = new System.Windows.Forms.PictureBox();
            this.lb_value3 = new System.Windows.Forms.Label();
            this.pb_color1 = new System.Windows.Forms.PictureBox();
            this.pb_color2 = new System.Windows.Forms.PictureBox();
            this.lb_value2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Profile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_saveProfile = new System.Windows.Forms.Label();
            this.cb_profileName = new System.Windows.Forms.ComboBox();
            this.btn_SaveProfile = new System.Windows.Forms.Button();
            this.tabPage_HideSettings = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_colorNode = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_angle_offset = new System.Windows.Forms.TextBox();
            this.tb_float_A = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tlp_MainTable.SuspendLayout();
            this.gb_viewType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_MainGraphicPanel)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tlp_loadJSON.SuspendLayout();
            this.gbox_connections.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl_Settings.SuspendLayout();
            this.tabPage_NodeSettings.SuspendLayout();
            this.tlp_nodeSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nodeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodeColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodeTextColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FontSize)).BeginInit();
            this.tabPage_EdgeSettings.SuspendLayout();
            this.tlp_edgesColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color2)).BeginInit();
            this.tabPage_Profile.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_MainTable
            // 
            this.tlp_MainTable.BackColor = System.Drawing.Color.White;
            this.tlp_MainTable.ColumnCount = 2;
            this.tlp_MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tlp_MainTable.Controls.Add(this.gb_viewType, 1, 2);
            this.tlp_MainTable.Controls.Add(this.pb_MainGraphicPanel, 0, 2);
            this.tlp_MainTable.Controls.Add(this.groupBox3, 0, 0);
            this.tlp_MainTable.Controls.Add(this.gbox_connections, 1, 3);
            this.tlp_MainTable.Controls.Add(this.groupBox1, 1, 0);
            this.tlp_MainTable.Controls.Add(this.tabControl_Settings, 0, 1);
            this.tlp_MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_MainTable.Location = new System.Drawing.Point(0, 0);
            this.tlp_MainTable.Name = "tlp_MainTable";
            this.tlp_MainTable.RowCount = 4;
            this.tlp_MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlp_MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tlp_MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlp_MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tlp_MainTable.Size = new System.Drawing.Size(802, 438);
            this.tlp_MainTable.TabIndex = 2;
            // 
            // gb_viewType
            // 
            this.gb_viewType.Controls.Add(this.cb_viewType);
            this.gb_viewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_viewType.Location = new System.Drawing.Point(677, 167);
            this.gb_viewType.Name = "gb_viewType";
            this.gb_viewType.Size = new System.Drawing.Size(122, 51);
            this.gb_viewType.TabIndex = 9;
            this.gb_viewType.TabStop = false;
            this.gb_viewType.Text = "View Type";
            // 
            // cb_viewType
            // 
            this.cb_viewType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_viewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_viewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_viewType.FormattingEnabled = true;
            this.cb_viewType.Items.AddRange(new object[] {
            "",
            "Spiral",
            "Square"});
            this.cb_viewType.Location = new System.Drawing.Point(3, 19);
            this.cb_viewType.Name = "cb_viewType";
            this.cb_viewType.Size = new System.Drawing.Size(116, 23);
            this.cb_viewType.TabIndex = 0;
            this.cb_viewType.SelectedIndexChanged += new System.EventHandler(this.cb_viewType_SelectedIndexChanged);
            // 
            // pb_MainGraphicPanel
            // 
            this.pb_MainGraphicPanel.AllowDrop = true;
            this.pb_MainGraphicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_MainGraphicPanel.Location = new System.Drawing.Point(3, 167);
            this.pb_MainGraphicPanel.Name = "pb_MainGraphicPanel";
            this.tlp_MainTable.SetRowSpan(this.pb_MainGraphicPanel, 2);
            this.pb_MainGraphicPanel.Size = new System.Drawing.Size(668, 268);
            this.pb_MainGraphicPanel.TabIndex = 0;
            this.pb_MainGraphicPanel.TabStop = false;
            this.pb_MainGraphicPanel.SizeChanged += new System.EventHandler(this.pb_MainGraphicPanel_SizeChanged);
            this.pb_MainGraphicPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.pb_MainGraphicPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.File_DragOver);
            this.pb_MainGraphicPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectNode);
            this.pb_MainGraphicPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoving);
            this.pb_MainGraphicPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUped);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tlp_loadJSON);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 52);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select JSON File";
            // 
            // tlp_loadJSON
            // 
            this.tlp_loadJSON.ColumnCount = 2;
            this.tlp_loadJSON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.80495F));
            this.tlp_loadJSON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.19505F));
            this.tlp_loadJSON.Controls.Add(this.cb_jsonPathList, 0, 0);
            this.tlp_loadJSON.Controls.Add(this.btn_Load_JSON_File, 1, 0);
            this.tlp_loadJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_loadJSON.Location = new System.Drawing.Point(3, 19);
            this.tlp_loadJSON.Name = "tlp_loadJSON";
            this.tlp_loadJSON.RowCount = 1;
            this.tlp_loadJSON.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_loadJSON.Size = new System.Drawing.Size(662, 30);
            this.tlp_loadJSON.TabIndex = 7;
            // 
            // cb_jsonPathList
            // 
            this.cb_jsonPathList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_jsonPathList.FormattingEnabled = true;
            this.cb_jsonPathList.Location = new System.Drawing.Point(3, 3);
            this.cb_jsonPathList.Name = "cb_jsonPathList";
            this.cb_jsonPathList.Size = new System.Drawing.Size(528, 23);
            this.cb_jsonPathList.TabIndex = 6;
            this.cb_jsonPathList.SelectedIndexChanged += new System.EventHandler(this.JSON_SelectedPathChanged);
            // 
            // btn_Load_JSON_File
            // 
            this.btn_Load_JSON_File.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Load_JSON_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Load_JSON_File.Location = new System.Drawing.Point(537, 3);
            this.btn_Load_JSON_File.Name = "btn_Load_JSON_File";
            this.btn_Load_JSON_File.Size = new System.Drawing.Size(122, 24);
            this.btn_Load_JSON_File.TabIndex = 7;
            this.btn_Load_JSON_File.Text = "Open JSON";
            this.btn_Load_JSON_File.UseVisualStyleBackColor = true;
            this.btn_Load_JSON_File.Click += new System.EventHandler(this.Button_Load_JSON_File_Click);
            // 
            // gbox_connections
            // 
            this.gbox_connections.Controls.Add(this.lv_connections);
            this.gbox_connections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbox_connections.Location = new System.Drawing.Point(677, 224);
            this.gbox_connections.Name = "gbox_connections";
            this.gbox_connections.Size = new System.Drawing.Size(122, 211);
            this.gbox_connections.TabIndex = 8;
            this.gbox_connections.TabStop = false;
            this.gbox_connections.Text = "Connections";
            // 
            // lv_connections
            // 
            this.lv_connections.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lv_connections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lv_connections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_connections.FormattingEnabled = true;
            this.lv_connections.ItemHeight = 15;
            this.lv_connections.Location = new System.Drawing.Point(3, 19);
            this.lv_connections.Name = "lv_connections";
            this.lv_connections.Size = new System.Drawing.Size(116, 189);
            this.lv_connections.Sorted = true;
            this.lv_connections.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SaveGraphToImage);
            this.groupBox1.Location = new System.Drawing.Point(677, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save Image";
            // 
            // btn_SaveGraphToImage
            // 
            this.btn_SaveGraphToImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SaveGraphToImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveGraphToImage.Location = new System.Drawing.Point(3, 19);
            this.btn_SaveGraphToImage.Name = "btn_SaveGraphToImage";
            this.btn_SaveGraphToImage.Size = new System.Drawing.Size(116, 30);
            this.btn_SaveGraphToImage.TabIndex = 9;
            this.btn_SaveGraphToImage.Text = "Save as JPG";
            this.btn_SaveGraphToImage.UseVisualStyleBackColor = true;
            this.btn_SaveGraphToImage.Click += new System.EventHandler(this.Button_SaveGraphToPNG);
            // 
            // tabControl_Settings
            // 
            this.tlp_MainTable.SetColumnSpan(this.tabControl_Settings, 2);
            this.tabControl_Settings.Controls.Add(this.tabPage_NodeSettings);
            this.tabControl_Settings.Controls.Add(this.tabPage_EdgeSettings);
            this.tabControl_Settings.Controls.Add(this.tabPage_Profile);
            this.tabControl_Settings.Controls.Add(this.tabPage_HideSettings);
            this.tabControl_Settings.Controls.Add(this.tabPage1);
            this.tabControl_Settings.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Settings.Location = new System.Drawing.Point(3, 61);
            this.tabControl_Settings.Name = "tabControl_Settings";
            this.tabControl_Settings.SelectedIndex = 0;
            this.tabControl_Settings.Size = new System.Drawing.Size(796, 100);
            this.tabControl_Settings.TabIndex = 10;
            this.tabControl_Settings.SelectedIndexChanged += new System.EventHandler(this.tabControl_Settings_SelectedIndexChanged);
            // 
            // tabPage_NodeSettings
            // 
            this.tabPage_NodeSettings.Controls.Add(this.tlp_nodeSettings);
            this.tabPage_NodeSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPage_NodeSettings.Name = "tabPage_NodeSettings";
            this.tabPage_NodeSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_NodeSettings.Size = new System.Drawing.Size(788, 72);
            this.tabPage_NodeSettings.TabIndex = 0;
            this.tabPage_NodeSettings.Text = "Nodes";
            this.tabPage_NodeSettings.UseVisualStyleBackColor = true;
            // 
            // tlp_nodeSettings
            // 
            this.tlp_nodeSettings.ColumnCount = 7;
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_nodeSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_nodeSettings.Controls.Add(this.lb_NodeSize, 5, 1);
            this.tlp_nodeSettings.Controls.Add(this.nud_nodeSize, 5, 0);
            this.tlp_nodeSettings.Controls.Add(this.lb_textStyle, 4, 1);
            this.tlp_nodeSettings.Controls.Add(this.cb_FontStyle, 4, 0);
            this.tlp_nodeSettings.Controls.Add(this.lb_TextColor, 0, 1);
            this.tlp_nodeSettings.Controls.Add(this.pb_nodeColor, 0, 0);
            this.tlp_nodeSettings.Controls.Add(this.pb_nodeTextColor, 0, 0);
            this.tlp_nodeSettings.Controls.Add(this.nud_FontSize, 3, 0);
            this.tlp_nodeSettings.Controls.Add(this.lb_nodeColor, 0, 1);
            this.tlp_nodeSettings.Controls.Add(this.lb_font, 2, 1);
            this.tlp_nodeSettings.Controls.Add(this.cb_fonts, 2, 0);
            this.tlp_nodeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_nodeSettings.Location = new System.Drawing.Point(3, 3);
            this.tlp_nodeSettings.MinimumSize = new System.Drawing.Size(640, 66);
            this.tlp_nodeSettings.Name = "tlp_nodeSettings";
            this.tlp_nodeSettings.RowCount = 2;
            this.tlp_nodeSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.34483F));
            this.tlp_nodeSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.65517F));
            this.tlp_nodeSettings.Size = new System.Drawing.Size(782, 66);
            this.tlp_nodeSettings.TabIndex = 3;
            // 
            // lb_NodeSize
            // 
            this.lb_NodeSize.AutoSize = true;
            this.lb_NodeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_NodeSize.Location = new System.Drawing.Point(663, 42);
            this.lb_NodeSize.Margin = new System.Windows.Forms.Padding(3);
            this.lb_NodeSize.Name = "lb_NodeSize";
            this.lb_NodeSize.Size = new System.Drawing.Size(64, 21);
            this.lb_NodeSize.TabIndex = 11;
            this.lb_NodeSize.Text = "Node Size";
            this.lb_NodeSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nud_nodeSize
            // 
            this.nud_nodeSize.DecimalPlaces = 2;
            this.nud_nodeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_nodeSize.Location = new System.Drawing.Point(663, 3);
            this.nud_nodeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_nodeSize.Name = "nud_nodeSize";
            this.nud_nodeSize.Size = new System.Drawing.Size(64, 23);
            this.nud_nodeSize.TabIndex = 10;
            this.nud_nodeSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_nodeSize.ValueChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            // 
            // lb_textStyle
            // 
            this.lb_textStyle.AutoSize = true;
            this.lb_textStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_textStyle.Location = new System.Drawing.Point(564, 42);
            this.lb_textStyle.Margin = new System.Windows.Forms.Padding(3);
            this.lb_textStyle.Name = "lb_textStyle";
            this.lb_textStyle.Size = new System.Drawing.Size(93, 21);
            this.lb_textStyle.TabIndex = 9;
            this.lb_textStyle.Text = "Style";
            this.lb_textStyle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_FontStyle
            // 
            this.cb_FontStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_FontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_FontStyle.FormattingEnabled = true;
            this.cb_FontStyle.Location = new System.Drawing.Point(564, 3);
            this.cb_FontStyle.Name = "cb_FontStyle";
            this.cb_FontStyle.Size = new System.Drawing.Size(93, 23);
            this.cb_FontStyle.TabIndex = 8;
            this.cb_FontStyle.SelectedIndexChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            // 
            // lb_TextColor
            // 
            this.lb_TextColor.AutoSize = true;
            this.lb_TextColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_TextColor.Location = new System.Drawing.Point(3, 42);
            this.lb_TextColor.Margin = new System.Windows.Forms.Padding(3);
            this.lb_TextColor.Name = "lb_TextColor";
            this.lb_TextColor.Size = new System.Drawing.Size(94, 21);
            this.lb_TextColor.TabIndex = 7;
            this.lb_TextColor.Text = "Text Color";
            this.lb_TextColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pb_nodeColor
            // 
            this.pb_nodeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(109)))), ((int)(((byte)(50)))));
            this.pb_nodeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_nodeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_nodeColor.Location = new System.Drawing.Point(103, 3);
            this.pb_nodeColor.Name = "pb_nodeColor";
            this.pb_nodeColor.Size = new System.Drawing.Size(94, 33);
            this.pb_nodeColor.TabIndex = 6;
            this.pb_nodeColor.TabStop = false;
            this.pb_nodeColor.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_nodeColor.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // pb_nodeTextColor
            // 
            this.pb_nodeTextColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.pb_nodeTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_nodeTextColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_nodeTextColor.Location = new System.Drawing.Point(3, 3);
            this.pb_nodeTextColor.Name = "pb_nodeTextColor";
            this.pb_nodeTextColor.Size = new System.Drawing.Size(94, 33);
            this.pb_nodeTextColor.TabIndex = 0;
            this.pb_nodeTextColor.TabStop = false;
            this.pb_nodeTextColor.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_nodeTextColor.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // nud_FontSize
            // 
            this.nud_FontSize.DecimalPlaces = 2;
            this.nud_FontSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_FontSize.Location = new System.Drawing.Point(484, 3);
            this.nud_FontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_FontSize.Name = "nud_FontSize";
            this.nud_FontSize.Size = new System.Drawing.Size(74, 23);
            this.nud_FontSize.TabIndex = 4;
            this.nud_FontSize.Value = new decimal(new int[] {
            1525,
            0,
            0,
            131072});
            this.nud_FontSize.ValueChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            // 
            // lb_nodeColor
            // 
            this.lb_nodeColor.AutoSize = true;
            this.lb_nodeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_nodeColor.Location = new System.Drawing.Point(103, 42);
            this.lb_nodeColor.Margin = new System.Windows.Forms.Padding(3);
            this.lb_nodeColor.Name = "lb_nodeColor";
            this.lb_nodeColor.Size = new System.Drawing.Size(94, 21);
            this.lb_nodeColor.TabIndex = 1;
            this.lb_nodeColor.Text = "Node Color";
            this.lb_nodeColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_font
            // 
            this.lb_font.AutoSize = true;
            this.lb_font.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_font.Location = new System.Drawing.Point(203, 42);
            this.lb_font.Margin = new System.Windows.Forms.Padding(3);
            this.lb_font.Name = "lb_font";
            this.lb_font.Size = new System.Drawing.Size(275, 21);
            this.lb_font.TabIndex = 3;
            this.lb_font.Text = "Font";
            this.lb_font.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cb_fonts
            // 
            this.cb_fonts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_fonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fonts.FormattingEnabled = true;
            this.cb_fonts.Location = new System.Drawing.Point(203, 3);
            this.cb_fonts.Name = "cb_fonts";
            this.cb_fonts.Size = new System.Drawing.Size(275, 23);
            this.cb_fonts.TabIndex = 2;
            this.cb_fonts.SelectedIndexChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            // 
            // tabPage_EdgeSettings
            // 
            this.tabPage_EdgeSettings.Controls.Add(this.tlp_edgesColors);
            this.tabPage_EdgeSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPage_EdgeSettings.Name = "tabPage_EdgeSettings";
            this.tabPage_EdgeSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_EdgeSettings.Size = new System.Drawing.Size(788, 72);
            this.tabPage_EdgeSettings.TabIndex = 1;
            this.tabPage_EdgeSettings.Text = "Edges";
            this.tabPage_EdgeSettings.UseVisualStyleBackColor = true;
            // 
            // tlp_edgesColors
            // 
            this.tlp_edgesColors.ColumnCount = 5;
            this.tlp_edgesColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_edgesColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_edgesColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_edgesColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_edgesColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_edgesColors.Controls.Add(this.lb_edgesWeight, 4, 1);
            this.tlp_edgesColors.Controls.Add(this.pb_color4, 3, 0);
            this.tlp_edgesColors.Controls.Add(this.lb_value1, 0, 1);
            this.tlp_edgesColors.Controls.Add(this.lb_value4, 0, 1);
            this.tlp_edgesColors.Controls.Add(this.pb_color3, 2, 0);
            this.tlp_edgesColors.Controls.Add(this.lb_value3, 0, 1);
            this.tlp_edgesColors.Controls.Add(this.pb_color1, 0, 0);
            this.tlp_edgesColors.Controls.Add(this.pb_color2, 1, 0);
            this.tlp_edgesColors.Controls.Add(this.lb_value2, 0, 1);
            this.tlp_edgesColors.Controls.Add(this.label1, 4, 0);
            this.tlp_edgesColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_edgesColors.Location = new System.Drawing.Point(3, 3);
            this.tlp_edgesColors.MinimumSize = new System.Drawing.Size(300, 66);
            this.tlp_edgesColors.Name = "tlp_edgesColors";
            this.tlp_edgesColors.RowCount = 2;
            this.tlp_edgesColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.40741F));
            this.tlp_edgesColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.59259F));
            this.tlp_edgesColors.Size = new System.Drawing.Size(782, 66);
            this.tlp_edgesColors.TabIndex = 3;
            // 
            // lb_edgesWeight
            // 
            this.lb_edgesWeight.AutoSize = true;
            this.lb_edgesWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_edgesWeight.Location = new System.Drawing.Point(483, 37);
            this.lb_edgesWeight.Name = "lb_edgesWeight";
            this.lb_edgesWeight.Size = new System.Drawing.Size(296, 29);
            this.lb_edgesWeight.TabIndex = 14;
            this.lb_edgesWeight.Text = "Weight";
            this.lb_edgesWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_color4
            // 
            this.pb_color4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pb_color4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_color4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_color4.Location = new System.Drawing.Point(363, 3);
            this.pb_color4.Name = "pb_color4";
            this.pb_color4.Size = new System.Drawing.Size(114, 31);
            this.pb_color4.TabIndex = 12;
            this.pb_color4.TabStop = false;
            this.pb_color4.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_color4.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // lb_value1
            // 
            this.lb_value1.AutoSize = true;
            this.lb_value1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_value1.Location = new System.Drawing.Point(3, 40);
            this.lb_value1.Margin = new System.Windows.Forms.Padding(3);
            this.lb_value1.Name = "lb_value1";
            this.lb_value1.Size = new System.Drawing.Size(114, 23);
            this.lb_value1.TabIndex = 11;
            this.lb_value1.Text = "1";
            this.lb_value1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb_value4
            // 
            this.lb_value4.AutoSize = true;
            this.lb_value4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_value4.Location = new System.Drawing.Point(363, 40);
            this.lb_value4.Margin = new System.Windows.Forms.Padding(3);
            this.lb_value4.Name = "lb_value4";
            this.lb_value4.Size = new System.Drawing.Size(114, 23);
            this.lb_value4.TabIndex = 10;
            this.lb_value4.Text = "4";
            this.lb_value4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pb_color3
            // 
            this.pb_color3.BackColor = System.Drawing.Color.DimGray;
            this.pb_color3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_color3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_color3.Location = new System.Drawing.Point(243, 3);
            this.pb_color3.Name = "pb_color3";
            this.pb_color3.Size = new System.Drawing.Size(114, 31);
            this.pb_color3.TabIndex = 9;
            this.pb_color3.TabStop = false;
            this.pb_color3.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_color3.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // lb_value3
            // 
            this.lb_value3.AutoSize = true;
            this.lb_value3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_value3.Location = new System.Drawing.Point(243, 40);
            this.lb_value3.Margin = new System.Windows.Forms.Padding(3);
            this.lb_value3.Name = "lb_value3";
            this.lb_value3.Size = new System.Drawing.Size(114, 23);
            this.lb_value3.TabIndex = 7;
            this.lb_value3.Text = "3";
            this.lb_value3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pb_color1
            // 
            this.pb_color1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pb_color1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_color1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_color1.Location = new System.Drawing.Point(3, 3);
            this.pb_color1.Name = "pb_color1";
            this.pb_color1.Size = new System.Drawing.Size(114, 31);
            this.pb_color1.TabIndex = 6;
            this.pb_color1.TabStop = false;
            this.pb_color1.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_color1.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // pb_color2
            // 
            this.pb_color2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.pb_color2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_color2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_color2.Location = new System.Drawing.Point(123, 3);
            this.pb_color2.Name = "pb_color2";
            this.pb_color2.Size = new System.Drawing.Size(114, 31);
            this.pb_color2.TabIndex = 0;
            this.pb_color2.TabStop = false;
            this.pb_color2.BackColorChanged += new System.EventHandler(this.ChangeNodePreviewParams);
            this.pb_color2.Click += new System.EventHandler(this.PictureBox_Colors_Click);
            // 
            // lb_value2
            // 
            this.lb_value2.AutoSize = true;
            this.lb_value2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_value2.Location = new System.Drawing.Point(123, 40);
            this.lb_value2.Margin = new System.Windows.Forms.Padding(3);
            this.lb_value2.Name = "lb_value2";
            this.lb_value2.Size = new System.Drawing.Size(114, 23);
            this.lb_value2.TabIndex = 1;
            this.lb_value2.Text = "2";
            this.lb_value2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(483, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 37);
            this.label1.TabIndex = 13;
            this.label1.Text = "Edges Color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage_Profile
            // 
            this.tabPage_Profile.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_Profile.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Profile.Name = "tabPage_Profile";
            this.tabPage_Profile.Size = new System.Drawing.Size(788, 72);
            this.tabPage_Profile.TabIndex = 2;
            this.tabPage_Profile.Text = "Load Profile";
            this.tabPage_Profile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lb_saveProfile, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cb_profileName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SaveProfile, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(788, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lb_saveProfile
            // 
            this.lb_saveProfile.AutoSize = true;
            this.lb_saveProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_saveProfile.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_saveProfile.Location = new System.Drawing.Point(473, 3);
            this.lb_saveProfile.Margin = new System.Windows.Forms.Padding(3);
            this.lb_saveProfile.Name = "lb_saveProfile";
            this.lb_saveProfile.Size = new System.Drawing.Size(312, 34);
            this.lb_saveProfile.TabIndex = 12;
            this.lb_saveProfile.Text = "Save selected settings";
            this.lb_saveProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_profileName
            // 
            this.cb_profileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_profileName.FormattingEnabled = true;
            this.cb_profileName.Location = new System.Drawing.Point(3, 10);
            this.cb_profileName.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.cb_profileName.Name = "cb_profileName";
            this.cb_profileName.Size = new System.Drawing.Size(344, 23);
            this.cb_profileName.TabIndex = 0;
            this.cb_profileName.SelectedIndexChanged += new System.EventHandler(this.ProfileChanged);
            this.cb_profileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.profileName_KeyPress);
            // 
            // btn_SaveProfile
            // 
            this.btn_SaveProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveProfile.Location = new System.Drawing.Point(353, 7);
            this.btn_SaveProfile.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.btn_SaveProfile.Name = "btn_SaveProfile";
            this.btn_SaveProfile.Size = new System.Drawing.Size(114, 26);
            this.btn_SaveProfile.TabIndex = 1;
            this.btn_SaveProfile.Text = "Save Profile";
            this.btn_SaveProfile.UseVisualStyleBackColor = true;
            this.btn_SaveProfile.Click += new System.EventHandler(this.Button_SaveProfile);
            // 
            // tabPage_HideSettings
            // 
            this.tabPage_HideSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPage_HideSettings.Name = "tabPage_HideSettings";
            this.tabPage_HideSettings.Size = new System.Drawing.Size(788, 72);
            this.tabPage_HideSettings.TabIndex = 3;
            this.tabPage_HideSettings.Text = "Hide";
            this.tabPage_HideSettings.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 0;
            // 
            // lb_colorNode
            // 
            this.lb_colorNode.AutoSize = true;
            this.lb_colorNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_colorNode.Location = new System.Drawing.Point(3, 31);
            this.lb_colorNode.Name = "lb_colorNode";
            this.lb_colorNode.Size = new System.Drawing.Size(92, 23);
            this.lb_colorNode.TabIndex = 7;
            this.lb_colorNode.Text = "Колір ноди";
            this.lb_colorNode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb_angle_offset);
            this.tabPage1.Controls.Add(this.tb_float_A);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 72);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(36, 23);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(36, 23);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Center X             Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "float a";
            // 
            // tb_angle_offset
            // 
            this.tb_angle_offset.Location = new System.Drawing.Point(257, 21);
            this.tb_angle_offset.Name = "tb_angle_offset";
            this.tb_angle_offset.Size = new System.Drawing.Size(36, 23);
            this.tb_angle_offset.TabIndex = 4;
            // 
            // tb_float_A
            // 
            this.tb_float_A.Location = new System.Drawing.Point(150, 21);
            this.tb_float_A.Name = "tb_float_A";
            this.tb_float_A.Size = new System.Drawing.Size(36, 23);
            this.tb_float_A.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "float angle_offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "float angle_offset";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(387, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(36, 23);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 438);
            this.Controls.Add(this.tlp_MainTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Words Connections Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tlp_MainTable.ResumeLayout(false);
            this.gb_viewType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_MainGraphicPanel)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.tlp_loadJSON.ResumeLayout(false);
            this.gbox_connections.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl_Settings.ResumeLayout(false);
            this.tabPage_NodeSettings.ResumeLayout(false);
            this.tlp_nodeSettings.ResumeLayout(false);
            this.tlp_nodeSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_nodeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodeColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_nodeTextColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FontSize)).EndInit();
            this.tabPage_EdgeSettings.ResumeLayout(false);
            this.tlp_edgesColors.ResumeLayout(false);
            this.tlp_edgesColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color2)).EndInit();
            this.tabPage_Profile.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlp_nodeSettings;
        private System.Windows.Forms.Label lb_TextColor;
        private System.Windows.Forms.PictureBox pb_nodeColor;
        private System.Windows.Forms.PictureBox pb_nodeTextColor;
        private System.Windows.Forms.NumericUpDown nud_FontSize;
        private System.Windows.Forms.Label lb_nodeColor;
        private System.Windows.Forms.Label lb_font;
        private System.Windows.Forms.ComboBox cb_fonts;
        private System.Windows.Forms.TableLayoutPanel tlp_edgesColors;
        private System.Windows.Forms.PictureBox pb_color4;
        private System.Windows.Forms.Label lb_value1;
        private System.Windows.Forms.Label lb_value4;
        private System.Windows.Forms.PictureBox pb_color3;
        private System.Windows.Forms.Label lb_value3;
        private System.Windows.Forms.PictureBox pb_color1;
        private System.Windows.Forms.PictureBox pb_color2;
        private System.Windows.Forms.Label lb_value2;
        private System.Windows.Forms.Label lb_textStyle;
        private System.Windows.Forms.ComboBox cb_FontStyle;
        private System.Windows.Forms.Label lb_NodeSize;
        private System.Windows.Forms.NumericUpDown nud_nodeSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pb_MainGraphicPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tlp_loadJSON;
        private System.Windows.Forms.ComboBox cb_jsonPathList;
        private System.Windows.Forms.Button btn_Load_JSON_File;
        private System.Windows.Forms.Label lb_colorNode;
        private System.Windows.Forms.TableLayoutPanel tlp_MainTable;
        private System.Windows.Forms.GroupBox gbox_connections;
        private System.Windows.Forms.ListBox lv_connections;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_saveProfile;
        private System.Windows.Forms.ComboBox cb_profileName;
        private System.Windows.Forms.Button btn_SaveProfile;
        private System.Windows.Forms.GroupBox gb_viewType;
        private System.Windows.Forms.ComboBox cb_viewType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SaveGraphToImage;
        private System.Windows.Forms.TabControl tabControl_Settings;
        private System.Windows.Forms.TabPage tabPage_NodeSettings;
        private System.Windows.Forms.TabPage tabPage_EdgeSettings;
        private System.Windows.Forms.TabPage tabPage_Profile;
        private System.Windows.Forms.TabPage tabPage_HideSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_edgesWeight;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_angle_offset;
        private System.Windows.Forms.TextBox tb_float_A;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

