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
    public partial class adaygörüntüle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public adaygörüntüle()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        private void adaygörüntüle_Load(object sender, EventArgs e)
        {
            kayit_goster();
        }

        private void kayit_goster()
        {
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Surucu_kayitt", baglan);
            adtr.Fill(daset,"Surucu_kayitt");
            dataGridView1.DataSource = daset.Tables["Surucu_kayitt"];
            baglan.Close();
        }
       
        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from Surucu_kayitt where adayno='" + dataGridView1.CurrentRow.Cells["adayno"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Surucu_kayitt"].Clear();
            kayit_goster();
            MessageBox.Show("Kayıt Silindi");
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Surucu_kayitt where adayno like'%" + textBox1.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Surucu_kayitt set adayno=@adayno,TC=@TC,AD=@AD,SOYAD=@SOYAD,TELEFON=@TELEFON,ŞİFRE=@ŞİFRE where adayno=@adayno", baglan);
            komut.Parameters.AddWithValue("@adayno", textBox2.Text);
            komut.Parameters.AddWithValue("@TC", textBox3.Text);
            komut.Parameters.AddWithValue("@AD", textBox4.Text);
            komut.Parameters.AddWithValue("@SOYAD", textBox5.Text);
            komut.Parameters.AddWithValue("@TELEFON", textBox6.Text);
            komut.Parameters.AddWithValue("@ŞİFRE", textBox7.Text);           
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Surucu_kayitt"].Clear();
            kayit_goster();
            MessageBox.Show("Aday Kaydı Güncellendi");
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Surucu_kayitt where adayno like '" + textBox2.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox3.Text = read["TC"].ToString();
                textBox4.Text = read["AD"].ToString();
                textBox5.Text = read["SOYAD"].ToString();
                textBox6.Text = read["TELEFON"].ToString();
                textBox7.Text = read["ŞİFRE"].ToString();
            }
            baglan.Close();
        }
    }
}
