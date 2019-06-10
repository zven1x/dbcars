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

namespace dbtestconnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\jaszuk\lol\DBcars\DBcars\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Select * From [rentcar] ", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "        " + Convert.ToString(sqlReader["Nazwa"]) + "        " + Convert.ToString(sqlReader["Model"]) + "        " + Convert.ToString(sqlReader["Cena"]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();

            }

        }


        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            {
                Dispose();
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label9.Visible)
                label9.Visible = false;


            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
            !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
            !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [rentcar] (Nazwa, Model, Cena)VALUES(@Nazwa, @Model, @Cena)", sqlConnection);

                command.Parameters.AddWithValue("Nazwa", textBox1.Text);

                command.Parameters.AddWithValue("Model", textBox2.Text);

                command.Parameters.AddWithValue("Cena", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;

                label9.Text = "Dane w polach 'Nazwa', 'Model', ' Cena'maja byc wypełnione";

            }
        }
        private async void uaktualizowacToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();


            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("Select * From [rentcar] ", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "        " + Convert.ToString(sqlReader["Nazwa"]) + "  " +
                        "      " + Convert.ToString(sqlReader["Model"]) + "        " + Convert.ToString(sqlReader["Cena"]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }
        private async void button2_Click(object sender, EventArgs e)
        {

            if (label10.Visible)
                label10.Visible = false;


            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
            !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
            !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
            !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))

            {
                SqlCommand command = new SqlCommand("UPDATE [rentcar] SET [Nazwa]=@Nazwa,[Model]=@Model, [Cena]=@Cena WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox7.Text);
                command.Parameters.AddWithValue("Nazwa", textBox6.Text);
                command.Parameters.AddWithValue("Model", textBox5.Text);
                command.Parameters.AddWithValue("Cena", textBox4.Text);

                await command.ExecuteNonQueryAsync();
            }



            else if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                label10.Visible = true;

                label10.Text = "Dane w polach 'Nazwa', 'Model', ' Cena'maja byc wypełnione!";
            }
            else
            {
                label10.Visible = true;
                label10.Text = "ID nie moze byc pusty!!!";

            }


        }







    }

}