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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            string telno = textBox4.Text;

            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "SELECT *  FROM  teslimalma WHERE telno=@telno and teslim_etme = 0";
            SqlParameter prm1 = new SqlParameter("@telno", telno);
           

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(prm1);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = Convert.ToString(dr["id"]);
                label5.Text = dr["ad"].ToString();
                label9.Text = dr["fiyat"].ToString() + "₺";
                label8.Text = dr["ekstra"].ToString();

                if (Convert.ToInt32(dr["tamir_etme"]) == 1)
                {
                    label7.Text = "Hazır.";
                    label7.ForeColor = Color.Green;
                }
                else
                {
                    label7.Text = "Hazır Değil.";
                    label7.ForeColor = Color.Red;
                }

                richTextBox1.Text = dr["iade_sebebi"].ToString();
            }
            else
            {
                MessageBox.Show("Bu Numaraya Kayıtlı Cihaz Bulunamadı !", "Uyarı ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string telno = textBox4.Text;
            if (con.State == ConnectionState.Closed)
                con.Open();
            DateTime suan = DateTime.Now;
            cmd = new SqlCommand("UPDATE teslimalma set teslim_etme = '" + 1 + "',teslim_tarih= '"+ suan +"'  WHERE telno =  " + telno, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ürün Başarıyla Teslim Edildi ! ", " Başarılı !", MessageBoxButtons.OK);
            this.Close();

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
