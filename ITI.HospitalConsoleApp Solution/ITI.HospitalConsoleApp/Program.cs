using ITI.HospitalConsoleApp;
using System.Data.SqlClient;

namespace ITI.HospitalConsoleApp
{
    internal class Program
    {
        
        static void Main()
        {

            // Print Welcome To Your Hospital Message
            Helper.PrintShapeStart();

            string connectionString = "Data Source=.;Initial Catalog=Hospital; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                // Ask for UserName && Password
                Helper.GetAccess();

                // User makes operations due to its choices
                Helper.OperationAsk(connection);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

        }
    }
}
