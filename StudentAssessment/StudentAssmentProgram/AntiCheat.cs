using Microsoft.VisualBasic;
using StudentAssmentProgram.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class AntiCheat : Form
    {
        public AntiCheat()
        {
            InitializeComponent();
            DisplayTable();
        }

        //Closes the program if X is clicked on the form
        private void AntiCheat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Brings the user to the home screen
        private void homeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        //Logs the user out
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Checks for a spike in a specified users' grades
        private void checkForSpikeInGradesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            int studentID = 0;
            int exists = 0;

            //Checks if the specified user exists in the table
            try
            {
                studentID = int.Parse(Interaction.InputBox("Enter a Student ID", "Check for Spike in Grades"));

                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string existsQuery = $"SELECT COUNT(*) FROM Student WHERE Student_ID IN ({studentID})";
                    SqlCommand command = new SqlCommand(existsQuery, connection);
                    connection.Open();

                    using (var sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            //Gets number of rows where the student ID exists
                            exists = sqlDataReader.GetInt32(0);
                        }
                    }
                }

                if (exists == 0)
                {
                    //If exists = 0 then no rows have that student ID so it doesnt exist
                    MessageBox.Show("Student ID does not exist!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid ID!");
                return;
            }

            //Gets all the information including grades of the specified student
            List<GradesObject> studentList = GetGradesObject(studentID);
            double divideBy = 0;
            double studentTotal = 0;

            //This part is not very efficient but gets the job done
            //Could not find out how to do it better :(
            //Checks each grade to make sure it is a number and not "N/A"
            //If it is a number add it to the total and add one to the denominator
            foreach (var student in studentList)
            {
                int currentNumber = 0;
                bool test1Success = Int32.TryParse(student.Test1, out currentNumber);
                if (test1Success == true)
                {
                    studentTotal += currentNumber;
                    divideBy++;
                }
                bool test2Success = Int32.TryParse(student.Test2, out currentNumber);
                if (test2Success == true)
                {
                    studentTotal += currentNumber;
                    divideBy++;
                }
                bool quiz1Success = Int32.TryParse(student.Quiz1, out currentNumber);
                if (quiz1Success == true)
                {
                    studentTotal += currentNumber;
                    divideBy++;
                }
                bool quiz2Success = Int32.TryParse(student.Quiz2, out currentNumber);
                if (quiz2Success == true)
                {
                    studentTotal += currentNumber;
                    divideBy++;
                }
                bool finalSuccess = Int32.TryParse(student.Final, out currentNumber);
                if (finalSuccess == true)
                {
                    studentTotal += currentNumber;
                    divideBy++;
                }

                if (divideBy == 0)
                {
                    //If nothing in denominator then all grades are "N/A"
                    MessageBox.Show("No Grades to Average!");
                    return;
                }
                //Checks if grade is a number and if it is 20pts greater than average
                //If it is then they may have cheated and add the output to the StringBuilder
                else
                {
                    int average = Convert.ToInt32(studentTotal / divideBy);
                    int cheatCount = 0;
                    StringBuilder output = new StringBuilder();
                    output.Append($"{student.First_Name} {student.Last_Name}");

                    if(test1Success && (int.Parse(student.Test1) - average > 20))
                    {
                        output.Append("\nMay have cheated on Test 1");
                        cheatCount++;
                    }
                    if (test2Success && (int.Parse(student.Test2) - average > 20))
                    {
                        output.Append("\nMay have cheated on Test 2");
                        cheatCount++;
                    }
                    if (quiz1Success && (int.Parse(student.Quiz1) - average > 20))
                    {
                        output.Append("\nMay have cheated on Quiz 1");
                        cheatCount++;
                    }
                    if (quiz2Success && (int.Parse(student.Quiz2) - average > 20))
                    {
                        output.Append("\nMay have cheated on Quiz 2");
                        cheatCount++;
                    }
                    if (finalSuccess && (int.Parse(student.Final) - average > 20))
                    {
                        output.Append("\nMay have cheated on the Final");
                        cheatCount++;
                    }

                    if (cheatCount == 0)
                    {
                        MessageBox.Show("No spike in grades detected!");
                    }
                    else
                    {
                        MessageBox.Show(output.ToString());
                        MessageBox.Show($"Please contact {student.First_Name} {student.Last_Name} to confirm!");
                    }
                }
            }
        }
        
        //Gets all information for the student and returns it in a list
        public List<GradesObject> GetGradesObject(int studentID)
        {
            var gradesList = new List<GradesObject>();

            //Queries all information into a student object and adds it to the list
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Student.Student_ID, Student.First_Name, Student.Last_Name, Grades.Test1, " +
                               "Grades.Test2, Grades.Quiz1, Grades.Quiz2, Grades.Final " +
                               "FROM Student " +
                               "INNER JOIN Grades " +
                               "ON Student.Student_ID = Grades.Student_ID " +
                               $"WHERE Student.Student_ID = {studentID}";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (var sqlDataReader = command.ExecuteReader())
                {
                    do
                    {
                        while (sqlDataReader.Read())
                        {
                            //Each parameter (x) corresponds to the columns returned in the query result
                            var grades = new GradesObject();
                            grades.Student_ID = sqlDataReader.GetInt32(0);
                            grades.First_Name = sqlDataReader.GetString(1);
                            grades.Last_Name = sqlDataReader.GetString(2);
                            grades.Test1 = sqlDataReader.GetString(3);
                            grades.Test2 = sqlDataReader.GetString(4);
                            grades.Quiz1 = sqlDataReader.GetString(5);
                            grades.Quiz2 = sqlDataReader.GetString(6);
                            grades.Final = sqlDataReader.GetString(7);
                            gradesList.Add(grades);
                        }
                    }
                    while (sqlDataReader.NextResult());
                }
            }
            return gradesList;
        }

        //Displays the specified columns into the data grid on the GUI
        public void DisplayTable()
        {
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT * FROM Student";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        //Help messagebox
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select 'Check for Spike in Grades'\n" +
                            "to check if someone may have cheated on an exam!\n" +
                            "The program will compare each exam to their average\n" +
                            "and if it is significantly higher, the program will\n" +
                            "let you know which exams the student may have cheated on.",
                            "Help");
        }
    }
}