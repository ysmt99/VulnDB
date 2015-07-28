namespace VulnDB
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sIDfmIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.タイトルDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVE番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVSS基本値DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃元区分DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃条件の複雑さDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃前の認証要否DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報漏えいDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報改竄DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.業務停止DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃コードの有無DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報登録日DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIDfmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sIDfmDataSet = new SIDfmContext.SIDfmDataSet();
            this.sIDfmTableAdapter = new SIDfmContext.SIDfmDataSetTableAdapters.SIDfmTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSVファイル（*.csv）|*.csv";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ファイルを開く";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(0, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1219, 522);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIDfmIdDataGridViewTextBoxColumn,
            this.タイトルDataGridViewTextBoxColumn,
            this.cVE番号DataGridViewTextBoxColumn,
            this.cVSS基本値DataGridViewTextBoxColumn,
            this.攻撃元区分DataGridViewTextBoxColumn,
            this.攻撃条件の複雑さDataGridViewTextBoxColumn,
            this.攻撃前の認証要否DataGridViewTextBoxColumn,
            this.情報漏えいDataGridViewTextBoxColumn,
            this.情報改竄DataGridViewTextBoxColumn,
            this.業務停止DataGridViewTextBoxColumn,
            this.攻撃コードの有無DataGridViewTextBoxColumn,
            this.情報登録日DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sIDfmBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1208, 522);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            // 
            // sIDfmIdDataGridViewTextBoxColumn
            // 
            this.sIDfmIdDataGridViewTextBoxColumn.DataPropertyName = "SIDfmId";
            this.sIDfmIdDataGridViewTextBoxColumn.HeaderText = "SIDfmId";
            this.sIDfmIdDataGridViewTextBoxColumn.Name = "sIDfmIdDataGridViewTextBoxColumn";
            // 
            // タイトルDataGridViewTextBoxColumn
            // 
            this.タイトルDataGridViewTextBoxColumn.DataPropertyName = "タイトル";
            this.タイトルDataGridViewTextBoxColumn.HeaderText = "タイトル";
            this.タイトルDataGridViewTextBoxColumn.Name = "タイトルDataGridViewTextBoxColumn";
            // 
            // cVE番号DataGridViewTextBoxColumn
            // 
            this.cVE番号DataGridViewTextBoxColumn.DataPropertyName = "CVE番号";
            this.cVE番号DataGridViewTextBoxColumn.HeaderText = "CVE番号";
            this.cVE番号DataGridViewTextBoxColumn.Name = "cVE番号DataGridViewTextBoxColumn";
            // 
            // cVSS基本値DataGridViewTextBoxColumn
            // 
            this.cVSS基本値DataGridViewTextBoxColumn.DataPropertyName = "CVSS基本値";
            this.cVSS基本値DataGridViewTextBoxColumn.HeaderText = "CVSS基本値";
            this.cVSS基本値DataGridViewTextBoxColumn.Name = "cVSS基本値DataGridViewTextBoxColumn";
            // 
            // 攻撃元区分DataGridViewTextBoxColumn
            // 
            this.攻撃元区分DataGridViewTextBoxColumn.DataPropertyName = "攻撃元区分";
            this.攻撃元区分DataGridViewTextBoxColumn.HeaderText = "攻撃元区分";
            this.攻撃元区分DataGridViewTextBoxColumn.Name = "攻撃元区分DataGridViewTextBoxColumn";
            // 
            // 攻撃条件の複雑さDataGridViewTextBoxColumn
            // 
            this.攻撃条件の複雑さDataGridViewTextBoxColumn.DataPropertyName = "攻撃条件の複雑さ";
            this.攻撃条件の複雑さDataGridViewTextBoxColumn.HeaderText = "攻撃条件の複雑さ";
            this.攻撃条件の複雑さDataGridViewTextBoxColumn.Name = "攻撃条件の複雑さDataGridViewTextBoxColumn";
            // 
            // 攻撃前の認証要否DataGridViewTextBoxColumn
            // 
            this.攻撃前の認証要否DataGridViewTextBoxColumn.DataPropertyName = "攻撃前の認証要否";
            this.攻撃前の認証要否DataGridViewTextBoxColumn.HeaderText = "攻撃前の認証要否";
            this.攻撃前の認証要否DataGridViewTextBoxColumn.Name = "攻撃前の認証要否DataGridViewTextBoxColumn";
            // 
            // 情報漏えいDataGridViewTextBoxColumn
            // 
            this.情報漏えいDataGridViewTextBoxColumn.DataPropertyName = "情報漏えい";
            this.情報漏えいDataGridViewTextBoxColumn.HeaderText = "情報漏えい";
            this.情報漏えいDataGridViewTextBoxColumn.Name = "情報漏えいDataGridViewTextBoxColumn";
            // 
            // 情報改竄DataGridViewTextBoxColumn
            // 
            this.情報改竄DataGridViewTextBoxColumn.DataPropertyName = "情報改竄";
            this.情報改竄DataGridViewTextBoxColumn.HeaderText = "情報改竄";
            this.情報改竄DataGridViewTextBoxColumn.Name = "情報改竄DataGridViewTextBoxColumn";
            // 
            // 業務停止DataGridViewTextBoxColumn
            // 
            this.業務停止DataGridViewTextBoxColumn.DataPropertyName = "業務停止";
            this.業務停止DataGridViewTextBoxColumn.HeaderText = "業務停止";
            this.業務停止DataGridViewTextBoxColumn.Name = "業務停止DataGridViewTextBoxColumn";
            // 
            // 攻撃コードの有無DataGridViewTextBoxColumn
            // 
            this.攻撃コードの有無DataGridViewTextBoxColumn.DataPropertyName = "攻撃コードの有無";
            this.攻撃コードの有無DataGridViewTextBoxColumn.HeaderText = "攻撃コードの有無";
            this.攻撃コードの有無DataGridViewTextBoxColumn.Name = "攻撃コードの有無DataGridViewTextBoxColumn";
            // 
            // 情報登録日DataGridViewTextBoxColumn
            // 
            this.情報登録日DataGridViewTextBoxColumn.DataPropertyName = "情報登録日";
            this.情報登録日DataGridViewTextBoxColumn.HeaderText = "情報登録日";
            this.情報登録日DataGridViewTextBoxColumn.Name = "情報登録日DataGridViewTextBoxColumn";
            // 
            // sIDfmBindingSource
            // 
            this.sIDfmBindingSource.DataMember = "SIDfm";
            this.sIDfmBindingSource.DataSource = this.sIDfmDataSet;
            // 
            // sIDfmDataSet
            // 
            this.sIDfmDataSet.DataSetName = "SIDfmDataSet";
            this.sIDfmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sIDfmTableAdapter
            // 
            this.sIDfmTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 552);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SIDfmContext.SIDfmDataSet sIDfmDataSet;
        private System.Windows.Forms.BindingSource sIDfmBindingSource;
        private SIDfmContext.SIDfmDataSetTableAdapters.SIDfmTableAdapter sIDfmTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDfmIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn タイトルDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVE番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVSS基本値DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃元区分DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃条件の複雑さDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃前の認証要否DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報漏えいDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報改竄DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 業務停止DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃コードの有無DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報登録日DataGridViewTextBoxColumn;

    }
}

