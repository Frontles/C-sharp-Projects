﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source= .\\SQLEXPRESS; Initial Catalog=servis ; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2= new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad, telno, marka, ekstra,ariza;
            ad = textBox1.Text;
            telno = textBox2.Text;
            marka = textBox3.Text;
            ekstra = textBox4.Text;
            ariza = richTextBox1.Text;

            if (con.State == ConnectionState.Closed)
                con.Open();
            cmd = new SqlCommand("insert into  teslimalma (ad,telno,marka,ekstra,ariza,tamir_etme,teslim_etme) values (@ad,@telno,@marka,@ekstra,@ariza,@tamir_etme,@teslim_etme) ", con);
            cmd.Parameters.AddWithValue("@ad", ad);
            cmd.Parameters.AddWithValue("@telno", telno);
            cmd.Parameters.AddWithValue("@marka", marka);
            cmd.Parameters.AddWithValue("@ekstra", ekstra);
            cmd.Parameters.AddWithValue("@ariza", ariza);
            cmd.Parameters.AddWithValue("@tamir_etme", 0);
            cmd.Parameters.AddWithValue("@teslim_etme", 0);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ürün Başarıyla Eklendi ! ", " Başarılı !", MessageBoxButtons.OK);  

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
