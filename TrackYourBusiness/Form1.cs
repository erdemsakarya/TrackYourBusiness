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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TrackYourBusiness
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = ERDEM\SQLEXPRESS; Initial Catalog = tyb; Integrated Security = True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2(this).Show();
            this.Hide();
        }
    }
}
