using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Roadster : MC
    {
        public Roadster(string vehicleType, string registrationNumber, string manufacturer, string model, string year, string wheels) : base(vehicleType, registrationNumber, manufacturer, model, year, wheels)
        {

        }
    }
}
