using System.Windows.Forms;

namespace StudentAssmentProgram
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //Brings user to attendance feature when attendance tile is clicked
        private void Button_Attendance_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Attendance attendance = new Attendance();
            attendance.Show();
        }

        //Brings user to grades feature when grades tile is clicked
        private void Button_Grades_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            CheckGrades checkGrades = new CheckGrades();
            checkGrades.Show();
        }

        //Brings user to curriculum feature when curriculum tile is clicked
        //YES I KNOW CURRICULUM IS SPELT WRONG IN THE BUTTON CLICK METHOD BELOW BUT LEAVE IT
        private void Button_Cirriculum_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Curriculum curriculum = new Curriculum();
            curriculum.Show();
        }

        //Brings user to anticheat feature when anticheat tile is clicked
        private void Button_AntiCheat_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            AntiCheat antiCheat = new AntiCheat();
            antiCheat.Show();
        }

        //Logs the user out when the logout button is clicked
        private void Button_LogOut_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Logs the user out when the logout button is clicked
        private void LogOutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            LogIn logIn = new LogIn();
            logIn.Show();
        }

        //Closes the program when the X is clicked on the form
        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Information messagebox
        private void InformationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is the Home Screen!\n" +
                "From here you will be able to select which feature you want to access.\n" +
                "Check out the Help sections in each feature for more information.", "Help");
        }

        //Information messagebox
        private void Button_Help_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is the Home Screen!\n" +
                "From here you will be able to select which feature you want to access.\n" +
                "Check out the Help sections in each feature for more information.", "Help");
        }
    }
}