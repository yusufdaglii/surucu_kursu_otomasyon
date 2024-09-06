using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surucukursuotomasyon
{
    public partial class adaygirissifre : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");

        public adaygirissifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Bırakılan Yerleri doldurun.");
            }
            else if (true)
            {
                aday_panel ekle = new aday_panel();
                Visible = false;
                ekle.ShowDialog();
                this.Show();
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Surucu_kayitt where adayno like '" + textBox1.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["adayno"].ToString();
                textBox2.Text = read["ŞİFRE"].ToString();
            }
            baglan.Close();

        }
    }
}
