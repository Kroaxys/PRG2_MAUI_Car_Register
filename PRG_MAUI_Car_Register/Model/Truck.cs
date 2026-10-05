using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {   
        private int loadCapacity;
        public override string GetDescription()
        {
            throw new NotImplementedException();
        }
        public Truck(string vehicleType, string registrationNumber, string manufacturer, string model, string year) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            LoadCapacity = loadCapacity;
        }
        public int LoadCapacity
        {
            get { return loadCapacity; }
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
