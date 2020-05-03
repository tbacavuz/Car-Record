using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Vehicles
    {
        string Plate, Owner, Brand, Color, Country;
        _CarType Type;
        int Year;

        //CONSTRUCTOR
        public Vehicles(string plate = "", string owner = "", string brand = "", string color = "", string country = "", int year = 0, _CarType type = _CarType.FAMILY)
        {
            Plate = plate.ToUpper();
            Owner = owner.ToUpper();
            Brand = brand.ToUpper();
            Type = type;
            Color = color.ToUpper();
            Country = country.ToUpper();
            Year = year;
        }
       
        //Finds if a vehicle exists
        public bool SearchPlate(string plate)
        {
            if (plate == Plate)
                return true;
            else
                return false;
        }
        //Finds if an owner exist
        public bool SearchOwner(string owner)
        {
            if (owner == Owner)
                return true;
            else
                return false;
        }

        //changeType = Decides which attribute to change as the parameter item in switch
        public void Edit(_ChangedType changeType, object item)
        {
            switch (changeType)
            {
                case _ChangedType.Brand:
                    Brand = item.ToString();
                    break;

                case _ChangedType.Color:
                    Color = item.ToString();
                    break;

                case _ChangedType.Country:
                    Country = item.ToString();
                    break;

                case _ChangedType.Owner:
                    Owner = item.ToString();
                    break;

                case _ChangedType.Plate:
                    Plate = item.ToString();
                    break;

                case _ChangedType.Type:
                    Type = (_CarType)item;
                    break;

                case _ChangedType.Year:
                    Year = Convert.ToInt32(item);
                    break;

            }
        }

        //Override object.ToString() so we can get a string in a readable form
        public override string ToString()
        {
            return "________________________________________________ \n" +
                   "\n Plate    : " + Plate +
                   "\n Owner    : " + Owner +
                   "\n Brand    : " + Brand +
                   "\n Car Type : " + Type +
                   "\n Color    : " + Color +
                   "\n Country  : " + Country +
                   "\n Year     : " + Year +
                   "\n________________________________________________ \n";
        }
        
        //Getter for Plate
        public string GetPlate()
        {
            return Plate;
        }
    }
}
