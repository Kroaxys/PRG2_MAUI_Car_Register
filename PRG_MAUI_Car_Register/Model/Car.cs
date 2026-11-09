using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {
        private int doors;
        public override string GetDescription()
        {
            return
                $"Registreringsnummer: {RegistrationNumber}\n" +
                $"Tillverkare: {Manufacturer}\n" +
                $"Modell: {Model}\n" +
                $"Typ: {VehicleType}\n" +
                $"År: {Year}\n " +
                $"Antal Dörrar: {Doors}\n";
        }
        public Car(string vehicleType, string registrationNumber, string manufacturer, string model, string year, int doors) : base( vehicleType,  registrationNumber,  manufacturer,  model,  year)
        {
            Doors = doors;
        }
        public int Doors
        {
            get { return doors; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid amount of doors.");
                }
                else { doors = value; }
            }
        }
    }
}
