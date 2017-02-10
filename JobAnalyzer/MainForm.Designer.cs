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
            this.btnRefreshRegion = new System.Windows.Forms.Button();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckTextQuery = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1134, 413);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Запрос";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(12, 12);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.Size = new System.Drawing.Size(779, 522);
            this.dgvTable.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1134, 439);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(941, 413);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Анализ";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            // 
            // btnAddKeyforAnalyze
            // 
            this.btnAddKeyforAnalyze.Location = new System.Drawing.Point(814, 384);
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
            this.lbKeys.Location = new System.Drawing.Point(814, 439);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.Size = new System.Drawing.Size(120, 95);
            this.lbKeys.TabIndex = 5;
            this.lbKeys.DoubleClick += new System.EventHandler(this.lbKeys_DoubleClick);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(814, 413);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(120, 20);
            this.tbKey.TabIndex = 6;
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(814, 37);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 7;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(811, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Страна";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(810, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Поисковое слово";
            // 
            // tbTextForQuery
            // 
            this.tbTextForQuery.Location = new System.Drawing.Point(812, 259);
            this.tbTextForQuery.Name = "tbTextForQuery";
            this.tbTextForQuery.Size = new System.Drawing.Size(291, 20);
            this.tbTextForQuery.TabIndex = 6;
            // 
            // btnRefreshCountry
            // 
            this.btnRefreshCountry.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnRefreshCountry.Location = new System.Drawing.Point(941, 35);
            this.btnRefreshCountry.Name = "btnRefreshCountry";
            this.btnRefreshCountry.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshCountry.TabIndex = 2;
            this.btnRefreshCountry.UseVisualStyleBackColor = true;
            this.btnRefreshCountry.Click += new System.EventHandler(this.btnRefreshCountry_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(813, 64);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(290, 176);
            this.treeView1.TabIndex = 12;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // btnRefreshRegion
            // 
            this.btnRefreshRegion.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnRefreshRegion.Location = new System.Drawing.Point(1109, 64);
            this.btnRefreshRegion.Name = "btnRefreshRegion";
            this.btnRefreshRegion.Size = new System.Drawing.Size(24, 23);
            this.btnRefreshRegion.TabIndex = 2;
            this.btnRefreshRegion.UseVisualStyleBackColor = true;
            this.btnRefreshRegion.Click += new System.EventHandler(this.btnRefreshRegion_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(814, 303);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.ReadOnly = true;
            this.tbQuery.Size = new System.Drawing.Size(266, 20);
            this.tbQuery.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Подготовленный запрос";
            // 
            // btnCheckTextQuery
            // 
            this.btnCheckTextQuery.Image = global::JobAnalyzer.Properties.Resources.refresh;
            this.btnCheckTextQuery.Location = new System.Drawing.Point(1086, 301);
            this.btnCheckTextQuery.Name = "btnCheckTextQuery";
            this.btnCheckTextQuery.Size = new System.Drawing.Size(24, 23);
            this.btnCheckTextQuery.TabIndex = 2;
            this.btnCheckTextQuery.UseVisualStyleBackColor = true;
            this.btnCheckTextQuery.Click += new System.EventHandler(this.btnCheckTextQuery_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1116, 301);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(51, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 546);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.tbTextForQuery);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lbKeys);
            this.Controls.Add(this.btnAddKeyforAnalyze);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnCheckTextQuery);
            this.Controls.Add(this.btnRefreshRegion);
            this.Controls.Add(this.btnRefreshCountry);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.btnQuery);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnRefreshRegion;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckTextQuery;
        private System.Windows.Forms.Button btnReset;
    }
}

