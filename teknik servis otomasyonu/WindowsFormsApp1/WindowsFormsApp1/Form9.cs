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


namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.textBox1.Text = dataGridView1.SelectedCells[3].Value.ToString();
            this.Hide();
            f10.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            da = new SqlDataAdapter("select marka,ariza,ad,telno,ekstra,teslim_tarih,iade_sebebi from  teslimalma  WHERE tamir_etme= 1 AND teslim_etme = 1", con);
            da.Fill(ds);



            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 200;
        }
    }
}
