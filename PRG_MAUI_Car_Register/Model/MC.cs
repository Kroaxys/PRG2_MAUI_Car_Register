using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        private int category;
        public override string GetDescription()
        {
            throw new NotImplementedException();
        }
        public MC(string vehicleType, string registrationNumber, string manufacturer, string model, string year) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            Category = category;
        }
        public int Category
        {
            get { return category; }
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
