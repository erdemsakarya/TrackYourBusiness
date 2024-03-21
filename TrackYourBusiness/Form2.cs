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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrackYourBusiness
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = ERDEM\SQLEXPRESS; Initial Catalog = tyb; Integrated Security = True;");
        private readonly Form _form;
        public Form2(Form form)
        {
            _form = form;
            InitializeComponent();
        }
        string tabloAdi;
        private void registerButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("@gmail.com") == false || textBox1.TextLength < 14)
            {
                MessageBox.Show("Mail adresinizi lütfen doğru giriniz, birtek gmail desteklenmektedir.");
            }
            if (txtUserName.TextLength < 4)
            {
                MessageBox.Show("Kullanıcı adınız 4 harften kısa olmamalıdır.");
            }
            if (txtPassword.TextLength < 4)
            {
                MessageBox.Show("Şifreniz çok kısa, daha güçlü bir şifre belirleyin!");
            }

            if (txtUserName.TextLength > 3 && txtPassword.TextLength > 3 && textBox1.TextLength > 13 && textBox1.Text.Contains("@gmail.com") == true)
            {
                tabloAdi = Convert.ToString(txtUserName.Text);
                SqlCommand command = new SqlCommand("Create Table " + tabloAdi + "(id int identity(1,1) not null,satisTarihi nvarchar(50) not null, urunAdi nvarchar(50) not null, urunAdeti int not null, taneFiyati int not null)", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                command.Dispose();

                string addUser = "INSERT INTO userData (id,gmail,username,password) VALUES (@id,@gmail,@username,@password)";
                SqlCommand command2 = new SqlCommand(addUser, con);
                command2.Parameters.AddWithValue("@id", 0);
                command2.Parameters.AddWithValue("@gmail", textBox1.Text);
                command2.Parameters.AddWithValue("@username", txtUserName.Text);
                command2.Parameters.AddWithValue("@password", txtPassword.Text);
                con.Open();
                command2.ExecuteNonQuery();
                con.Close();
                _form.Show();
                this.Hide();
                Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
