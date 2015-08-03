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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.button1.Refresh();
                    SIDfmCsvRegister register = new SIDfmCsvRegister();
                    ErrorOfAll error = register.doRegist(openFileDialog1.FileName);
                    this.progressBar1.Visible = false;
                    this.dataGridView1.Visible = true;
                    this.dataGridView1.DataSource = SIDfmSearch.search();
                    MessageBox.Show("完了しました");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.progressBar1.Visible = false;
                this.textBox1.Visible = true;
                this.textBox1.Text = ex.ToString();
            }

        }
    }
}