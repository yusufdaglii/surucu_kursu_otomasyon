using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surucukursuotomasyon
{
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void deneme_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Toptan Alış");
            comboBox3.Items.Add("Perakende Alış");
            comboBox3.Items.Add("Müşteri");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
