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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sIDfmIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.タイトルDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVE番号DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVSS基本値DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃元DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃成立条件DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃前の認証DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報漏えいDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報改ざんDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.業務停止DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.攻撃コードの有無DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.情報登録日DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNSERTDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPDATEDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIDfmViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "ファイル選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(-3, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(910, 349);
            this.textBox1.TabIndex = 1;
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
            this.攻撃元DataGridViewTextBoxColumn,
            this.攻撃成立条件DataGridViewTextBoxColumn,
            this.攻撃前の認証DataGridViewTextBoxColumn,
            this.情報漏えいDataGridViewTextBoxColumn,
            this.情報改ざんDataGridViewTextBoxColumn,
            this.業務停止DataGridViewTextBoxColumn,
            this.攻撃コードの有無DataGridViewTextBoxColumn,
            this.情報登録日DataGridViewTextBoxColumn,
            this.iNSERTDATEDataGridViewTextBoxColumn,
            this.uPDATEDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sIDfmViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(910, 349);
            this.dataGridView1.TabIndex = 2;
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
            this.タイトルDataGridViewTextBoxColumn.Width = 300;
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
            // 攻撃元DataGridViewTextBoxColumn
            // 
            this.攻撃元DataGridViewTextBoxColumn.DataPropertyName = "攻撃元";
            this.攻撃元DataGridViewTextBoxColumn.HeaderText = "攻撃元";
            this.攻撃元DataGridViewTextBoxColumn.Name = "攻撃元DataGridViewTextBoxColumn";
            this.攻撃元DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 攻撃成立条件DataGridViewTextBoxColumn
            // 
            this.攻撃成立条件DataGridViewTextBoxColumn.DataPropertyName = "攻撃成立条件";
            this.攻撃成立条件DataGridViewTextBoxColumn.HeaderText = "攻撃成立条件";
            this.攻撃成立条件DataGridViewTextBoxColumn.Name = "攻撃成立条件DataGridViewTextBoxColumn";
            this.攻撃成立条件DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 攻撃前の認証DataGridViewTextBoxColumn
            // 
            this.攻撃前の認証DataGridViewTextBoxColumn.DataPropertyName = "攻撃前の認証";
            this.攻撃前の認証DataGridViewTextBoxColumn.HeaderText = "攻撃前の認証";
            this.攻撃前の認証DataGridViewTextBoxColumn.Name = "攻撃前の認証DataGridViewTextBoxColumn";
            this.攻撃前の認証DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 情報漏えいDataGridViewTextBoxColumn
            // 
            this.情報漏えいDataGridViewTextBoxColumn.DataPropertyName = "情報漏えい";
            this.情報漏えいDataGridViewTextBoxColumn.HeaderText = "情報漏えい";
            this.情報漏えいDataGridViewTextBoxColumn.Name = "情報漏えいDataGridViewTextBoxColumn";
            this.情報漏えいDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 情報改ざんDataGridViewTextBoxColumn
            // 
            this.情報改ざんDataGridViewTextBoxColumn.DataPropertyName = "情報改ざん";
            this.情報改ざんDataGridViewTextBoxColumn.HeaderText = "情報改ざん";
            this.情報改ざんDataGridViewTextBoxColumn.Name = "情報改ざんDataGridViewTextBoxColumn";
            this.情報改ざんDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 業務停止DataGridViewTextBoxColumn
            // 
            this.業務停止DataGridViewTextBoxColumn.DataPropertyName = "業務停止";
            this.業務停止DataGridViewTextBoxColumn.HeaderText = "業務停止";
            this.業務停止DataGridViewTextBoxColumn.Name = "業務停止DataGridViewTextBoxColumn";
            this.業務停止DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 攻撃コードの有無DataGridViewTextBoxColumn
            // 
            this.攻撃コードの有無DataGridViewTextBoxColumn.DataPropertyName = "攻撃コードの有無";
            this.攻撃コードの有無DataGridViewTextBoxColumn.HeaderText = "攻撃コードの有無";
            this.攻撃コードの有無DataGridViewTextBoxColumn.Name = "攻撃コードの有無DataGridViewTextBoxColumn";
            this.攻撃コードの有無DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 情報登録日DataGridViewTextBoxColumn
            // 
            this.情報登録日DataGridViewTextBoxColumn.DataPropertyName = "情報登録日";
            this.情報登録日DataGridViewTextBoxColumn.HeaderText = "情報登録日";
            this.情報登録日DataGridViewTextBoxColumn.Name = "情報登録日DataGridViewTextBoxColumn";
            // 
            // iNSERTDATEDataGridViewTextBoxColumn
            // 
            this.iNSERTDATEDataGridViewTextBoxColumn.DataPropertyName = "INSERT_DATE";
            this.iNSERTDATEDataGridViewTextBoxColumn.HeaderText = "INSERT_DATE";
            this.iNSERTDATEDataGridViewTextBoxColumn.Name = "iNSERTDATEDataGridViewTextBoxColumn";
            // 
            // uPDATEDATEDataGridViewTextBoxColumn
            // 
            this.uPDATEDATEDataGridViewTextBoxColumn.DataPropertyName = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn.HeaderText = "UPDATE_DATE";
            this.uPDATEDATEDataGridViewTextBoxColumn.Name = "uPDATEDATEDataGridViewTextBoxColumn";
            // 
            // sIDfmViewBindingSource
            // 
            this.sIDfmViewBindingSource.DataSource = typeof(SIDfmContext.view.SIDfmView);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(908, 433);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "脆弱性／パッチ管理DB";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sIDfmViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDfmIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn タイトルDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVE番号DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVSS基本値DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃元DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃成立条件DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃前の認証DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報漏えいDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報改ざんDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 業務停止DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 攻撃コードの有無DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 情報登録日DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNSERTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPDATEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sIDfmViewBindingSource;

    }
}

