﻿using Microsoft.VisualBasic.FileIO;
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

        #region Start Interface of the app
        public static void PrintShapeStart()
        {
            // Print Hello Message Shape
            Console.WriteLine(new string('*', Console.WindowWidth));
            string print = "\n\t\t\t\t\t^ _ ^ Welcome to Your hospital ^ _ ^";
            Console.WriteLine(print.PadLeft(Console.WindowWidth / 2));
            Console.WriteLine();
            Console.WriteLine(new string('*', Console.WindowWidth));
        }

        public static void GetAccess()
        {
            // Access Method
            bool is_enterded = false, flag;
            do
            {
                Console.WriteLine("\nEnter the User Name :)");

                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;

                string user_name = Console.ReadLine();

                Console.ForegroundColor = originalColor;

                Console.WriteLine("\nEnter Password :)");
                Console.ForegroundColor = ConsoleColor.Green;
                flag = int.TryParse(Console.ReadLine(), out int password);
                Console.ForegroundColor = originalColor;
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
        #endregion

        #region Handle the user options
        public static int AskUserForNumber(UserInputEnum userInputEnum)
        {
            // Ask user to Enter name of columns depending on its choice.
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
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            while (!int.TryParse(Console.ReadLine(), out UserInput) || UserInput <= 0)
            {
                Console.ForegroundColor = originalColor;
                Console.WriteLine(PrintErrorMessage);
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ForegroundColor = originalColor;

            return UserInput;
        }

        public static string AskUserForString(UserInputEnum userInputEnum)
        {
            // Ask user to Enter name of columns depending on its choice.
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
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            UserInput = Console.ReadLine();
            Console.ForegroundColor = originalColor;
            while (UserInput is null)
            {
                Console.WriteLine(PrintErrorMessage);
                Console.ForegroundColor = ConsoleColor.Green;
                UserInput = Console.ReadLine();
                Console.ForegroundColor = originalColor;
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
        #endregion

        #region Excute Operations

        public static void ExecuteCruds(OperationsEnum operationName, SqlConnection connection)
        {
            // takes an operation from the user and excute it
            AskForTableForOperation(operationName);
            Console.WriteLine();
            Console.Write("Enter an Option: ");
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= 5)
            {
                Console.ForegroundColor = originalColor;
                ChooseCrud(operationName, input, connection);
            }
            else
            { Console.ForegroundColor = originalColor; Console.WriteLine("\nEnter a VALID option 👎\n"); }

            OperationAsk(connection);
        }


        // Operations List
        public static void OperationAsk(SqlConnection connection)
        {
            // ask the user for crud

            Console.WriteLine($"\n 1) To Add ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 2) To Read ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 3) To Update ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 4) To Delete ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 5) To Search ( Patients - nurses - consultant - drug )");
            Console.WriteLine($" 6) To Exit..");
            Console.WriteLine("\nSara please choose an operation :)");
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            int.TryParse(Console.ReadLine(), out int UserOption);
            Console.ForegroundColor = originalColor;
            switch (UserOption)
            {
                case 1:
                    {
                        ExecuteCruds(OperationsEnum.Add, connection);
                    }
                    break;
                case 2:
                    ExecuteCruds(OperationsEnum.Read, connection);
                    break;
                case 3:
                    ExecuteCruds(OperationsEnum.Update, connection);
                    break;
                case 4:
                    ExecuteCruds(OperationsEnum.Delete, connection);
                    break;
                case 5:
                    ExecuteCruds(OperationsEnum.Search, connection);
                    break;
                case 6:
                    {
                        Console.WriteLine("\n------------------\nGood Bye Ya Sara 👋\n------------------\n");
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

        public static void ChooseCrud(OperationsEnum opera, int option, SqlConnection connection)
        {
            // excute a crud depends on the user choice
            BaseClass sara = ReturnObj(option);
            if (sara is null)
                OperationAsk(connection);
            else if (OperationsEnum.Update == opera)
                sara.Update(connection);
            else if (OperationsEnum.Delete == opera)
                sara.Delete(connection, sara);
            else if (OperationsEnum.Search == opera)
                sara.Search(connection, sara);
            else if (OperationsEnum.Add == opera)
                sara.Add(connection, sara);
            else if (OperationsEnum.Read == opera)
                sara.Read(connection, sara);
            else
                sara.Delete(connection, sara);
        }


        public static BaseClass ReturnObj(int option)
        {
            // return object of entity depends on the user choice
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

            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write($"{column.ColumnName,-20}");
            }
            Console.WriteLine("\n");


            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item,-20}");
                }
                Console.WriteLine();
            }
        }

        #endregion


    }
}

