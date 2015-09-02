using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace VulnDB
{
    public partial class MainForm : Form
    {
        readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public MainForm()
        {
            InitializeComponent();
            // 連続してCSVファイルを読むとエラー。ログに出ない。。
            backgroundWorkerRegist.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorkerRegist.ProgressChanged += backgroundWorker1_ProgressChanged;
            ///脆弱性一覧のDataGridViewの並び替えデリゲータ登録
            dataGridViewSearch.ColumnHeaderMouseClick +=  new DataGridViewCellMouseEventHandler(dataGridViewSearch_ColumnHeaderMouseClick);
        }

        List<string> resourceList_;
        private void MainForm_Load(object sender, EventArgs e)
        {
            resourceList_ = SIDfmResourceSearch.search();
            foreach(var item in resourceList_)
                this.checkedListBoxResources.Items.Add(item);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorkerRegist.RunWorkerAsync(openFileDialog1.FileName);
                    this.textBoxRegistLog.Text = "登録処理中。。。";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.textBoxRegistLog.Text = ex.ToString();
                logger.Error(ex.ToString());
            }
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarRegist.Value += e.ProgressPercentage;
            progressBarRegist.Maximum = (int)e.UserState;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("登録処理が完了しました。");
            if (e.Result != null)
                this.textBoxRegistLog.Text = string.Join("\r\n", (List<string>)e.Result);
            else
                this.textBoxRegistLog.Text = string.Empty;

            // 登録完了時に値をクリアしないと連続でCSVファイルを読み込んだときにindexエラーになる
            progressBarRegist.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SIDfmCsvRegister register = new SIDfmCsvRegister();
            register.progressCountUp += progressCountUp;
            e.Result = register.doRegist((string)e.Argument);
        }
        private void progressCountUp(int i, int j)
        {
            backgroundWorkerRegist.ReportProgress(i, j);
        }
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            try
            {
                this.sIDfmSQLiteDataSetBindingSource.DataSource = SIDfmSearch.search();
                this.sIDfmSQLiteDataSetBindingSource.RemoveFilter();
                foreach(DataGridViewColumn col in dataGridViewSearch.Columns)
                    col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                MessageBox.Show("エラーが発生しました。詳細はログファイルを確認してください。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 脆弱性一覧のDataGridViewの並び替え
        ///脆弱性一覧のDataGridViewの並び替え
        ///以下のURLを参考にして実装追加
        ///http://dobon.net/vb/dotnet/datagridview/autosort.html
        ///

        /// <summary>
        /// 脆弱性一覧のDataGridViewの並び替えデリゲータ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGridViewSearch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn clickedColumn = dataGridViewSearch.Columns[e.ColumnIndex];
            if (clickedColumn.SortMode != DataGridViewColumnSortMode.Automatic)
                this.SortRows(clickedColumn, true);
        }

        /// <summary>
        /// 指定された列を基準にして並び替えを行う
        /// </summary>
        /// <param name="sortColumn">基準にする列</param>
        /// <param name="orderToggle">並び替えの方向をトグルで変更する</param>
        private void SortRows(DataGridViewColumn sortColumn, bool orderToggle)
        {
            if (sortColumn == null)
                return;

            //今までの並び替えグリフを消す
            if (sortColumn.SortMode == DataGridViewColumnSortMode.Programmatic &&
                dataGridViewSearch.SortedColumn != null &&
                !dataGridViewSearch.SortedColumn.Equals(sortColumn))
            {
                dataGridViewSearch.SortedColumn.HeaderCell.SortGlyphDirection =
                    SortOrder.None;
            }

            //並び替えの方向（昇順か降順か）を決める
            ListSortDirection sortDirection;
            if (orderToggle)
            {
                sortDirection =
                    dataGridViewSearch.SortOrder == SortOrder.Descending ?
                    ListSortDirection.Ascending : ListSortDirection.Descending;
            }
            else
            {
                sortDirection =
                    dataGridViewSearch.SortOrder == SortOrder.Descending ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            SortOrder sortOrder =
                sortDirection == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            //並び替えを行う
            dataGridViewSearch.Sort(sortColumn, sortDirection);

            if (sortColumn.SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                //並び替えグリフを変更
                sortColumn.HeaderCell.SortGlyphDirection = sortOrder;
            }

        }
        #endregion 脆弱性一覧のDataGridViewの並び替え

        private void Filter()
        {
            StringBuilder sb = new StringBuilder();
            if (checkBoxFilter情報登録日検索開始日.Checked == true)
                sb.AppendLine(" AND 情報登録日 >= '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "'");
            if (checkBoxFilter情報登録日検索終了日.Checked == true)
                sb.AppendLine(" AND 情報登録日 <= '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'");
            if (!string.IsNullOrEmpty(textBoxFilter登録製品名.Text))
            {
                StringBuilder sb2 = new StringBuilder();
                char[] delimiters = { ' ' };
                string[] args = textBoxFilter登録製品名.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                foreach(var arg in args)
                    sb2.AppendLine(" OR 対象製品名 LIKE '*" + arg + "*'");
                sb.AppendLine(" AND ( " + sb2.ToString(4, sb2.Length - 4) + " )");
            }

            if (sb.Length > 4)
                sIDfmSQLiteDataSetBindingSource.Filter = sb.ToString(4, sb.Length - 4);
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilter.Checked)
            {
                Filter();
            }
            else
            {
                sIDfmSQLiteDataSetBindingSource.RemoveFilter();
            }
        }

    }
}