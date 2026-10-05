using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnPickerChanged(object sender, EventArgs e)
        {
            try
            {
                //fix
                string vehicle = pickerType.SelectedItem.ToString();
                entryDoors.IsVisible = false;
                entryCategory.IsVisible = false;
                entryLoadCapacity.IsVisible = false;

                switch (vehicle)
                {
                    case "Bil": { entryDoors.IsVisible = true; break; }
                    case "MC": { entryCategory.IsVisible = true; break; }
                    case "Lastbil": { entryLoadCapacity.IsVisible = true; break; }
                }
            }
            catch { throw new ArgumentException("Invalid Picker."); }

        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                //Vehicle vehicle = new Vehicle(/*(Vehicle.Type)*/pickerType.SelectedIndex.ToString());

                //vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                //vehicle.Manufacturer = entryManufacturer.Text;
                //vehicle.Model = entryModel.Text;
                //vehicle.Year = entryYear.Text;




                //vehicleList.Add(vehicle);
                //listViewVehicles.ItemsSource = null;
                //listViewVehicles.ItemsSource = vehicleList;

                Vehicle vehicle;

                ClearTextFields();
            }

            // här "fångas" eventuella felmeddelanden från Vehicle
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            // Skapa en temporär filtrerad lista baserat på vilken radioknapp som är vald
            IEnumerable<Vehicle> filteredList;

            //if (radioCar.IsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v.is Car).ToList();
            //}
            //else if (radioMC.IsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v.VehicleType == "MC"/*Vehicle.Type.MC*/).ToList();
            //}
            //else if (radioTruck.IsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v.VehicleType == "Truck"/*Vehicle.Type.Lastbil*/).ToList();
            //}
            //else
            //{
            //    // Om "Alla" är vald, visa hela listan
            //    filteredList = vehicleList;
            //}

            //listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Typ: {foundVehicle.VehicleType}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

        private void ClearTextFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryYear.Text = string.Empty;
        }
    }
}
