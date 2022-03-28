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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("UPDATE teslimalma set fiyat = '" + textBox4.Text + "',iade_sebebi = '" + richTextBox1.Text + "'  WHERE id =  " + Convert.ToInt32(textBox2.Text), con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşlem Başarılı  ! ", " Başarılı !", MessageBoxButtons.OK);
            Form6 f6 = new Form6();
            this.Hide();
            f6.Show();
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string telno = textBox1.Text;

            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT *  FROM  teslimalma WHERE telno=@telno";
            SqlParameter prm1 = new SqlParameter("@telno", telno);

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(prm1);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = Convert.ToString(dr["id"]);
                textBox4.Text = Convert.ToString(dr["fiyat"]);
                richTextBox1.Text = Convert.ToString(dr["iade_sebebi"]);

            }
            else
            {
                MessageBox.Show("Kişi Bulunamadı !", "Uyarı ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }
    }
}
