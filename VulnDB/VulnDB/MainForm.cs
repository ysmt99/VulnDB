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

namespace VulnDB
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    // TODO: このコード行はデータを 'sIDfmDataSet1.SIDfm' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
        //    //this.sIDfmTableAdapter1.Fill(this.sIDfmDataSet1.SIDfm);
        //}
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync(openFileDialog1.FileName);
                    backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                    backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;

                    this.textBox1.Text = "登録処理中。。。";
                    //Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.textBox1.Text = ex.ToString();
            }
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value += e.ProgressPercentage;
            progressBar1.Maximum = (int)e.UserState;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("登録処理が完了しました。");
            string text = "";
            foreach (string s in (List<string>)e.Result)
            {
                text += s + "\r\n";
            }
            this.textBox1.Text = text;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SIDfmCsvRegister register = new SIDfmCsvRegister();
            register.progressCountUp += progressCountUp;
            //register.progressMax += progressMax;
            List<string> errors = register.doRegist((string)e.Argument);
            e.Result = errors;
        }
        private void progressCountUp(int i, int j)
        {
            backgroundWorker1.ReportProgress(i, j);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.dataGridView1.DataSource = SIDfmSearch.search();
        }
        //private void progressMax(int max)
        //{
        //    //backgroundWorker1.ReportProgress(1,1);
        //    //progressBar1.Minimum = 0;
        //    //progressBar1.Maximum = max;
        //    //progressBar1.Value = 0;
        //}
    }
}