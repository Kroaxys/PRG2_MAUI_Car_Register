using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {
        private int doors;
        public Truck(string vehicleType, string registrationNumber, string manufacturer, string model, string year, string GetDescription) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            Doors = doors;
        }
        public int Doors
        {
            get { return doors; }
            set
            {
                if (value < 1 || value > 6)
                {
                    throw new Exception("");
                }
            }
        }
    }
}
