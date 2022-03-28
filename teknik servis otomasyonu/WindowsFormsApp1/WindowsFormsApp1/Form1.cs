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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            string kadi, sifre;
            kadi = textBox1.Text;
            sifre = textBox2.Text;

            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() =="" )
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurunuz !", "HATA ! ",
                MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sql = "SELECT *  FROM  users WHERE kadi=@kadi AND sifre=@sifre ";
                SqlParameter prm1 = new SqlParameter("@kadi", textBox1.Text);
                SqlParameter prm2 = new SqlParameter("@sifre", textBox2.Text);
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("Hoşgeldiniz Sayın " + textBox1.Text,"Giriş Başarılı !", MessageBoxButtons.OK);
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Veritabanında Böyle Bir Kullanıcı Bulunamadı ! ");
                }
                
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
