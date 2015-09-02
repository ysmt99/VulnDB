namespace VulnDB
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
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxFilter情報登録日検索終了日 = new System.Windows.Forms.CheckBox();
            this.checkBoxFilter情報登録日検索開始日 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilter登録製品名 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this.cmdbDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdbDataSet = new SIDfmContext.db.cmdbDataSet();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBarRegist = new System.Windows.Forms.ProgressBar();
            this.textBoxRegistLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorkerRegist = new System.ComponentModel.BackgroundWorker();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.checkBoxFilter = new System.Windows.Forms.CheckBox();
            this.checkedListBoxResources = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdbDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdbDataSet)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 409);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkedListBoxResources);
            this.tabPage2.Controls.Add(this.checkBoxFilter);
            this.tabPage2.Controls.Add(this.checkBoxFilter情報登録日検索終了日);
            this.tabPage2.Controls.Add(this.checkBoxFilter情報登録日検索開始日);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.textBoxFilter登録製品名);
            this.tabPage2.Controls.Add(this.dateTimePicker2);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dataGridViewSearch);
            this.tabPage2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "脆弱性一覧";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBoxFilter情報登録日検索終了日.AutoSize = true;
            this.checkBoxFilter情報登録日検索終了日.Location = new System.Drawing.Point(532, 11);
            this.checkBoxFilter情報登録日検索終了日.Name = "checkBox2";
            this.checkBoxFilter情報登録日検索終了日.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFilter情報登録日検索終了日.TabIndex = 6;
            this.checkBoxFilter情報登録日検索終了日.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBoxFilter情報登録日検索開始日.AutoSize = true;
            this.checkBoxFilter情報登録日検索開始日.Location = new System.Drawing.Point(356, 11);
            this.checkBoxFilter情報登録日検索開始日.Name = "checkBox1";
            this.checkBoxFilter情報登録日検索開始日.Size = new System.Drawing.Size(15, 14);
            this.checkBoxFilter情報登録日検索開始日.TabIndex = 6;
            this.checkBoxFilter情報登録日検索開始日.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "～";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "登録製品名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "情報登録日";
            // 
            // textBox1
            // 
            this.textBoxFilter登録製品名.Location = new System.Drawing.Point(356, 33);
            this.textBoxFilter登録製品名.Name = "textBox1";
            this.textBoxFilter登録製品名.Size = new System.Drawing.Size(326, 25);
            this.textBoxFilter登録製品名.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(553, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 25);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(377, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 25);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "最終更新日時：2015/08/05 22:42:28";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "最新の情報に更新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSerch_Click);
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowUserToAddRows = false;
            this.dataGridViewSearch.AllowUserToOrderColumns = true;
            this.dataGridViewSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearch.AutoGenerateColumns = true;
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.DataSource = this.sIDfmSQLiteDataSetBindingSource;
            this.dataGridViewSearch.Location = new System.Drawing.Point(6, 78);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.ReadOnly = true;
            this.dataGridViewSearch.RowTemplate.Height = 21;
            this.dataGridViewSearch.Size = new System.Drawing.Size(864, 285);
            this.dataGridViewSearch.TabIndex = 0;
            // 
            // sIDfmSQLiteDataSetBindingSource
            // 
            this.sIDfmSQLiteDataSetBindingSource.DataSource = this.sIDfmDataSet;
            this.sIDfmSQLiteDataSetBindingSource.Position = 0;
            // 
            // sIDfmSQLiteDataSet
            // 
            this.sIDfmDataSet.DataSetName = "SIDfmDataSet";
            this.sIDfmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.progressBarRegist);
            this.tabPage1.Controls.Add(this.textBoxRegistLog);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CSV登録";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBarRegist
            // 
            this.progressBarRegist.Location = new System.Drawing.Point(186, 23);
            this.progressBarRegist.Name = "progressBarRegist";
            this.progressBarRegist.Size = new System.Drawing.Size(665, 35);
            this.progressBarRegist.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarRegist.TabIndex = 2;
            // 
            // textBoxRegistLog
            // 
            this.textBoxRegistLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegistLog.Location = new System.Drawing.Point(22, 80);
            this.textBoxRegistLog.Multiline = true;
            this.textBoxRegistLog.Name = "textBoxRegistLog";
            this.textBoxRegistLog.Size = new System.Drawing.Size(829, 273);
            this.textBoxRegistLog.TabIndex = 1;
            this.textBoxRegistLog.TabStop = false;
            this.textBoxRegistLog.Text = "ファイルを選択してください。";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "ファイル選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // backgroundWorkerRegist
            // 
            this.backgroundWorkerRegist.WorkerReportsProgress = true;
            this.backgroundWorkerRegist.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // checkBoxFilter
            // 
            this.checkBoxFilter.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxFilter.AutoSize = true;
            this.checkBoxFilter.Checked = false;
            this.checkBoxFilter.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.checkBoxFilter.Location = new System.Drawing.Point(186, 11);
            this.checkBoxFilter.Name = "checkBox3";
            this.checkBoxFilter.Size = new System.Drawing.Size(90, 28);
            this.checkBoxFilter.TabIndex = 7;
            this.checkBoxFilter.Text = "検索フィルタ";
            this.checkBoxFilter.UseVisualStyleBackColor = true;
            this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.checkBoxFilter_CheckedChanged);
            // 
            // checkedListBoxResources
            // 
            this.checkedListBoxResources.FormattingEnabled = true;
            this.checkedListBoxResources.Location = new System.Drawing.Point(704, 6);
            this.checkedListBoxResources.Name = "checkedListBoxResources";
            this.checkedListBoxResources.Size = new System.Drawing.Size(169, 91);
            this.checkedListBoxResources.TabIndex = 8;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(908, 433);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "脆弱性／パッチ管理DB";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmSQLiteDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmDataSet)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progressBarRegist;
        private System.Windows.Forms.TextBox textBoxRegistLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRegist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
        private System.Windows.Forms.BindingSource sIDfmSQLiteDataSetBindingSource;
        private SIDfmContext.db.SIDfmDataSet sIDfmDataSet;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxFilter登録製品名;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxFilter情報登録日検索終了日;
        private System.Windows.Forms.CheckBox checkBoxFilter情報登録日検索開始日;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxFilter;
        private System.Windows.Forms.CheckedListBox checkedListBoxResources;

    }
}

