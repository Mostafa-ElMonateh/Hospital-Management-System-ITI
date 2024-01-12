using System;
using System.Collections.Generic;
using System.Data;
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
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get => name;
            set => name = value;
        } 
        #endregion

        #region Methods
        public virtual void Create(SqlConnection connection, BaseClass entity) { }
        public void Search(SqlConnection connection, BaseClass entity)
        {
            Console.WriteLine("Sara Search by name ..");
            Console.Write("Enter the name : ");
            string input = Console.ReadLine();

            string nameColumn = entity.ToString() == "Drugs" ? "Brand" : "Name";

            string sqlQuery = $"select * from {entity.ToString()} where {nameColumn} = '{input}'";

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                adapter.Fill(dataTable);
            }

            Helper.PrintDataTable(dataTable);


        }
        public virtual void Update(SqlConnection connection) { }


        public void Delete(SqlConnection connection, BaseClass entity)
        {
            string sara = (entity.ToString() == "Drugs") ? "Code" : "Id";

            int Id = sara == "Code" ? Helper.AskUserForNumber(UserInputEnum.Code) : Helper.AskUserForNumber(UserInputEnum.Id);


            SqlCommand command = new SqlCommand($"delete from {entity.ToString()} where { sara } = {Id}", connection);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with identifier {Id} deleted successfully.");
            else
                Console.WriteLine($"Record with identifier {Id} not found.");

        }

        public void Read(SqlConnection connection, BaseClass entity)
        {
            Console.WriteLine();

            string sqlQuery = $"select * from {entity.ToString()}";

            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                adapter.Fill(dataTable);
            }

            Helper.PrintDataTable(dataTable);


        }

        #endregion


    }
}
