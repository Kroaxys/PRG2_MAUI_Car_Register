using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    abstract class MC : Vehicle
    {
        private string wheels;
        public override string GetDescription()
        {
            return
                    $"Registreringsnummer: {RegistrationNumber}\n" +
                    $"Tillverkare: {Manufacturer}\n" +
                    $"Modell: {Model}\n" +
                    $"Typ: {VehicleType}\n" +
                    $"År: {Year}\n" +
                    $"Kategori: {Wheels}\n";
        }
        public MC(string vehicleType, string registrationNumber, string manufacturer, string model, string year, string wheels) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            Wheels = wheels;
        }
        public string Wheels
        {
            get { return wheels; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Entry is null or empty.");
                }
                else{
                    int wheelsInt = 0;
                    if (int.TryParse(value, out wheelsInt))
                    {
                        wheels = wheelsInt.ToString();
                    }
                    else
                    {
                        throw new ArgumentException("Not a number");
                    }
                }
            }
        }
    }
}
