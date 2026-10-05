using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        private string category;
        public override string GetDescription()
        {
            throw new NotImplementedException();
        }
        public MC(string vehicleType, string registrationNumber, string manufacturer, string model, string year, string category) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            Category = category;
        }
        public string Category
        {
            get { return category; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Entry is null or empty.");
                }
            }
        }
    }
}
