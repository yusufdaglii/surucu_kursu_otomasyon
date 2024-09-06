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
    public partial class egitmengirissifre : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public egitmengirissifre()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Boş Bırakılan Yerleri doldurun.");
            }
            else if (true)
            {
                egitmen_panel ekle = new egitmen_panel();
                Visible = false;
                ekle.ShowDialog();
                this.Show();
            }
            textBox6.Text = "";
            textBox5.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Egitmen where TC like '" + textBox6.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox6.Text = read["TC"].ToString();
                textBox5.Text = read["ŞİFRE"].ToString();
            }
            baglan.Close();
        }
    }
}
