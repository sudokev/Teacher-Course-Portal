using Microsoft.VisualBasic;
using StudentAssmentProgram.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class Curriculum : Form
    {
        public Curriculum()
        {
            InitializeComponent();
            DisplayTable();
        }

        //Brings user to Home Screen
        private void HomeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        //Logs the user out
        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Closes program if X is clicked on form
        private void Curriculum_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Sets a new goal for a specified week
        private void editCirriculumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var weekNum = 0;
            string weekGoals = null;

            //Gets week number from user and checks if it is valid
            //Week number cant be 0 or less
            //Week number cant be greater than 15 because there are only 15 weeks in a semester
            try
            {
                weekNum = int.Parse(Interaction.InputBox("Enter a week number between 1 and 15 to edit", "EnterGoals"));

                if (weekNum <= 0 || weekNum > 15)
                {
                    MessageBox.Show("Invalid week number!");
                    return;
                }

                //Gets new goal for specified week
                weekGoals = Interaction.InputBox("Enter a goal", "Enter Goals");

                //Week goal cannot be 256 or more chars. that is the limit of the database
                if (weekGoals.Length >= 256)
                {
                    MessageBox.Show("Cannot be longer than 256 characters!");
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Invalid week number!");
                return;
            }

            //Updates the table with new week goal
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = $"UPDATE Class SET Week_Goals = '{weekGoals}' WHERE Week_Number = {weekNum}";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteReader();
            }
            //Displays new information onto the GUI
            DisplayTable();
        }

        //Help messagebox
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit the Currciulum to add a certain goal for a specified week.", "Help");
        }

        //Resets all goals back to default value
        private void resetCurriculumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
            ("Are you sure you want to reset the curriculum?\nThis cannot be undone!",
            "Reset Curriculum", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string query = "UPDATE Class SET Week_Goals = '<ENTER WEEK GOALS>';";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            //Displays new information onto the GUI
            DisplayTable();
        }

        //Displays the current table information on the data grid on the GUI
        public void DisplayTable()
        {
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Class.Week_Number, Class.Week_Goals FROM Class";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}