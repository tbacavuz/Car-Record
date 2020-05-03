using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class ListVehicles
    {
        List<Vehicles> list;
        
        //INIT LIST WITH 10 VEHICLE OBJECTS
        public ListVehicles()
        {           
            list = new List<Vehicles>
            {
                new Vehicles("HM230","Ahmet","bmw","Green","Germany",2012),
                new Vehicles("HT685","Mehmet","mercedes","Black","Germany",2015),
                new Vehicles("SD345","Behcet","audi","White","Germany",2017),
                new Vehicles("VSD23","ceyla","suzuki","Brown","Japan",1999),
                new Vehicles("WE896","Ali","hyundai","Purple","Japan",2007),
                new Vehicles("YT187","Ayse","opel","Red","Germany",2009),
                new Vehicles("PU852","Fatma","nissan","Black","Japan",2006),
                new Vehicles("BX054","Selin","toyota","Silver","Japan",1996),
                new Vehicles("RN2229","Tolga","ford","Blue","usa",2000),
                new Vehicles("EM334","Cagri","porshce","Yellow","Germany",2018),
            };
        }

        public void Add(Vehicles item)
        {
            //CHECK FULL
            if (list.Count == 100) { 
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n***********\t LIST IS FULL.\t***********\n");
            Console.ResetColor(); }
            else
            {
                list.Add(item);
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("\n**********       "+item.GetPlate()+ " ADDED.      ***********\n");
                Console.ResetColor();
            }
        }
        public string Capacity()
        {
            return "*********** LIST CAPACITY: " + list.Count + "/100. ***********\n";
        }
        public Vehicles SearchPlate(string Plate)
        {
            foreach (Vehicles item in list)      //  for (int i = 0; i < list.Count; i++)
            {                                    //  {
                if (item.SearchPlate(Plate))     //    if (list[i].SearchPlate(Plate))
                    return item;                 //        return list[i];
            }                                    //  }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n***********\t" + Plate + " NOT FOUND.\t***********\n");
            Console.ResetColor();
            return null;
        }
        public void SearchOwner(string Owner)
        {
            bool control=true;
            foreach (Vehicles item in list)
            {
                if (item.SearchOwner(Owner))
                {
                    Console.WriteLine(item);
                    control = false;
                }

            }
            if (control)
            {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n***********\t" + Owner + " NOT FOUND.\t***********\n");
            Console.ResetColor();

            }
            return;
        }

        public void Show(string Plate)
        {
            Console.WriteLine(SearchPlate(Plate));

            //foreach (Vehicles item in list)     //for (int i = 0; i < list.Count; i++)
            //{                                   //{
            //    if (item.SearchPlate(Plate))    //    if (list[i].SearchPlate(Plate))
            //        Console.WriteLine(item);    //        Console.WriteLine(list[i]);
            //}                                   //}     

        }

        public void Remove(string Plate)
        {
            Vehicles get = SearchPlate(Plate);
            if (get != null)  //get? = not null
            {
                list.Remove(get);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("\n***********\t" + Plate + " DELETED.\t***********\n");
                Console.ResetColor();
            }
        }

        public void Edit(string Plate, _ChangedType changeType, object newItem)
        {
            Vehicles get = SearchPlate(Plate);
            get?.Edit(changeType, newItem);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("\n***********\tOPERATION SUCCESS\t***********\n");
            Console.ResetColor();
        }

        public override string ToString()
        {
            string all = "";

            foreach (Vehicles item in list)    //for (int i = 0; i < list.Count; i++)
            { all += item.ToString(); }        //all += list[i].ToString();

            return all;

        }
    }
}
