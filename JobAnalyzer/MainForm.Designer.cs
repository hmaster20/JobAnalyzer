namespace JobAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripLabel toolStripLabel3;
            System.Windows.Forms.ToolStripLabel toolStripLabel5;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.Windows.Forms.ToolStripLabel toolStripLabel2;
            System.Windows.Forms.Splitter Splitter;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnAddKeyforAnalyze = new System.Windows.Forms.Button();
            this.lbKeys = new System.Windows.Forms.ListBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTextForQuery = new System.Windows.Forms.TextBox();
            this.btnRefreshCountry = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckTextQuery = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDBtoDiagram = new System.Windows.Forms.Button();
            this.btnCheckDB = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnCheckSpecs = new System.Windows.Forms.Button();
            this.cbSpecs = new System.Windows.Forms.ComboBox();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.cbGrafik = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshPeriod = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnVac = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolStripButtonGo = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripButtonEditBlacklist = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxLayout = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxFont = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxMinFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxMaxFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listViewOldRequest = new System.Windows.Forms.ListView();
            this.hideAndBlackListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnEmpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            Splitter = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new System.Drawing.Size(46, 29);
            toolStripLabel3.Text = "Layout:";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new System.Drawing.Size(34, 29);
            toolStripLabel5.Text = "Font:";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(58, 29);
            toolStripLabel1.Text = "size from:";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(21, 29);
            toolStripLabel2.Text = "to:";
            // 
            // Splitter
            // 
            Splitter.Dock = System.Windows.Forms.DockStyle.Right;
            Splitter.Location = new System.Drawing.Point(1218, 0);
            Splitter.Name = "Splitter";
            Splitter.Size = new System.Drawing.Size(3, 617);
            Splitter.TabIndex = 16;
            Splitter.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1050, 513);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(132, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Выполнить запрос";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnID,
            this.cmnName,
            this.cmnDesc,
            this.cmnDate,
            this.cmnArea,
            this.cmnEmpl});
            this.dgvTable.Location = new System.Drawing.Point(17, 33);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(762, 532);
            this.dgvTable.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1107, 542);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(20, 189);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(120, 23);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Выполнить анализ";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnAddKeyforAnalyze
            // 
            this.btnAddKeyforAnalyze.Location = new System.Drawing.Point(20, 33);
            this.btnAddKeyforAnalyze.Name = "btnAddKeyforAnalyze";
            this.btnAddKeyforAnalyze.Size = new System.Drawing.Size(120, 23);
            this.btnAddKeyforAnalyze.TabIndex = 4;
            this.btnAddKeyforAnalyze.Text = "Добавить";
            this.btnAddKeyforAnalyze.UseVisualStyleBackColor = true;
            this.btnAddKeyforAnalyze.Click += new System.EventHandler(this.btnAddKeyforAnalyze_Click);
            // 
            // lbKeys
            // 
            this.lbKeys.FormattingEnabled = true;
            this.lbKeys.Location = new System.Drawing.Point(20, 88);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.Size = new System.Drawing.Size(120, 95);
            this.lbKeys.TabIndex = 5;
            this.lbKeys.DoubleClick += new System.EventHandler(this.lbKeys_DoubleClick);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(20, 62);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(120, 20);
            this.tbKey.TabIndex = 6;
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(790, 33);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 7;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Страна";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(786, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поисковое слово";
            // 
            // tbTextForQuery
            // 
            this.tbTextForQuery.BackColor = System.Drawing.SystemColors.Window;
            this.tbTextForQuery.Location = new System.Drawing.Point(788, 354);
            this.tbTextForQuery.Name = "tbTextForQuery";
            this.tbTextForQuery.Size = new System.Drawing.Size(367, 20);
            this.tbTextForQuery.TabIndex = 6;
            // 
            // btnRefreshCountry
            // 
            this.btnRefreshCountry.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnRefreshCountry.Location = new System.Drawing.Point(917, 31);
            this.btnRefreshCountry.Name = "btnRefreshCountry";
            this.btnRefreshCountry.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshCountry.TabIndex = 2;
            this.btnRefreshCountry.UseVisualStyleBackColor = true;
            this.btnRefreshCountry.Click += new System.EventHandler(this.btnRefreshCountry_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Location = new System.Drawing.Point(789, 61);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(366, 187);
            this.treeView1.TabIndex = 12;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(788, 408);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.ReadOnly = true;
            this.tbQuery.Size = new System.Drawing.Size(335, 20);
            this.tbQuery.TabIndex = 6;
            this.tbQuery.DoubleClick += new System.EventHandler(this.tbQuery_DoubleClick);
            this.tbQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuery_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(786, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Подготовленный запрос";
            // 
            // btnCheckTextQuery
            // 
            this.btnCheckTextQuery.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnCheckTextQuery.Location = new System.Drawing.Point(1131, 406);
            this.btnCheckTextQuery.Name = "btnCheckTextQuery";
            this.btnCheckTextQuery.Size = new System.Drawing.Size(24, 23);
            this.btnCheckTextQuery.TabIndex = 2;
            this.btnCheckTextQuery.UseVisualStyleBackColor = true;
            this.btnCheckTextQuery.Click += new System.EventHandler(this.btnCheckTextQuery_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1050, 542);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(51, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1221, 617);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnDBtoDiagram);
            this.tabPage1.Controls.Add(this.btnCheckDB);
            this.tabPage1.Controls.Add(this.btnInit);
            this.tabPage1.Controls.Add(this.btnCheckSpecs);
            this.tabPage1.Controls.Add(this.cbSpecs);
            this.tabPage1.Controls.Add(this.dgvTable);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.cbPeriod);
            this.tabPage1.Controls.Add(this.cbGrafik);
            this.tabPage1.Controls.Add(this.cbCountry);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.btnQuery);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnRefreshPeriod);
            this.tabPage1.Controls.Add(this.btnRefreshCountry);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnCheckTextQuery);
            this.tabPage1.Controls.Add(this.tbTextForQuery);
            this.tabPage1.Controls.Add(this.tbQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1213, 591);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Форма запроса";
            // 
            // btnDBtoDiagram
            // 
            this.btnDBtoDiagram.Location = new System.Drawing.Point(790, 501);
            this.btnDBtoDiagram.Name = "btnDBtoDiagram";
            this.btnDBtoDiagram.Size = new System.Drawing.Size(134, 23);
            this.btnDBtoDiagram.TabIndex = 19;
            this.btnDBtoDiagram.Text = "from DB to diagram";
            this.btnDBtoDiagram.UseVisualStyleBackColor = true;
            this.btnDBtoDiagram.Click += new System.EventHandler(this.btnDBtoDiagram_Click);
            // 
            // btnCheckDB
            // 
            this.btnCheckDB.Location = new System.Drawing.Point(790, 472);
            this.btnCheckDB.Name = "btnCheckDB";
            this.btnCheckDB.Size = new System.Drawing.Size(134, 23);
            this.btnCheckDB.TabIndex = 18;
            this.btnCheckDB.Text = "from DB to many files";
            this.btnCheckDB.UseVisualStyleBackColor = true;
            this.btnCheckDB.Click += new System.EventHandler(this.btnCheckDB_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(1131, 17);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(32, 19);
            this.btnInit.TabIndex = 17;
            this.btnInit.Text = "init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnCheckSpecs
            // 
            this.btnCheckSpecs.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnCheckSpecs.Location = new System.Drawing.Point(1132, 312);
            this.btnCheckSpecs.Name = "btnCheckSpecs";
            this.btnCheckSpecs.Size = new System.Drawing.Size(24, 23);
            this.btnCheckSpecs.TabIndex = 16;
            this.btnCheckSpecs.UseVisualStyleBackColor = true;
            this.btnCheckSpecs.Click += new System.EventHandler(this.btnCheckSpecs_Click);
            // 
            // cbSpecs
            // 
            this.cbSpecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecs.FormattingEnabled = true;
            this.cbSpecs.Location = new System.Drawing.Point(788, 314);
            this.cbSpecs.Name = "cbSpecs";
            this.cbSpecs.Size = new System.Drawing.Size(338, 21);
            this.cbSpecs.TabIndex = 15;
            this.cbSpecs.SelectedIndexChanged += new System.EventHandler(this.cbSpecs_SelectedIndexChanged);
            // 
            // cbPeriod
            // 
            this.cbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(1034, 270);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbPeriod.TabIndex = 7;
            this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
            // 
            // cbGrafik
            // 
            this.cbGrafik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrafik.FormattingEnabled = true;
            this.cbGrafik.Location = new System.Drawing.Point(788, 270);
            this.cbGrafik.Name = "cbGrafik";
            this.cbGrafik.Size = new System.Drawing.Size(121, 21);
            this.cbGrafik.TabIndex = 7;
            this.cbGrafik.SelectedIndexChanged += new System.EventHandler(this.cbGrafik_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1031, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Период";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(786, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Профессиональная область";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(785, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "График работы";
            // 
            // btnRefreshPeriod
            // 
            this.btnRefreshPeriod.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnRefreshPeriod.Location = new System.Drawing.Point(917, 268);
            this.btnRefreshPeriod.Name = "btnRefreshPeriod";
            this.btnRefreshPeriod.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshPeriod.TabIndex = 2;
            this.btnRefreshPeriod.UseVisualStyleBackColor = true;
            this.btnRefreshPeriod.Click += new System.EventHandler(this.btnRefreshPeriod_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbKeys);
            this.tabPage2.Controls.Add(this.btnAnalyze);
            this.tabPage2.Controls.Add(this.btnAddKeyforAnalyze);
            this.tabPage2.Controls.Add(this.tbKey);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1213, 591);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Форма анализа";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnVac);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1213, 591);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Форма отчета";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnVac
            // 
            this.btnVac.Location = new System.Drawing.Point(47, 76);
            this.btnVac.Name = "btnVac";
            this.btnVac.Size = new System.Drawing.Size(75, 23);
            this.btnVac.TabIndex = 0;
            this.btnVac.Text = "button1";
            this.btnVac.UseVisualStyleBackColor = true;
            this.btnVac.Click += new System.EventHandler(this.btnVac_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.splitContainer1);
            this.tabPage4.Controls.Add(this.MainToolStrip);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1213, 591);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Диаграмма";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1213, 559);
            this.splitContainer1.SplitterDistance = 776;
            this.splitContainer1.TabIndex = 18;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonGo,
            this.ToolStripButtonCancel,
            this.ToolStripProgressBar,
            this.toolStripButtonSave,
            this.toolStripSeparator1,
            this.toolStripComboBoxLanguage,
            this.ToolStripButtonEditBlacklist,
            this.toolStripSeparator2,
            toolStripLabel3,
            this.toolStripComboBoxLayout,
            toolStripLabel5,
            this.toolStripComboBoxFont,
            toolStripLabel1,
            this.toolStripComboBoxMinFontSize,
            toolStripLabel2,
            this.toolStripComboBoxMaxFontSize,
            this.toolStripLabel4,
            this.toolStripSeparator3});
            this.MainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(1213, 32);
            this.MainToolStrip.TabIndex = 17;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // ToolStripButtonGo
            // 
            this.ToolStripButtonGo.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonGo.Image")));
            this.ToolStripButtonGo.ImageTransparentColor = System.Drawing.Color.White;
            this.ToolStripButtonGo.Name = "ToolStripButtonGo";
            this.ToolStripButtonGo.Size = new System.Drawing.Size(78, 29);
            this.ToolStripButtonGo.Text = "Generate";
            this.ToolStripButtonGo.Click += new System.EventHandler(this.ToolStripButtonGoClick);
            // 
            // ToolStripButtonCancel
            // 
            this.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonCancel.Enabled = false;
            this.ToolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCancel.Image")));
            this.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonCancel.Name = "ToolStripButtonCancel";
            this.ToolStripButtonCancel.Size = new System.Drawing.Size(47, 29);
            this.ToolStripButtonCancel.Text = "Cancel";
            // 
            // ToolStripProgressBar
            // 
            this.ToolStripProgressBar.Margin = new System.Windows.Forms.Padding(3);
            this.ToolStripProgressBar.Name = "ToolStripProgressBar";
            this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 26);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(80, 29);
            this.toolStripButtonSave.Text = "Snapshot";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripComboBoxLanguage
            // 
            this.toolStripComboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxLanguage.Items.AddRange(new object[] {
            "c#",
            "Java",
            "C++",
            "VB.NET",
            "English *.txt",
            "Any *.txt"});
            this.toolStripComboBoxLanguage.Name = "toolStripComboBoxLanguage";
            this.toolStripComboBoxLanguage.Size = new System.Drawing.Size(75, 32);
            // 
            // ToolStripButtonEditBlacklist
            // 
            this.ToolStripButtonEditBlacklist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStripButtonEditBlacklist.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonEditBlacklist.Image")));
            this.ToolStripButtonEditBlacklist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButtonEditBlacklist.Name = "ToolStripButtonEditBlacklist";
            this.ToolStripButtonEditBlacklist.Size = new System.Drawing.Size(77, 29);
            this.ToolStripButtonEditBlacklist.Text = "Edit Blacklist";
            this.ToolStripButtonEditBlacklist.Click += new System.EventHandler(this.ToolStripButtonEditBlacklistClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripComboBoxLayout
            // 
            this.toolStripComboBoxLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxLayout.Name = "toolStripComboBoxLayout";
            this.toolStripComboBoxLayout.Size = new System.Drawing.Size(121, 32);
            this.toolStripComboBoxLayout.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxFontSelectedIndexChanged);
            // 
            // toolStripComboBoxFont
            // 
            this.toolStripComboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxFont.DropDownWidth = 150;
            this.toolStripComboBoxFont.Name = "toolStripComboBoxFont";
            this.toolStripComboBoxFont.Size = new System.Drawing.Size(150, 32);
            this.toolStripComboBoxFont.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxFontSelectedIndexChanged);
            // 
            // toolStripComboBoxMinFontSize
            // 
            this.toolStripComboBoxMinFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMinFontSize.DropDownWidth = 75;
            this.toolStripComboBoxMinFontSize.Items.AddRange(new object[] {
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "20",
            "24",
            "28",
            "36",
            "48",
            "72"});
            this.toolStripComboBoxMinFontSize.Name = "toolStripComboBoxMinFontSize";
            this.toolStripComboBoxMinFontSize.Size = new System.Drawing.Size(75, 32);
            this.toolStripComboBoxMinFontSize.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxFontSelectedIndexChanged);
            // 
            // toolStripComboBoxMaxFontSize
            // 
            this.toolStripComboBoxMaxFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxMaxFontSize.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16",
            "20",
            "24",
            "28",
            "36",
            "48",
            "60",
            "72",
            "80",
            "86"});
            this.toolStripComboBoxMaxFontSize.Name = "toolStripComboBoxMaxFontSize";
            this.toolStripComboBoxMaxFontSize.Size = new System.Drawing.Size(75, 32);
            this.toolStripComboBoxMaxFontSize.SelectedIndexChanged += new System.EventHandler(this.ToolStripComboBoxFontSelectedIndexChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(0, 29);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listViewOldRequest);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1213, 591);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Последние запросы";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listViewOldRequest
            // 
            this.listViewOldRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOldRequest.Location = new System.Drawing.Point(0, 0);
            this.listViewOldRequest.Name = "listViewOldRequest";
            this.listViewOldRequest.Size = new System.Drawing.Size(1213, 591);
            this.listViewOldRequest.TabIndex = 1;
            this.listViewOldRequest.UseCompatibleStateImageBehavior = false;
            this.listViewOldRequest.DoubleClick += new System.EventHandler(this.listViewOldRequest_DoubleClick);
            // 
            // hideAndBlackListMenuItem
            // 
            this.hideAndBlackListMenuItem.Name = "hideAndBlackListMenuItem";
            this.hideAndBlackListMenuItem.Size = new System.Drawing.Size(208, 22);
            this.hideAndBlackListMenuItem.Text = "Hide and add to black list";
            this.hideAndBlackListMenuItem.Click += new System.EventHandler(this.HideAndBlackListMenuItemClick);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideMenuItem,
            this.hideAndBlackListMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(209, 48);
            // 
            // hideMenuItem
            // 
            this.hideMenuItem.Name = "hideMenuItem";
            this.hideMenuItem.Size = new System.Drawing.Size(208, 22);
            this.hideMenuItem.Text = "Hide this word";
            this.hideMenuItem.Click += new System.EventHandler(this.HideMenuItemClick);
            // 
            // toolTip
            // 
            this.toolTip.Active = false;
            this.toolTip.AutomaticDelay = 2000;
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 2000;
            this.toolTip.ReshowDelay = 1000;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "Statistics:";
            // 
            // cmnID
            // 
            this.cmnID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnID.DataPropertyName = "dgvID";
            this.cmnID.HeaderText = "ID";
            this.cmnID.Name = "cmnID";
            this.cmnID.ReadOnly = true;
            this.cmnID.Width = 43;
            // 
            // cmnName
            // 
            this.cmnName.DataPropertyName = "dgvNAME";
            this.cmnName.HeaderText = "Название";
            this.cmnName.Name = "cmnName";
            this.cmnName.ReadOnly = true;
            // 
            // cmnDesc
            // 
            this.cmnDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDesc.DataPropertyName = "dgvDESC";
            this.cmnDesc.HeaderText = "Описание";
            this.cmnDesc.Name = "cmnDesc";
            this.cmnDesc.ReadOnly = true;
            // 
            // cmnDate
            // 
            this.cmnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cmnDate.DataPropertyName = "dgvDATE";
            this.cmnDate.HeaderText = "Дата";
            this.cmnDate.Name = "cmnDate";
            this.cmnDate.ReadOnly = true;
            this.cmnDate.Width = 58;
            // 
            // cmnArea
            // 
            this.cmnArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.cmnArea.DataPropertyName = "dgvAREA";
            this.cmnArea.HeaderText = "Расположение";
            this.cmnArea.Name = "cmnArea";
            this.cmnArea.ReadOnly = true;
            this.cmnArea.Width = 21;
            // 
            // cmnEmpl
            // 
            this.cmnEmpl.DataPropertyName = "dgvEMPL";
            this.cmnEmpl.HeaderText = "Работодатель";
            this.cmnEmpl.Name = "cmnEmpl";
            this.cmnEmpl.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 617);
            this.Controls.Add(Splitter);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "JobAnalyzer";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnAddKeyforAnalyze;
        private System.Windows.Forms.ListBox lbKeys;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTextForQuery;
        private System.Windows.Forms.Button btnRefreshCountry;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckTextQuery;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbGrafik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRefreshPeriod;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnVac;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnCheckSpecs;
        private System.Windows.Forms.ComboBox cbSpecs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem hideAndBlackListMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem hideMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMaxFontSize;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMinFontSize;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFont;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLayout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ToolStripButtonEditBlacklist;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLanguage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
        private System.Windows.Forms.ToolStripButton ToolStripButtonGo;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnCheckDB;
        private System.Windows.Forms.Button btnDBtoDiagram;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listViewOldRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEmpl;
    }
}

