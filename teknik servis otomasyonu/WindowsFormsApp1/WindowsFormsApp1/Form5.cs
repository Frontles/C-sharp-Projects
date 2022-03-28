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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UPDATE teslimalma set ad = '"  + textBox2.Text+  "',telno= '" +textBox1.Text+"',marka = '"+ textBox3.Text+"',ekstra = '" +textBox4.Text+"',ariza = '"+richTextBox1.Text+ "'  WHERE id =  " + Convert.ToInt32( textBox5.Text), con);
            
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bilgi Güncellemesi Başarılı  ! ", " Başarılı !", MessageBoxButtons.OK);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string telno = textBox1.Text;

            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT *  FROM  teslimalma WHERE telno=@telno";
            SqlParameter prm1 = new SqlParameter("@telno", textBox1.Text);

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(prm1);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox5.Text = Convert.ToString(dr["id"]);
                textBox2.Text = dr["ad"].ToString();
                textBox3.Text = dr["marka"].ToString();
                textBox4.Text = dr["ekstra"].ToString();
                richTextBox1.Text = dr["ariza"].ToString();
            }
            else
            {
                MessageBox.Show("Kişi Bulunamadı !", "Uyarı ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }
    }
}
