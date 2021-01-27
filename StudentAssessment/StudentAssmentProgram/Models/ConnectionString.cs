namespace StudentAssmentProgram.Models
{
    public static class ConnectionString
    {
        //Connection string to connect to Azure Cloud Database
        public static string conString = "Server=tcp:se-final-project.database.windows.net,1433;" +
               "Initial Catalog=Student_Database;Persist Security Info=False;" +
               "User ID=se_admin;Password=se_is_great380;" +
               "MultipleActiveResultSets=False;Encrypt=True;" +
               "TrustServerCertificate=False;Connection Timeout=30;";
    }
}