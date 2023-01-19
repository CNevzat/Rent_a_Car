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


namespace RENT_A_CAR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TIME78H\\MYSQL;Initial Catalog=RentCar;Integrated Security=True");
        SqlCommand command;
        SqlDataReader dr;
       

        private void label3_Click(object sender, EventArgs e)
        {

            try
            {
              

                string ID = textBox1.Text;
                string Password = textBox2.Text;
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Select * from PersonelLogin where ID='" + textBox1.Text +
                    "' AND Password='" + textBox2.Text + "'";
                connection.Open();
                dr = command.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Login successful.You're being redirected to the system.");


                    Form3 frm3 = new Form3();
                    this.Hide();
                    frm3.Show();
                }
            }
            catch (Exception)

            {
                MessageBox.Show("Username or Password is wrong");
                connection.Close();
            }

            

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            textBox2.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
