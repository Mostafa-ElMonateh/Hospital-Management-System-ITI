using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    class Consultant : BaseClass
    {
        #region Fields
        private string department; 
        #endregion

        #region Properties
        public string Department
        {
            get => department;
            set => department = value;
        } 
        #endregion

        #region Methods
        public override void Create() { }
        public override void Read() { }
        public override void Update(SqlConnection connection)
        {
            int Id = Helper.AskUserForNumber(UserInputEnum.Id);
            string Name = Helper.AskUserForString(UserInputEnum.Name);
            string Department = Helper.AskUserForString(UserInputEnum.Department);

            SqlCommand command = new SqlCommand($"update Consultants set Name = '{Name}', Department = '{Department}' where Id = {Id}", connection);

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
