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
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.cbGrafik = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshPeriod = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnVac = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1053, 459);
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
            this.dgvTable.Location = new System.Drawing.Point(17, 33);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(762, 532);
            this.dgvTable.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1110, 488);
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
            this.label3.Location = new System.Drawing.Point(786, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поисковое слово";
            // 
            // tbTextForQuery
            // 
            this.tbTextForQuery.BackColor = System.Drawing.SystemColors.Window;
            this.tbTextForQuery.Location = new System.Drawing.Point(788, 310);
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
            this.tbQuery.Location = new System.Drawing.Point(790, 354);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.ReadOnly = true;
            this.tbQuery.Size = new System.Drawing.Size(335, 20);
            this.tbQuery.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(788, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Подготовленный запрос";
            // 
            // btnCheckTextQuery
            // 
            this.btnCheckTextQuery.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnCheckTextQuery.Location = new System.Drawing.Point(1131, 352);
            this.btnCheckTextQuery.Name = "btnCheckTextQuery";
            this.btnCheckTextQuery.Size = new System.Drawing.Size(24, 23);
            this.btnCheckTextQuery.TabIndex = 2;
            this.btnCheckTextQuery.UseVisualStyleBackColor = true;
            this.btnCheckTextQuery.Click += new System.EventHandler(this.btnCheckTextQuery_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1053, 488);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 617);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
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
    }
}

