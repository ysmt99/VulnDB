using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
                    this.button1.Refresh();
                    SIDfmCsvRegister register = new SIDfmCsvRegister();
                    List<string> errors = register.doRegist(openFileDialog1.FileName);
                    this.textBox1.Text = "登録処理中。。。";
                    textBox1.Refresh();

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 10;
                    progressBar1.Value = 0;
                    
                    //Invalidate(true);
                    //時間のかかる処理を開始する
                    for (int i = 1; i <= 10; i++)
                    {
                        //progressBar1.Refresh();
                        tabControl1.Refresh();
                        //progressBar1.Invalidate(true);
                        //progressBar1.Update();

                        //1秒間待機する（時間のかかる処理があるものとする）
                        System.Threading.Thread.Sleep(1000);
                        //ProgressBar1の値を変更する
                        progressBar1.Value = i;
                    }                    
                    
                    //this.dataGridView1.Visible = true;
                    //this.dataGridView1.DataSource = SIDfmSearch.search();
                    MessageBox.Show("登録処理が完了しました。");
                    string text = "";
                    foreach (string s in errors)
                    {
                        text += s + "\r\n";
                    }
                    this.textBox1.Text = text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.textBox1.Text = ex.ToString();
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

    }
}