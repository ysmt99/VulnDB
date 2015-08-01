using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VulnDBSQLite.db;

namespace VulnDBSQLite
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var ent = new VulnDBSQLiteEntities())
            {
                this.dataGridView1.DataSource = (from x in ent.SIDfm
                                                orderby x.CVE番号
                                                select x).ToList();
            }
        }
    }
}
