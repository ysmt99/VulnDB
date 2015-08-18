using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System;
using log4net;

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
            this.dataGridViewSearch.DataSource = SIDfmSearch.search();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}