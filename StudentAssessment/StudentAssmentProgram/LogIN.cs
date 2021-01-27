using StudentAssmentProgram.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        //Closes the program when the X is clicked on the form
        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Closes the program when exit button is pressed
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Checks for valid credentials and either allows the user access or not
        private void Button_LogIn_Click(object sender, EventArgs e)
        {
            string teacherID = textBox1.Text;
            string teacherPassword = textBox2.Text;
            int exists = 0;

            try
            {
                //Checks if what the user entered is in the table
                //It checks if there is a row that exists with the inputted user and pass
                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string query = $"SELECT COUNT(*) FROM Teacher WHERE (Teacher_ID IN ({teacherID})) " +
                                   $"AND (Teacher_Password IN ('{teacherPassword}'))";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (var sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            //gets the number of rows that match the inputted user and pass
                            exists = sqlDataReader.GetInt32(0);
                        }
                    }
                }

                //If the amount of rows exist are 0 then the credentials are invalid
                if (exists == 0)
                {
                    MessageBox.Show("Invalid Credentials!");
                    return;
                }
                else
                {
                    //Otherwise bring them to the home page
                    this.Hide();
                    HomePage homePage = new HomePage();
                    homePage.Show();
                }
            }
            catch
            {
                MessageBox.Show("Invalid Credentials!");
                return;
            }
        }

        //Information messagebox
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Student Assessment Program!\n" +
                "This program will allow you to manage your class in many ways.\n" +
                "You will be able to take attendance,\n" +
                "manage your students' grades, check for cheating,\n" +
                "and also update and keep track of the curriculum.", "Help");
        }
    }
}