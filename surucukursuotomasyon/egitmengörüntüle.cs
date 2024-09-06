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
    public partial class egitmengörüntüle : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public egitmengörüntüle()
        {
            InitializeComponent();
        } 
        private void egitmengörüntüle_Load(object sender, EventArgs e)
        {
            kayit_goster();
            kayit_goster2();
        }
        DataSet daset = new DataSet();
        private void kayit_goster()
        {
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Egitmen", baglan);
            adtr.Fill(daset, "Egitmen");
            dataGridView1.DataSource = daset.Tables["Egitmen"];
            baglan.Close();
        }
        private void kayit_goster2()
        {
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from Egitmen_ikamet", baglan);
            adtr.Fill(daset, "Egitmen_ikamet");
            dataGridView2.DataSource = daset.Tables["Egitmen_ikamet"];
            baglan.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from Egitmen where TC='" + dataGridView1.CurrentRow.Cells["TC"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Egitmen"].Clear();
            kayit_goster();
            MessageBox.Show("Kayıt Silindi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from Egitmen_ikamet where TC='" + dataGridView2.CurrentRow.Cells["TC"].Value.ToString() + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            daset.Tables["Egitmen_ikamet"].Clear();
            kayit_goster2();
            MessageBox.Show("Kayıt Silindi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Egitmen where TC like'%" + textBox1.Text + "%'", baglan);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
    }
}
