using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    abstract class BaseClass
    {
        #region Fields
        private int id;
        private string name;
        #endregion

        #region Properties
        public int Id{get => id;}
        public string Name
        {
            get => name;
            set => name = value;
        } 
        #endregion

        #region Methods
        public virtual void Create() { }
        public virtual void Read() { }
        public virtual void Search() { }
        public virtual void Update(SqlConnection connection) { }


        public void Delete(SqlConnection connection, EntitiesEnum entitiesEnum)
        {

            int Id = Helper.AskUserForNumber(UserInputEnum.Id);

            SqlCommand command = new SqlCommand($"delete from {entitiesEnum.ToString()} where Id = {Id}", connection);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with ID {Id} deleted successfully.");
            else
                Console.WriteLine($"Record with ID {Id} not found.");

        }

        #endregion


    }
}
