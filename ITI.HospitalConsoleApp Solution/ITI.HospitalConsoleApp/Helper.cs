using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HospitalConsoleApp
{
    static class Helper
    {

        // Print Hello Message Shape
        public static void PrintShapeStart()
        {
            Console.WriteLine(new string('*', Console.WindowWidth));
            string print = "\n\t\t\t\t\t^ _ ^ Welcome to Your hospital ^ _ ^";
            Console.WriteLine(print.PadLeft(Console.WindowWidth / 2));
            Console.WriteLine();
            Console.WriteLine(new string('*', Console.WindowWidth));
        }

        // Access Method
        public static void GetAccess()
        {
            bool is_enterded = false, flag;
            do
            {
                Console.WriteLine("\nEnter the User Name :)");
                string user_name = Console.ReadLine();
                Console.WriteLine("\nEnter Password :)");

                flag = int.TryParse(Console.ReadLine(), out int password);
                if (flag && user_name == "sara" && password == 1592001)
                {
                    Console.Clear();
                    Console.WriteLine("---------------");
                    Console.WriteLine("Hello Ya Sara 👋 ");
                    Console.WriteLine("---------------");
                    is_enterded = true;
                }
            } while (!is_enterded);
        }

        public static int AskUserForNumber(UserInputEnum userInputEnum)
        {

            string PrintMessage = "";
            string PrintErrorMessage = "";

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
        
        // List Options
        public static void AskForTableForOperation(OperationsEnum OperationName)
        {
            Console.WriteLine();
            Console.WriteLine($" 1) {OperationName.ToString()} Patients");
            Console.WriteLine($" 2) {OperationName.ToString()} nurses");
            Console.WriteLine($" 3) {OperationName.ToString()} consultant");
            Console.WriteLine($" 4) {OperationName.ToString()} drug");
            Console.WriteLine($" 5) Back to the menu..");
        }




        // Operations List
        public static void OperationAsk(SqlConnection connection)
        {
            Console.WriteLine($"\n 1) To Add ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 2) To Read ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 3) To Update ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 4) To Delete ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 5) To Search ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 6) To Exit..");

            Console.WriteLine("\nSara please choose an operation :)");

            int.TryParse(Console.ReadLine(), out int UserOption);


            switch (UserOption)
            {
                case 1:
                    {
                        // Nada Will Complete this Code..
                        Console.WriteLine("This Is Nada Code..");
                    }
                    break;
                case 2:
                    {
                        AskForTableForOperation(OperationsEnum.Read);
                        Console.WriteLine();
                        Console.Write("Enter an Option: ");
                        if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input < 5)
                            testSara(OperationsEnum.Read, input, connection);
                        else
                            Console.WriteLine("\nEnter a VALID option 👎\n");
                        OperationAsk(connection);
                    }
                    break;
                case 3:
                    {
                        AskForTableForOperation(OperationsEnum.Update);
                        Console.WriteLine();
                        Console.Write("Enter an Option: ");

                        if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input < 5)
                            testSara(OperationsEnum.Update, input, connection);
                        else
                            Console.WriteLine("\nEnter a VALID option 👎\n");

                        OperationAsk(connection);
                    }
                    break;
                case 4:
                    {
                        AskForTableForOperation(OperationsEnum.Delete);
                        Console.WriteLine();
                        Console.Write("Enter an Option: ");

                        if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input < 5)
                            testSara(OperationsEnum.Delete, input, connection);
                        else
                            Console.WriteLine("\nEnter a VALID option 👎\n");

                        OperationAsk(connection);

                    }
                    break;
                case 5:
                    {
                        AskForTableForOperation(OperationsEnum.Search);
                        Console.WriteLine();
                        Console.Write("Enter an Option: ");

                        if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input < 5)
                            testSara(OperationsEnum.Search, input, connection);
                        else
                            Console.WriteLine("\nEnter a VALID option 👎\n");

                        OperationAsk(connection);
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("\n------------------");
                        Console.WriteLine("Good Bye Ya Sara 👋");
                        Console.WriteLine("------------------\n");
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n----------------------------------------------------------");
                        Console.WriteLine("Sara Don't Make Me Nervous 😡.. Choose a correct choice!!!");
                        Console.WriteLine("----------------------------------------------------------\n");
                        OperationAsk(connection);
                    }
                    break;
            }


        }


        public static void testSara(OperationsEnum opera, int option, SqlConnection connection)
        {
            BaseClass sara = ReturnObj(option);
            if(sara is null)
                OperationAsk(connection);
            else if (OperationsEnum.Update == opera)
                sara.Update(connection);
            else if (OperationsEnum.Delete == opera)
                sara.Delete(connection, sara);
            else if (OperationsEnum.Search == opera)
                sara.Search(connection, sara);
            else if (OperationsEnum.Add == opera)
                sara.Create(connection, sara);
            else if (OperationsEnum.Read == opera)
                sara.Read(connection, sara);
            else
                sara.Delete(connection, sara);
        }


        public static BaseClass ReturnObj(int option)
        {
            if (option == 1)
                return new Patient();
            else if (option == 2)
                return new Nurse();
            else if (option == 3)
                return new Consultant();
            else if (option == 4)
                return new Drug();
            return null;
        }


        public static void PrintDataTable(DataTable dataTable)
        {
            // Print column headers
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write($"{column.ColumnName,-15}");
            }
            Console.WriteLine();

            // Print rows
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-15}");
                }
                Console.WriteLine();
            }
        }





    }
}

