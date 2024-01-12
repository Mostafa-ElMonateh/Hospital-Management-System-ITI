using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    static class Helper
    {

        public static int AskUserForNumber(UserInputEnum userInputEnum)
        {
            
            string PrintMessage="";
            string PrintErrorMessage="";

            switch (userInputEnum)
            {
                case UserInputEnum.Id:
                    PrintMessage = $"Enter the ID: ";
                    PrintErrorMessage = $"Enter VALID ID: ";
                    break;
                case UserInputEnum.Age:
                    PrintMessage = $"Enter the Age: ";
                    PrintErrorMessage = $"Enter VALID Age: ";
                    break;
                case UserInputEnum.Code:
                    PrintMessage = $"Enter the Code: ";
                    PrintErrorMessage = $"Enter VALID Code: ";
                    break;
                case UserInputEnum.Dose:
                    PrintMessage = $"Enter the Dose: ";
                    PrintErrorMessage = $"Enter VALID Dose: ";
                    break;
            }

            int UserInput;

            Console.Write(PrintMessage);
            while (!int.TryParse(Console.ReadLine(), out UserInput) || UserInput <= 0)
            {
                Console.WriteLine(PrintErrorMessage);
            }
            return UserInput;
        }

        public static string AskUserForString(UserInputEnum userInputEnum)
        {
            
            string PrintMessage = "";
            string PrintErrorMessage = "";

            switch (userInputEnum)
            {
                case UserInputEnum.Name:
                    PrintMessage = $"Enter the Name: ";
                    PrintErrorMessage = $"Enter VALID Name: ";
                    break;
                case UserInputEnum.Department:
                    PrintMessage = $"Enter the Departmant: ";
                    PrintErrorMessage = $"Enter VALID Departmant: ";
                    break;
                case UserInputEnum.Brand:
                    PrintMessage = $"Enter the Brand Name: ";
                    PrintErrorMessage = $"Enter VALID Brand Name: ";
                    break;
                
            }







            string UserInput;

            Console.Write(PrintMessage);
            UserInput = Console.ReadLine();

            while (UserInput is null)
            {
                Console.WriteLine(PrintErrorMessage);
                UserInput = Console.ReadLine();
            }
            return UserInput;
        }


    }
}
