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
            return
                $"Registreringsnummer: {RegistrationNumber}\n" +
                $"Tillverkare: {Manufacturer}\n" +
                $"Modell: {Model}\n" +
                $"Typ: {VehicleType}\n" +
                $"År: {Year}\n" +
                $"Kategori: {Category}\n";
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
                    throw new ArgumentException("Entry is null or empty.");
                }
                else { category = value; }
            }
        }
    }
}
