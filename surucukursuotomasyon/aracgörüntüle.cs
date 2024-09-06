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
    public partial class aracgörüntüle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public aracgörüntüle()
        {
            InitializeComponent();
        }
        private void aracgörüntüle_Load(object sender, EventArgs e)
        {
            kayit_goster();
        }
        DataSet daset = new DataSet();
        private void kayit_goster()
        {
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Arac_bilgi", baglan);
            adtr.Fill(daset, "Arac_bilgi");
            dataGridView1.DataSource = daset.Tables["Arac_bilgi"];
            baglan.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from Arac_bilgi where arac_no='" + dataGridView1.CurrentRow.Cells["arac_no"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Arac_bilgi"].Clear();
            kayit_goster();
            MessageBox.Show("Kayıt Silindi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Arac_bilgi where arac_no like'%" + textBox1.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
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
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Arac_bilgi where arac_no like '" + textBox2.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox3.Text = read["marka"].ToString();
                textBox4.Text = read["model"].ToString();
                textBox5.Text = read["renk"].ToString();
                textBox6.Text = read["hp"].ToString();
                textBox7.Text = read["km"].ToString();
                textBox8.Text = read["aktiflik"].ToString();
                textBox9.Text = read["vites_sekli"].ToString();
                textBox10.Text = read["cinsi"].ToString();
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Arac_bilgi set arac_no=@arac_no,marka=@marka,model=@model,renk=@renk,hp=@hp,km=@km,aktiflik=@aktiflik,vites_sekli=@vites_sekli,cinsi=@cinsi where arac_no=@arac_no", baglan);
            komut.Parameters.AddWithValue("@arac_no", textBox2.Text);
            komut.Parameters.AddWithValue("@marka", textBox3.Text);
            komut.Parameters.AddWithValue("@model", textBox4.Text);
            komut.Parameters.AddWithValue("@renk", textBox5.Text);
            komut.Parameters.AddWithValue("@hp", textBox6.Text);
            komut.Parameters.AddWithValue("@km", textBox7.Text);
            komut.Parameters.AddWithValue("@aktiflik", textBox8.Text);
            komut.Parameters.AddWithValue("@vites_sekli", textBox9.Text);
            komut.Parameters.AddWithValue("@cinsi", textBox10.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Arac_bilgi"].Clear();
            kayit_goster();
            MessageBox.Show("Araç Kaydı Güncellendi");
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
            textBox10.Text = " ";
        }
    }
}
