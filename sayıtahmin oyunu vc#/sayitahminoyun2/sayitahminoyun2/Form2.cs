using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace sayitahminoyun2
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=sayitahmin ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form2()
        {
            InitializeComponent();
        }

        int sayac = 0;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show(" 1. Seviyede , 0-10 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                //int tutulansayi = randomsayi(10);
                int tutulansayi = 0;
                label2.Text = " Bu Seviyede , 0-10 sayıları arasında tahmin yapınız ! ";
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 1";
               
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                
                pictureBox9.ImageLocation = "9.jpg";
                pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 2. Seviyede , 0-50 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                //int tutulansayi = randomsayi(50);
                int tutulansayi = 0;
                label2.Text = " Bu Seviyede , 0-50 sayıları arasında tahmin yapınız ! ";
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 2";
                
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                pictureBox1.ImageLocation = "1.jpg";
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 3. Seviyede , 0-250 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                //int tutulansayi = randomsayi(250);
                int tutulansayi = 0;
                label2.Text = " Bu Seviyede , 0-250 sayıları arasında tahmin yapınız ! ";
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 3";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                
                pictureBox3.ImageLocation = "3.jpg";
                pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 4. Seviyede , 0-1000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                label2.Text = " Bu Seviyede , 0-1.000 sayıları arasında tahmin yapınız ! ";
                //int tutulansayi = randomsayi(1000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 4";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                pictureBox7.ImageLocation = "7.jpg";
                pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 5. Seviyede , 0-2000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                label2.Text = " Bu Seviyede , 0-2.000 sayıları arasında tahmin yapınız ! ";
                //int tutulansayi = randomsayi(2000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 5";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                pictureBox2.ImageLocation = "2.jpg";
                pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 6. Seviyede , 0-5000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                label2.Text = " Bu Seviyede , 0-5.000 sayıları arasında tahmin yapınız ! ";
                //int tutulansayi = randomsayi(5000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 6";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                pictureBox5.ImageLocation = "5.jpg";
                pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 7. Seviyede , 0-10000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                label2.Text = " Bu Seviyede , 0-1.0000 sayıları arasında tahmin yapınız ! ";
                //int tutulansayi = randomsayi(10000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 7";
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                pictureBox4.ImageLocation = "4.jpg";
                pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                MessageBox.Show(" 8. Seviyede , 0-50000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
                label2.Text = " Bu Seviyede , 0-50.000 sayıları arasında tahmin yapınız ! ";
                //int tutulansayi = randomsayi(50000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 8";
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                pictureBox8.ImageLocation = "8.jpg";
                pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                label2.Text = " Bu Seviyede , 0-100.000 sayıları arasında tahmin yapınız ! ";
                MessageBox.Show(" Son Seviyede , 0-100000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");

                //int tutulansayi = randomsayi(100000);
                int tutulansayi = 0;
                label3.Text = "" + tutulansayi;
                label4.Text = "Seviye 9";
            }

            if (comboBox1.SelectedIndex != 0)
            {
                button5.Visible = false;
                button1.Enabled = true;
                textBox1.Enabled = true;
            }

        }


        public static int randomsayi(int sondeger)
        {
            Random rastgelesayi = new Random();

            int sonuc = rastgelesayi.Next(0, sondeger);

            return sonuc;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex <= 8)
                comboBox1.SelectedIndex++;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tutulansayi = Convert.ToInt32(label3.Text);
            int tahmin = Convert.ToInt32(textBox1.Text);
            
            sayac++;

            
            if (comboBox1.SelectedIndex == 0 && tahmin > 10 )
                MessageBox.Show(" 1. Seviyede , 0-10 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 1 && tahmin > 50 )
                MessageBox.Show(" 2. Seviyede , 0-50 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 2 && tahmin > 250 )
                MessageBox.Show(" 3. Seviyede , 0-250 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 3 && tahmin > 1000 )
                MessageBox.Show(" 4. Seviyede , 0- 1000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 4 && tahmin > 2000 )
                MessageBox.Show(" 5. Seviyede , 0-2000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 5 && tahmin > 5000 )
                MessageBox.Show(" 6. Seviyede , 0-5000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 6 && tahmin > 10000 )
                MessageBox.Show(" 7. Seviyede , 0-10000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 7 && tahmin > 50000 )
                MessageBox.Show(" 8. Seviyede , 0-50000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (comboBox1.SelectedIndex == 8 && tahmin > 100000 )
                MessageBox.Show(" son Seviyede , 0-100000 sayıları arasında tahmin yapınız ! ", "Bilgilendirme ");
            else if (tahmin > tutulansayi)
                MessageBox.Show("Tahmininiz, tutulan sayıdan daha büyük. Lütfen Daha küçük bir değer giriniz ! ", "Yanlış Tahmin");
            else if (tahmin < tutulansayi)
                MessageBox.Show("Tahmininiz, tutulan sayıdan daha küçük. Lütfen Daha büyük bir değer giriniz !", "Yanlış Tahmin");

            if (tahmin == tutulansayi)
            {

                if (comboBox1.SelectedIndex < 8)
                {
                    
                    MessageBox.Show("Tahmininiz doğru !  Sonraki Seviyeye geçtiniz !. \n Toplam tahmin sayınız : " + sayac, "Tebrikler !");
                    button5.Visible = true;
                }


                else if (comboBox1.SelectedIndex == 8)
                {
                    pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pictureBox6.ImageLocation = "6.jpg";
                    MessageBox.Show(" Oyun Bitti !  \n Toplam tahmin sayınız : " + sayac, "Tebrikler !");
                    button4.Visible = true;
                    string oyuncuadi = Microsoft.VisualBasic.Interaction.InputBox("Adınızı Giriniz :", "Bilgi Girişi", "Örn: Ali", 0, 0);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd = new SqlCommand("insert into  sayitahmin (Isim,skor) values (@Isim,@skor) ", con);
                    cmd.Parameters.AddWithValue("@Isim", oyuncuadi);
                    cmd.Parameters.AddWithValue("@skor",sayac);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    

                }
                button1.Enabled = false;
                textBox1.Enabled = false;
            }
            textBox1.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                errorProvider1.SetError(textBox1, "Lütfen tahmin değerinizi giriniz !");
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                errorProvider1.Clear();
            }
        }
        private void textBox1_KeyPress(object sender , KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
