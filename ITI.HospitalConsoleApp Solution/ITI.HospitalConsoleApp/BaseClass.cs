using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public virtual void Update(SqlConnection connection) { }

        public void Add(SqlConnection connection, BaseClass entity) {
            // Add records to entities in the database
            string Name = entity.ToString() == "Drugs" ? Helper.AskUserForString(UserInputEnum.Brand) : Helper.AskUserForString(UserInputEnum.Name);
            SqlCommand command;
            if (entity.ToString() == "Patients" || entity.ToString() == "Drugs")
            {
                int number = entity.ToString() == "Drugs" ? Helper.AskUserForNumber(UserInputEnum.Dose) : Helper.AskUserForNumber(UserInputEnum.Age);
                command = new SqlCommand($"insert into {entity.ToString()} values('{Name}',{number})", connection);
            }
            else
            {
                string DepartmentName = Helper.AskUserForString(UserInputEnum.Department);
                command = new SqlCommand($"insert into {entity.ToString()} values('{Name}','{DepartmentName}')", connection);
            }
            
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with {Name} added successfully.");
            else
                Console.WriteLine($"Record with {Name} not found.");

        }


        public void Search(SqlConnection connection, BaseClass entity)
        {
            // Search by name for records of entities in the database
            Console.WriteLine("\nSara Search by name ..");
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
        

        public void Delete(SqlConnection connection, BaseClass entity)
        {
            // Delete a record of entities in the database
            string option = (entity.ToString() == "Drugs") ? "Code" : "Id";

            int Id = option == "Code" ? Helper.AskUserForNumber(UserInputEnum.Code) : Helper.AskUserForNumber(UserInputEnum.Id);


            SqlCommand command = new SqlCommand($"delete from {entity.ToString()} where { option } = {Id}", connection);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with identifier {Id} deleted successfully.");
            else
                Console.WriteLine($"Record with identifier {Id} not found.");

        }

        public void Read(SqlConnection connection, BaseClass entity)
        {
            // Read data of entities in the database
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
