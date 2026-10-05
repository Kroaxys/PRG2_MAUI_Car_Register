using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {   
        private double loadCapacity;
        public override string GetDescription()
        {
            throw new NotImplementedException();
        }
        public Truck(string vehicleType, string registrationNumber, string manufacturer, string model, string year, double loadCapacity) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            LoadCapacity = loadCapacity;
        }
        public double LoadCapacity
        {
            get { return loadCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Ogiltlig lastkapacitet");
                }
                loadCapacity = value;
            }
        }
    }
}
