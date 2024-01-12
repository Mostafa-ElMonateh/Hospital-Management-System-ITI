using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ITI.HospitalConsoleApp
{
    class Patient : BaseClass
    {
        #region Fields
        private int age; 
        #endregion

        #region Properties
        public int Age {get => age; set => age = value;} 
        #endregion

        #region Methods
        public override void Create() { }
        public override void Read() { }
        public override void Update(SqlConnection connection) {
            int Id = Helper.AskUserForNumber(UserInputEnum.Id);
            string Name = Helper.AskUserForString(UserInputEnum.Name);
            int Age = Helper.AskUserForNumber(UserInputEnum.Age);

            SqlCommand command = new SqlCommand($"update Patients set Name = '{Name}', Age = {Age} where Id = {Id}", connection);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with ID {Id} updated successfully.");
            else
                Console.WriteLine($"Record with ID {Id} not found.");
        }
        
        public override void Search() { } 
        #endregion
    }
}
