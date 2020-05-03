using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project
{
    class Program
    {
        //Create a list of vehicle class objects
        static ListVehicles listVehicles = new ListVehicles();

        //static void import()
        //{
        //    string plate, brand, owner, color, country;
        //    int year;
        //    _CarType Type;
        //    string[] attributes = new string[6];
        //    string[] data = File.ReadAllLines(@"vehicles.txt");

        //    for (int i=0; i<100 ;i++)
        //    {
        //        attributes = data[i].Split(',');
        //    for(int j=0; j<7 ; j++)
        //    {
        //        switch (j)
        //        {
        //            case 0: plate = attributes[j]; break;
        //            case 1: owner = attributes[j]; break;
        //            case 2: brand = attributes[j]; break;
        //            case 3: color = attributes[j]; break;
        //            case 4: country = attributes[j]; break;
        //            case 5: year = Convert.ToInt32(attributes[j]); break;
        //            case 6: Type = (_CarType)Convert.ToInt32(attributes[j]); break;
        //        }            
        //    }
        //        listVehicles.Add(new Vehicles(plate, owner, brand, color, country, year, Type));
        //    }       
        //}


        //Visual instruction functions
        static void addmenu()
        {
            string plate, brand, owner, color, country;
            int year;
            _CarType Type;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n Enter the vehicles information below.\n");
            Console.ResetColor();
            Console.WriteLine("PLATE: "); plate = Console.ReadLine();
            Console.WriteLine("OWNER: "); owner = Console.ReadLine();
            Console.WriteLine("BRAND: "); brand = Console.ReadLine();
            Console.WriteLine("COLOR: "); color = Console.ReadLine();
            Console.WriteLine("COUNTRY: "); country = Console.ReadLine();
            Console.WriteLine("YEAR: "); year = Convert.ToInt32(Console.ReadLine());
            ask:
            Console.WriteLine("Choose TYPE from BUS(0) - Family(1) - Truck(2): ");

            int check = Convert.ToInt32(System.Console.ReadLine());
            if (Convert.ToBoolean(check < 0 || check > 2))
            {
                Console.WriteLine("\n***********    INVALID INPUT.   ***********\n");
                goto ask;
            }
            Type = (_CarType)check;
            listVehicles.Add(new Vehicles(plate, owner, brand, color, country, year, Type));
        }
        static void searchmenu()
        {
            int option;
            ask:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press 9 to GO BACK\n");
            Console.ResetColor();
            Console.WriteLine("\n Choose an option to search by:\n 1-PLATE\n 2-OWNER");
            option = Convert.ToInt32(Console.ReadLine());
            if (option == 9) { Console.Clear(); return; }            
            switch (option)
            {
                case 1:
                    Console.WriteLine("\nEnter Plate: ");
                    string plate = Console.ReadLine().ToUpper();
                    listVehicles.Show(plate); break;
                case 2:
                    Console.WriteLine("\nEnter Owners Name: ");
                    string Owner = Console.ReadLine().ToUpper();
                    listVehicles.SearchOwner(Owner);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n*********** INVALID INPUT.\t***********\n");
                    goto ask;
            }
        }
        static void delete()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press 9 to GO BACK\n");
            Console.ResetColor();
            Console.WriteLine("\nEnter the plate to DELETE: ");
            string plate = Console.ReadLine().ToUpper();
            if (plate == 9.ToString()) { Console.Clear(); return; }
            Console.Clear();
            listVehicles.Remove(plate);
        }
        static void editmenu()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press 9 to GO BACK\n");
            Console.ResetColor();
            Console.WriteLine("\nEnter Plate: ");
            string plate = Console.ReadLine().ToUpper();
            if (plate == 9.ToString()) { Console.Clear(); return; }
            ask:
            Console.Clear();
            Console.WriteLine("________________________________________________\n");
            Console.WriteLine("\n Choose the field to EDIT " + plate
                               + "\n\n 0-PLATE\n"
                               + " 1-OWNER\n"
                               + " 2-BRAND\n"
                               + " 3-YEAR\n"
                               + " 4-COLOR\n"
                               + " 5-COUNRTY\n"
                               + " 6-TYPE\n");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press 9 to GO BACK\n");
            Console.ResetColor();
            Console.WriteLine("________________________________________________\n");
            int field = Convert.ToInt32(System.Console.ReadLine());
            _ChangedType Type = (_ChangedType)field;
            if (field == 9) { Console.Clear(); return; }
            if (field < 0 || field > 6)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n*********** INVALID INPUT.\t***********\n");
                Console.ResetColor();
            goto ask;
            }
            if (field != 6)
            { Console.WriteLine("\nEnter the new value: "); object item = Console.ReadLine();
                listVehicles.Edit(plate, Type, item);
            }
            if (field == 6)
            {   ask2:
                Console.WriteLine("\nChoose TYPE from BUS(0) - Family(1) - Truck(2): ");
                int check = Convert.ToInt32(System.Console.ReadLine());
                if (Convert.ToBoolean(check < 0 || check > 2))
                    {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n*********** INVALID INPUT.\t***********\n");
                    Console.ResetColor();
                    goto ask2;
                    }
                listVehicles.Edit(plate, Type, check);
            }
            

        }
        static void showall()
        {
            Console.WriteLine(listVehicles.ToString()); //Prints All

        }
        static void Main(string[] args)
        {
            //INIT MAIN MENU
            int i = 0;
            Console.WriteLine("__________________  WELCOME  ___________________\n");
            menu:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(listVehicles.Capacity()); //Shows remaining space
            Console.ResetColor();
            Console.WriteLine("________________________________________________\n");
            Console.WriteLine(" Press 1 to ADD\n" +
                              " Press 2 to SEARCH\n" +
                              " Press 3 to DELETE\n" +
                              " Press 4 to EDIT\n" +
                              " Press 5 to LIST ALL\n");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Press 0 to EXIT\n");
            if(Convert.ToBoolean(i))
            Console.WriteLine("Press 9 to CLEAR TEXT\n");
            Console.ResetColor();
            Console.WriteLine("________________________________________________\n");
            i=1;
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0: Environment.Exit(0); break;
                case 1: addmenu();
                    break;
                case 2: searchmenu();
                    break;
                case 3: delete();
                    break;
                case 4: editmenu();
                    break;
                case 5: showall();
                    break;
                case 9: Console.Clear(); break;
                default: Console.WriteLine("Wrong input"); break;
            }
            goto menu;   
        }
    }
}
