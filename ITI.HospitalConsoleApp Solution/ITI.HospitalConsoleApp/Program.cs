using System.Data.SqlClient;

namespace ITI.HospitalConsoleApp
{
    internal class Program
    {
        static void Main()
        {

            string connectionString = "Data Source=.;Initial Catalog=Hospital; Trusted_Connection=True";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                Patient patient = new Patient();
                Consultant consultant = new Consultant();
                Nurse nurse = new Nurse();
                Drug drug = new Drug();
                drug.Update(connection);
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
