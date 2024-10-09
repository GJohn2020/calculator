using calculator.operation;
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
using System.Configuration;

namespace calculator
{
    public partial class Form1 : Form
    {
        SqlConnection con=new SqlConnection(@"Data Source=LAPTOP-ED8N8UHA\SQLEXPRESS;Initial Catalog=calculations;Integrated Security=True;TrustServerCertificate=True");
        Calculator calculator=new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
       //int num1, num2;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text+= button1.Text;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button14.Text;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button3.Text;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            calculator.SetFirstNumber(float.Parse(textBox1.Text));
            Button button = (Button)sender;

            // Get operation from factory
            calculator.SetOperation(operationFactory.GetOperation(button.Text));

            textBox1.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            calculator.SetFirstNumber(float.Parse(textBox1.Text));
            Button button = (Button)sender;

            // Get operation from factory
            calculator.SetOperation(operationFactory.GetOperation(button.Text));

            textBox1.Text = "";
        }
        //private void button8_Click(object sender, EventArgs e)
        //{
        //    num1 = int.Parse(textBox1.Text);
        //    textBox1.Text = "";
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }



        private void button12_Click(object sender, EventArgs e)
        {

            // Set the second number
            calculator.SetSecondNumber(float.Parse(textBox1.Text));

            // Perform the calculation and display the result
            double result = calculator.Calculate();
            textBox1.Text = result.ToString();


            // Result result = new Substract();

            //DB
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table_2 values('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

           // MessageBox.Show("successfully added into DB");

        }

        //Database
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table_2";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            textBox1.Text = dt.ToString();
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {

            disp_data();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table_2 where Result='"+ float.Parse(textBox1.Text)+ "'";

            cmd.ExecuteNonQuery();
    
            con.Close();
            disp_data();
            MessageBox.Show("DB has cleared");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update from Table_2 set Result='" + dataGridView1.DataSource + "'where name'"+textBox1.Text  + "'";

            cmd.ExecuteNonQuery();

            con.Close();
            disp_data();
            MessageBox.Show("DB has updated");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Table_2 where Result='"+textBox1.Text+"'";

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //textBox1.Text = dt.ToString();
            con.Close();
        }
    }
}


    //< connectionString >

    //    < add name = "connection_string"

    //         providerName = "System.Data.SqlClient"

    //         connectionString = "Data Source=LAPTOP-ED8N8UHA\SQLEXPRESS;Initial Catalog=calculations;Integrated Security=True;Trust Server Certificate=True" />

    //</ connectionString >