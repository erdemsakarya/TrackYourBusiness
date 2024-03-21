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

namespace TrackYourBusiness
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = ERDEM\SQLEXPRESS; Initial Catalog = tyb; Integrated Security = True;");
        public Form3()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        void gridDoldur()
        {
            con.Open();
            da = new SqlDataAdapter("SELECT *FROM userData", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gridDoldur();
        }
    }
}
