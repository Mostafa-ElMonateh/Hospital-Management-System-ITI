using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    class Drug : BaseClass
    {
        #region Fields
        private int dose; 
        #endregion

        #region Properties
        public int Dose { get => dose; set => dose = value; } 
        #endregion

        #region Methods
        public override void Create() { }
        public override void Read() { }
        public override void Update(SqlConnection connection)
        {
            int Code = Helper.AskUserForNumber(UserInputEnum.Code);
            string Brand = Helper.AskUserForString(UserInputEnum.Brand);
            int Dose = Helper.AskUserForNumber(UserInputEnum.Dose);

            SqlCommand command = new SqlCommand($"update Drugs set Brand = '{Brand}', Dose = {Dose} where Code = {Code}", connection);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
                Console.WriteLine($"Record with ID {Code} updated successfully.");
            else
                Console.WriteLine($"Record with Code {Code} not found.");
        }
        public override void Search() { }
        #endregion
    }
}
