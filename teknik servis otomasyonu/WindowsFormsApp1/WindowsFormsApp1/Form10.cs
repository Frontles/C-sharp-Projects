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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void Form10_Load(object sender, EventArgs e)
        {

            string telno = textBox1.Text;

            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT *  FROM  teslimalma WHERE telno=@telno and teslim_etme = 1";
            SqlParameter prm1 = new SqlParameter("@telno", telno);


            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(prm1);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                
                label11.Text = dr["ad"].ToString();
                label5.Text = dr["marka"].ToString();
                label9.Text = dr["fiyat"].ToString() + "₺";
                label8.Text = dr["ekstra"].ToString();
                label13.Text = dr["telno"].ToString();
                label15.Text = dr["teslim_tarih"].ToString();
                richTextBox1.Text = dr["iade_sebebi"].ToString();
                richTextBox2.Text = dr["ariza"].ToString();

                if (Convert.ToInt32(dr["teslim_etme"]) == 1)
                {
                    label7.Text = "Teslim Edildi.";
                    label7.ForeColor = Color.Green;
                }
                

                richTextBox1.Text = dr["iade_sebebi"].ToString();
            }
            else
            {
                MessageBox.Show("Bu Numaraya Kayıtlı Cihaz Bulunamadı !", "Uyarı ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            this.Hide();
            f9.Show();
        }
    }
}
