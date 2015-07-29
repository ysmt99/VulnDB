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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'sIDfmDataSet.SIDfm' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.sIDfmTableAdapter.Fill(this.sIDfmDataSet.SIDfm);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SIDfmCsvRegister register = new SIDfmCsvRegister();
                    register.doRegist(openFileDialog1.FileName);
                    this.dataGridView1.Visible = true;
                    this.dataGridView1.DataSource = SIDfmSearch.search();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.textBox1.Visible = true;
                this.textBox1.Text = ex.ToString();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'sIDfmDataSet1.SIDfm' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.sIDfmTableAdapter1.Fill(this.sIDfmDataSet1.SIDfm);

        }

    }
}