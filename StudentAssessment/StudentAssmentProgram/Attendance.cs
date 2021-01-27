using Microsoft.VisualBasic;
using StudentAssmentProgram.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            DisplayTable();
        }

        //Brings user to home screen
        private void HomeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        //Logs user out
        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Closes form when X is clicked on the form
        private void Attendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Takes attendance for the entire class
        private void TakeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //list of objects that contains Attendance objects
            var attendanceObjects = new List<AttendanceObject>();

            string query = "SELECT Attendance.Student_ID, Student.First_Name, Student.Last_Name, " +
            "Attendance.Record, Attendance.Total_Classes, Attendance.Percentage " +
            "FROM Attendance " +
            "INNER JOIN Student " +
            "ON Attendance.Student_ID = Student.Student_ID " +
            "ORDER BY Attendance.Student_ID";

            //Returns a list of objects with all of the students information and stores it in attendanceObjects list
            attendanceObjects = GetAttendanceObjectList(query);

            //Prompts the user if the student is present or not
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                //Loops through entire list (one prompt for each student)
                foreach (var currentStudent in attendanceObjects)
                {
                    DialogResult dialogResult = MessageBox.Show
                        ($"Is {currentStudent.First_Name} {currentStudent.Last_Name} present?",
                        "Taking Attendance", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        //If yes add one to their record and total class count
                        currentStudent.Record++;
                        currentStudent.Total_Classes++;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //If no just add one to their total class count to help calculate percenatge time being present
                        currentStudent.Total_Classes++;
                    }

                    //Calculates percentage of attendance
                    currentStudent.Percentage = ((double)(currentStudent.Record) / (double)(currentStudent.Total_Classes)) * 100;
                    currentStudent.Percentage = Math.Round(currentStudent.Percentage, 2);

                    //Queries new attendance information into the table
                    string updateQuery =
                    $"UPDATE Attendance SET Record = {currentStudent.Record} WHERE Student_ID = {currentStudent.Student_ID};" +
                    $"UPDATE Attendance SET Total_Classes = {currentStudent.Total_Classes} WHERE Student_ID = {currentStudent.Student_ID};" +
                    $"UPDATE Attendance SET Percentage = {currentStudent.Percentage} WHERE Student_ID = {currentStudent.Student_ID};";

                    SqlCommand command2 = new SqlCommand(updateQuery, connection);
                    connection.Open();
                    command2.ExecuteReader();
                    connection.Close();
                }
            }
            //Display the updated table onto the form
            DisplayTable();
        }

        //Edits a specific students attendance record
        private void EditAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int studentID = 0;
            int newRecord = 0;
            int exists = 0;

            //Gets student ID from user and checks if it exists
            try
            {
                studentID = int.Parse(Interaction.InputBox("Enter the student ID whose record you want to change:"
                    , "Edit Attendance"));

                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string existsQuery = $"SELECT COUNT(*) FROM Attendance WHERE Student_ID IN ({studentID})";
                    SqlCommand command = new SqlCommand(existsQuery, connection);
                    connection.Open();

                    using (var sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            //Gets number of rows that have that student ID
                            exists = sqlDataReader.GetInt32(0);
                        }
                    }
                }

                if (exists == 0)
                {
                    //If exists is = 0 then there are no rows with that ID and it doesn't exist
                    MessageBox.Show("Student ID does not exist!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid ID!");
                return;
            }

            string query = "SELECT Attendance.Student_ID, Student.First_Name, Student.Last_Name, " +
            "Attendance.Record, Attendance.Total_Classes, Attendance.Percentage " +
            "FROM Attendance " +
            "INNER JOIN Student " +
            "ON Attendance.Student_ID = Student.Student_ID " +
            $"WHERE Attendance.Student_ID = {studentID}";

            //List of object that will contain one object in this instance because there will be only one student
            //GetAttenanceObjectList will gather all information related to the specified student
            List<AttendanceObject> student = GetAttendanceObjectList(query);

            //Gets the new attendance record we want to replace with the old one
            try
            {
                newRecord = int.Parse(Interaction.InputBox("Enter the new record:", "Edit Attendance"));
                if (newRecord < 0 || newRecord > student[0].Total_Classes)
                {
                    //Student's attendance record cannot be less than zero, or greater than total classes that have occurred
                    MessageBox.Show("Invalid Record:\nNew record cannot be less than zero!\n" +
                        "New record cannot be greater than the total classes!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Record!");
                return;
            }

            //Updates new records and percentage into the table
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                student[0].Percentage = ((double)(newRecord) / (double)(student[0].Total_Classes)) * 100;
                student[0].Percentage = Math.Round(student[0].Percentage, 2);
                string updateQuery = $"UPDATE Attendance SET Record = {newRecord} WHERE Student_ID = {studentID};" +
                                     $"UPDATE Attendance SET Percentage = {student[0].Percentage} WHERE Student_ID = {studentID}";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
            MessageBox.Show("Attendance Updated!");
            //Shows new information on the GUI
            DisplayTable();
        }

        //Resets all student's attendance to 0
        private void ResetAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
                ("Are you sure you want to reset the attendance records?\nThis cannot be undone!",
                "Reset Attendance", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Queries 0s into all columns in Attendance table
                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string query = "UPDATE Attendance SET Record = 0;" +
                                   "UPDATE Attendance SET Total_Classes = 0;" +
                                   "UPDATE Attendance SET Percentage = 0;";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            //Displays new information onto the GUI
            DisplayTable();
        }

        //Information messagebox
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use Take Attendance to take attendance for all students.\n" +
                            "Use Edit Attendance to change a specific students' attendance record.\n" +
                            "Use Reset attendance to reset all records back to zero.", "Help");
        }

        //Method that returns a list of each students information
        public List<AttendanceObject> GetAttendanceObjectList(string query)
        {
            var attendanceObjects = new List<AttendanceObject>();

            //Queries all information into the object and adds the object into the list
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (var sqlDataReader = command.ExecuteReader())
                {
                    do
                    {
                        while (sqlDataReader.Read())
                        {
                            //Parameters (x) represent the columns returned by the query
                            var attendance = new AttendanceObject();
                            attendance.Student_ID = sqlDataReader.GetInt32(0);
                            attendance.First_Name = sqlDataReader.GetString(1);
                            attendance.Last_Name = sqlDataReader.GetString(2);
                            attendance.Record = sqlDataReader.GetInt32(3);
                            attendance.Total_Classes = sqlDataReader.GetInt32(4);
                            attendance.Percentage = sqlDataReader.GetDouble(5);
                            attendanceObjects.Add(attendance);
                        }
                    }
                    //Keeps reading until there are no rows left to read
                    while (sqlDataReader.NextResult());
                }
                connection.Close();
            }
            //Returns the list of all students and their information
            return attendanceObjects;
        }

        //Displays the specified columns onto the data grid on the GUI
        public void DisplayTable()
        {
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Attendance.Student_ID, Student.First_Name, Student.Last_Name, " +
                               "Attendance.Record, Attendance.Total_Classes, Attendance.Percentage " +
                               "FROM Attendance " +
                               "INNER JOIN Student " +
                               "ON Attendance.Student_ID = Student.Student_ID " +
                               "ORDER BY Attendance.Student_ID";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}