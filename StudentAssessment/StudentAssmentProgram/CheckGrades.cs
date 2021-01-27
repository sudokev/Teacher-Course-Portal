using Microsoft.VisualBasic;
using StudentAssmentProgram.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class CheckGrades : Form
    {
        public CheckGrades()
        {
            InitializeComponent();
            DisplayTable();
        }

        //Brings user back to home screen
        private void homeScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        //Logs the user out when clicked
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Closes the program when the X is clicked on the form
        private void CheckGrades_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Resets all students' grades to 0
        private void resetAllGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show
            ("Are you sure you want to reset all grades?\nThis cannot be undone!",
            "Reset Grades", MessageBoxButtons.YesNo);
            //If they clicked YES then query all 0s into each column of Grades table
            if (dialogResult == DialogResult.Yes)
            {
                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string query = "UPDATE Grades SET Test1 = 'N/A';" +
                                   "UPDATE Grades SET Test2 = 'N/A';" +
                                   "UPDATE Grades SET Quiz1 = 'N/A';" +
                                   "UPDATE Grades SET Quiz2 = 'N/A';" +
                                   "UPDATE Grades SET Final = 'N/A';";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            //Shows new updated information onto the GUI
            DisplayTable();
        }

        //Abstracted method that allows the user to enter all student's grades for Test1
        private void EnterAllGradesTest1_Click(object sender, EventArgs e)
        {
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGradesObject("Test1");
            if (gradesObjects == null)
            {
                return;
            }
            UpdateGrades(gradesObjects, "Test1");
            DisplayTable();
        }

        //Abstracted method that allows the user to enter all student's grades for Test2
        private void EnterAllGradesTest2_Click(object sender, EventArgs e)
        {
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGradesObject("Test2");
            //If returned null then the user entered incorrect info
            if (gradesObjects == null)
            {
                //Boots the user out of menu so they can try again
                return;
            }
            UpdateGrades(gradesObjects, "Test2");
            DisplayTable();
        }

        //Abstracted method that allows the user to enter all student's grades for Quiz1
        private void EnterAllGradesQuiz1_Click(object sender, EventArgs e)
        {
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGradesObject("Quiz1");
            //If returned null then the user entered incorrect info
            if (gradesObjects == null)
            {
                //Boots the user out of menu so they can try again
                return;
            }
            UpdateGrades(gradesObjects, "Quiz1");
            DisplayTable();
        }

        //Abstracted method that allows the user to enter all student's grades for Quiz2
        private void EnterAllGradesQuiz2_Click(object sender, EventArgs e)
        {
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGradesObject("Quiz2");
            //If returned null then the user entered incorrect info
            if (gradesObjects == null)
            {
                //Boots the user out of menu so they can try again
                return;
            }
            UpdateGrades(gradesObjects, "Quiz2");
            DisplayTable();
        }

        //Abstracted method that allows the user to enter all student's grades for Final Exam
        private void EnterAllGradesFinalExam_Click(object sender, EventArgs e)
        {
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGradesObject("Final");
            //If returned null then the user entered incorrect info
            if (gradesObjects == null)
            {
                //Boots the user out of menu so they can try again
                return;
            }
            UpdateGrades(gradesObjects, "Final");
            DisplayTable();
        }

        //Edits a specific students' grade for Test1
        private void EditStudentGradeTest1_Click(object sender, EventArgs e)
        {
            EditStudentGrade("Test1");
        }

        //Edit a specific students' grade for Test2
        private void EditStudentGradeTest2_Click_1(object sender, EventArgs e)
        {
            EditStudentGrade("Test2");
        }

        //Edit a specific grade for a student's quiz 1
        private void EditStudentGradeQuiz1_Click(object sender, EventArgs e)
        {
            EditStudentGrade("Quiz1");
        }

        //Edit a specifc grade for a student's quiz 2
        private void EditStudentScoreQuiz2_Click(object sender, EventArgs e)
        {
            EditStudentGrade("Quiz2");
        }

        //Edit a specifc grade for a student's final exam
        private void EditStudentGradesFinalExam_Click(object sender, EventArgs e)
        {
            EditStudentGrade("Final");
        }

        //Gets the average test score for Test1
        private void Test1AverageScore_Click(object sender, EventArgs e)
        {
            //List of gradesObjects that will be filled with every students exams score
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGrades();

            double divideBy = 0;
            double total = 0;

            //Loops through each student and adds all test1 scores up
            //If the grade is "N/A" it will not be counted
            foreach (var student in gradesObjects)
            {
                int currentNumber = 0;
                bool success = Int32.TryParse(student.Test1, out currentNumber);
                if (success == true)
                {
                    total += currentNumber;
                    divideBy++;
                }
            }
            if (divideBy == 0)
            {
                MessageBox.Show("No Grades to Average!");
                return;
            }
            else
            {
                double average = total / divideBy;
                MessageBox.Show($"The average grade for Test 1 is: {Math.Round(average, 2)}");
            }
        }

        //Gets the average test score for Test2
        private void Test2AverageScore_Click(object sender, EventArgs e)
        {
            //List of gradesObjects that will be filled with every students exams score
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGrades();
            ;
            double divideBy = 0;
            double total = 0;

            //Loops through each student and adds all test2 scores up
            //If the grade is "N/A" it will not be counted
            foreach (var student in gradesObjects)
            {
                int currentNumber = 0;
                bool success = Int32.TryParse(student.Test2, out currentNumber);
                if (success == true)
                {
                    total += currentNumber;
                    divideBy++;
                }
            }
            if (divideBy == 0)
            {
                MessageBox.Show("No Grades to Average!");
                return;
            }
            else
            {
                double average = total / divideBy;
                MessageBox.Show($"The average grade for Test 2 is: {Math.Round(average, 2)}");
            }
        }

        //Gets the average test score for Quiz1
        private void Quiz1AverageScore_Click(object sender, EventArgs e)
        {
            //List of gradesObjects that will be filled with every students exams score
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGrades();

            double divideBy = 0;
            double total = 0;

            //Loops through each student and adds all quiz1 scores up
            //If the grade is "N/A" it will not be counted
            foreach (var student in gradesObjects)
            {
                int currentNumber = 0;
                bool success = Int32.TryParse(student.Quiz1, out currentNumber);
                if (success == true)
                {
                    total += currentNumber;
                    divideBy++;
                }
            }
            if (divideBy == 0)
            {
                MessageBox.Show("No Grades to Average!");
                return;
            }
            else
            {
                double average = total / divideBy;
                MessageBox.Show($"The average grade for Quiz 1 is: {Math.Round(average, 2)}");
            }
        }
        //Gets the average test score for Quiz2
        private void Quiz2Average_Click(object sender, EventArgs e)
        {
            //List of gradesObjects that will be filled with every students exams score
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGrades();

            double divideBy = 0;
            double total = 0;

            //Loops through each student and adds all quiz2 scores up
            //If the grade is "N/A" it will not be counted
            foreach (var student in gradesObjects)
            {
                int currentNumber = 0;
                bool success = Int32.TryParse(student.Quiz2, out currentNumber);
                if (success == true)
                {
                    total += currentNumber;
                    divideBy++;
                }
            }
            if (divideBy == 0)
            {
                MessageBox.Show("No Grades to Average!");
                return;
            }
            else
            {
                double average = total / divideBy;
                MessageBox.Show($"The average grade for Quiz 2 is: {Math.Round(average, 2)}");
            }
        }
        //Gets the average test score for Final exam
        private void FinalExamAverageScore_Click(object sender, EventArgs e)
        {
            //List of gradesObjects that will be filled with every students exams score
            var gradesObjects = new List<GradesObject>();
            gradesObjects = GetGrades();

            double divideBy = 0;
            double total = 0;

            //Loops through each student and adds all final scores up
            //If the grade is "N/A" it will not be counted
            foreach (var student in gradesObjects)
            {
                int currentNumber = 0;
                bool success = Int32.TryParse(student.Final, out currentNumber);
                if (success == true)
                {
                    total += currentNumber;
                    divideBy++;
                }
            }
            if (divideBy == 0)
            {
                MessageBox.Show("No Grades to Average!");
                return;
            }
            else
            {
                double average = total / divideBy;
                MessageBox.Show($"The average grade for Final is: {Math.Round(average, 2)}");
            }
        }

        //Returns a list of all students and their information
        public List<GradesObject> GetGradesObject(string gradeType)
        {
            var gradesList = new List<GradesObject>();

            //Queries all information for each student and adds it to the list
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Student.Student_ID, Student.First_Name, Student.Last_Name, Grades.Test1, " +
                               "Grades.Test2, Grades.Quiz1, Grades.Quiz2, Grades.Final " +
                               "FROM Student " +
                               "INNER JOIN Grades " +
                               "ON Student.Student_ID = Grades.Student_ID " +
                               "ORDER BY Student.Student_ID ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (var sqlDataReader = command.ExecuteReader())
                {
                    do
                    {
                        while (sqlDataReader.Read())
                        {
                            //Each parameter (x) represents the column in the query result
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

            //Asks the user for the grades of each student for the specified exam
            int input = 0;
            try
            {
                //Loops for each student in the list
                foreach (var currentStudent in gradesList)
                {
                    switch (gradeType)
                    {
                        case "Test1":
                            input = int.Parse(Interaction.InputBox($"What did {currentStudent.First_Name} {currentStudent.Last_Name}" +
                                    $" get on Test1", "Enter Test1 grade"));
                            if (input < 0)
                            {
                                MessageBox.Show("Invalid Grade!\n" +
                                    "Grade cannot be less than 0!");
                                return null;
                            }
                            currentStudent.Test1 = input.ToString();
                            break;

                        case "Test2":
                            input = int.Parse(Interaction.InputBox($"What did {currentStudent.First_Name} {currentStudent.Last_Name}" +
                                    $" get on Test2", "Enter Test2 grade"));
                            if (input < 0)
                            {
                                MessageBox.Show("Invalid Grade!\n" +
                                    "Grade cannot be less than 0!");
                                return null;
                            }
                            currentStudent.Test2 = input.ToString();
                            break;

                        case "Quiz1":
                            input = int.Parse(Interaction.InputBox($"What did {currentStudent.First_Name} {currentStudent.Last_Name}" +
                                    $" get on Quiz1", "Enter Quiz1 grade"));
                            if (input < 0)
                            {
                                MessageBox.Show("Invalid Grade!\n" +
                                    "Grade cannot be less than 0!");
                                return null;
                            }
                            currentStudent.Quiz1 = input.ToString();
                            break;

                        case "Quiz2":
                            input = int.Parse(Interaction.InputBox($"What did {currentStudent.First_Name} {currentStudent.Last_Name}" +
                                    $" get on Quiz2", "Enter Quiz2 grade"));
                            if (input < 0)
                            {
                                MessageBox.Show("Invalid Grade!\n" +
                                    "Grade cannot be less than 0!");
                                return null;
                            }
                            currentStudent.Quiz2 = input.ToString();
                            break;

                        case "Final":
                            input = int.Parse(Interaction.InputBox($"What did {currentStudent.First_Name} {currentStudent.Last_Name}" +
                                    $" get on Final", "Enter Final grade"));
                            if (input < 0)
                            {
                                MessageBox.Show("Invalid Grade!\n" +
                                    "Grade cannot be less than 0!");
                                return null;
                            }
                            currentStudent.Final = input.ToString();
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invaid Grade");
                return null;
            }
            return gradesList;
        }

        //Enters all new grades entered for each student into the database
        public void UpdateGrades(List<GradesObject> grades, string gradeType)
        {
            var currentStudent = grades;

            //Loops for each student in the list
            foreach (var student in currentStudent)
            {
                switch (gradeType)
                {
                    case "Test1":
                        using (var connection = new SqlConnection(ConnectionString.conString))
                        {
                            string query = $"UPDATE Grades SET Test1 = '{student.Test1}' WHERE Student_ID = {student.Student_ID} ";
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            command.ExecuteReader();
                        }
                        break;

                    case "Test2":
                        using (var connection = new SqlConnection(ConnectionString.conString))
                        {
                            string query = $"UPDATE Grades SET Test2 = '{student.Test2}' WHERE Student_ID = {student.Student_ID} ";
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            command.ExecuteReader();
                        }
                        break;

                    case "Quiz1":
                        using (var connection = new SqlConnection(ConnectionString.conString))
                        {
                            string query = $"UPDATE Grades SET Quiz1 = '{student.Quiz1}' WHERE Student_ID = {student.Student_ID} ";
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            command.ExecuteReader();
                        }
                        break;

                    case "Quiz2":
                        using (var connection = new SqlConnection(ConnectionString.conString))
                        {
                            string query = $"UPDATE Grades SET Quiz2 = '{student.Quiz2}' WHERE Student_ID = {student.Student_ID} ";
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            command.ExecuteReader();
                        }
                        break;

                    case "Final":
                        using (var connection = new SqlConnection(ConnectionString.conString))
                        {
                            string query = $"UPDATE Grades SET Final = '{student.Final}' WHERE Student_ID = {student.Student_ID} ";
                            SqlCommand command = new SqlCommand(query, connection);
                            connection.Open();
                            command.ExecuteReader();
                        }
                        break;
                }
            }
        }

        //Displays the specified columns onto the data grid on the GUI
        public void DisplayTable()
        {
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Student.Student_ID, Student.First_Name, Student.Last_Name, Grades.Test1, " +
                            "Grades.Test2, Grades.Quiz1, Grades.Quiz2, Grades.Final " +
                            "FROM Student " +
                            "INNER JOIN Grades " +
                            "ON Student.Student_ID = Grades.Student_ID " +
                            "ORDER BY Student.Student_ID ";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter dAdapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                dAdapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        //Edits a specified student's grade for a specified exam
        public void EditStudentGrade(string exam)
        {
            int studentID = 0;
            int newGrade = 0;
            int exists = 0;

            try
            {
                studentID = int.Parse(Interaction.InputBox($"Enter the student ID whose {exam} grade you want to change:",
                    $"Edit {exam}"));

                //Checks if the specified student ID exists in the table
                using (var connection = new SqlConnection(ConnectionString.conString))
                {
                    string existsQuery = $"SELECT COUNT(*) FROM Student WHERE Student_ID IN ({studentID})";
                    SqlCommand command = new SqlCommand(existsQuery, connection);
                    connection.Open();

                    using (var sqlDataReader = command.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            //Gets number of rows that exist with that student ID
                            exists = sqlDataReader.GetInt32(0);
                        }
                    }
                }

                if (exists == 0)
                {
                    //If exists = 0 then that ID is not in the table
                    MessageBox.Show("Student ID does not exist!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid ID!");
                return;
            }

            //Gets new grade from user if it is greater than or equal to 0
            try
            {
                newGrade = int.Parse(Interaction.InputBox("Enter the new grade:", "Edit Grade"));
                if (newGrade < 0)
                {
                    MessageBox.Show("Invalid Grade:\nNew grade cannot be less than zero!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Grade!");
                return;
            }

            //Updates new grade into the table
            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string updateQuery = $"UPDATE Grades SET Grades.{exam} = {newGrade} WHERE Student_ID = {studentID};";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                connection.Open();
                command.ExecuteReader();
                connection.Close();
            }
            MessageBox.Show("Grade Updated!");
            DisplayTable();
        }

        //Returns a list of all students information
        public List<GradesObject> GetGrades()
        {
            var gradesList = new List<GradesObject>();

            using (var connection = new SqlConnection(ConnectionString.conString))
            {
                string query = "SELECT Student.Student_ID, Student.First_Name, Student.Last_Name, Grades.Test1, " +
                               "Grades.Test2, Grades.Quiz1, Grades.Quiz2, Grades.Final " +
                               "FROM Student " +
                               "INNER JOIN Grades " +
                               "ON Student.Student_ID = Grades.Student_ID " +
                               "ORDER BY Student.Student_ID ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (var sqlDataReader = command.ExecuteReader())
                {
                    do
                    {
                        while (sqlDataReader.Read())
                        {
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

        //Help messagebox
        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a specific Exam to perform an action.\n" +
                            "In each submenu, you may:\n" +
                            "Enter all grades at once for that exam\n" +
                            "Enter/Edit a specific students grade for that exam\n" +
                            "View the class average for that exam" +
                            "Note: If a grade is listed as N/A, it has not been assigned!",
                            "Help");
        }
    }
}