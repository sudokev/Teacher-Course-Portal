namespace StudentAssmentProgram.Models
{
    public class AttendanceObject
    {
        public int Student_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Record { get; set; }
        public int Total_Classes { get; set; }
        public double Percentage { get; set; }
    }
}