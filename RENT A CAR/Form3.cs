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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-TIME78H\\MYSQL;Initial Catalog=RentCar;Integrated Security=True");


        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            groupBox1.Visible = false;
            dataGridView2.Visible = false;
        }

        private void cUSTOMERINFORMATİONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                da = new SqlDataAdapter("Select * from CustomerInformation", connection);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
                connection.Close();


            }
            catch (Exception fail)
            {
                MessageBox.Show("Problem is occured" + fail.Message);
            }

        }

        private void nEWPERSONELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            groupBox1.Visible = true;
            dataGridView2.Visible = false;
            Random random = new Random();
            int ID = random.Next(1000, 100000);
            textBox1.Text = ID.ToString();
            textBox1.Enabled = false;
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void sTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            groupBox1.Visible = false; ;
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                da = new SqlDataAdapter("Select * from Car", connection);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView2.DataSource = table;
                connection.Close();


            }
            catch (Exception fail)
            {
                MessageBox.Show("Problem is occured" + fail.Message);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            String newUser = "insert into PersonelLogin (ID,Password,Mail) Values (@ID,@Password,@Mail)";
            SqlCommand command = new SqlCommand(newUser, connection);
            command.Parameters.AddWithValue("@ID", textBox1.Text);
            command.Parameters.AddWithValue("@Password", textBox2.Text);
            command.Parameters.AddWithValue("@Mail", textBox3.Text);

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("User has been added");
        }
    }
}
