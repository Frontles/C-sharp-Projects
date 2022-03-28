using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sayitahminoyun2
{
    public partial class Form1 : Form
    {


        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=sayitahmin ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();

            f2.comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            da = new SqlDataAdapter("select TOP 10 Isim,skor from sayitahmin ORDER BY skor asc", con);
            da.Fill(ds);
            
            Form3 f3 = new Form3();
            f3.Show();
            f3.dataGridView1.DataSource = ds.Tables[0];
            this.Hide();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
