using PRG_MAUI_Car_Register.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();
        private string pickerTypeItem = "Bil";
        public string PickerTypeItem
        {
            get
            {
                return pickerTypeItem;
            }
            set
            {
                if (pickerTypeItem != value)
                {
                    pickerTypeItem = value;
                    OnPropertyChanged(nameof(PickerTypeItem));
                    OnPickerChanged();  
                }
            }
        }
        private ObservableCollection<Vehicle> collectionViewVehiclesItemsSource;
        public ObservableCollection<Vehicle> CollectionViewVehiclesItemsSource
        {
            get
            {
                return collectionViewVehiclesItemsSource;
            }
            set
            {
                collectionViewVehiclesItemsSource = value;
                OnPropertyChanged(nameof(CollectionViewVehiclesItemsSource));
            }
        }
        public bool entryDoorsIsVisible { get; set; } = true;
        public bool entryCategoryIsVisible { get; set; } = false;
        public bool entryLoadCapacityIsVisible { get; set; } = false;
        public string entryManufacturerText { get; set; }
        public string entryYearText { get; set; }
        public string entryRegistrationNumberText { get; set; }
        public string entryModelText { get; set; }
        public string entryDoorsText { get; set; }
        public string entryCategoryText { get; set; }
        public string entryLoadCapacityText { get; set; }
        public bool radioCarIsChecked { get; set; }
        public bool radioMCIsChecked { get; set; }
        public bool radioTruckIsChecked { get; set; }
        public string entrySearchRegistrationNumberText { get; set; }
        public string labelSearchResultText { get; set; } = "Sökresultat visas här...";
        public ICommand? RegisterBtnCommand { get; set; }
        private string selectedRadioVehicles = "Alla";
        public string SelectedRadioVehicles
        {
            get
            {
                return selectedRadioVehicles;
            }
            set 
            {
                if (selectedRadioVehicles != value) 
                {
                    selectedRadioVehicles = value;
                    OnPropertyChanged(nameof(SelectedRadioVehicles));
                    OnRadioCheckedChanged();
                }
            }
        }
        public ICommand? SearchBtnCommand { get; set; }


        public MainPageViewModel()
        {
            collectionViewVehiclesItemsSource = vehicleList;
            RegisterBtnCommand = new Command(() => OnRegisterClicked());
            SearchBtnCommand = new Command(() => OnSearchClicked());
        }

        private void OnPickerChanged()
        {
            try
            {
                string vehicle = pickerTypeItem.ToString();
                entryDoorsIsVisible = false;
                entryCategoryIsVisible = false;
                entryLoadCapacityIsVisible = false;

                switch (vehicle)
                {
                    case "Bil": { entryDoorsIsVisible = true; break; }
                    case "MC": { entryCategoryIsVisible = true; break; }
                    case "Lastbil": { entryLoadCapacityIsVisible = true; break; }
                }
            }
            catch { throw new ArgumentException("Invalid Picker."); }
            OnPropertyChanged(nameof(entryDoorsIsVisible));
            OnPropertyChanged(nameof(entryCategoryIsVisible));
            OnPropertyChanged(nameof(entryLoadCapacityIsVisible));
        }

        private async Task OnRegisterClicked()
        {
            try
            {
                //Vehicle vehicle = new Vehicle(/*(Vehicle.Type)*/pickerType.SelectedIndex.ToString());

                //vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                //vehicle.Manufacturer = entryManufacturer.Text;
                //vehicle.Model = entryModel.Text; 
                //vehicle.Year = entryYear.Text;

                string manufacturer = entryManufacturerText;
                string year = entryYearText;
                string registrationNumber = entryRegistrationNumberText;
                string model = entryModelText;

                Vehicle vehicle;
                string vehicleType = pickerTypeItem.ToString();

                switch (vehicleType)
                {
                    case "Bil":
                        {
                            if (!int.TryParse(entryDoorsText, out int doors)) { throw new ArgumentException("Ogiltlig symboler för dörrar"); }
                            vehicle = new Car(vehicleType, registrationNumber, manufacturer, model, year, doors);
                            break;
                        }
                    case "MC":
                        {
                            string category = entryCategoryText;
                            vehicle = new MC(vehicleType, registrationNumber, manufacturer, model, year, category);
                            break;
                        }
                    case "Lastbil":
                        {
                            if (!double.TryParse(entryLoadCapacityText, out double loadCapacity)) { throw new ArgumentException("Ogiltlig Lastkapasitet"); }
                            vehicle = new Truck(vehicleType, registrationNumber, manufacturer, model, year, loadCapacity);
                            break;
                        }
                    default: { throw new ArgumentException("Ogiltlig fordonstyp"); }
                }



                vehicleList.Add(vehicle);

                //Vehicle vehicle;

                ClearTextFields();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.ToString());
                }
        }

        private void OnRadioCheckedChanged()
        {
            // Skapa en temporär filtrerad lista baserat på vilken radioknapp som är vald
            IEnumerable<Vehicle> filteredList;

            switch (selectedRadioVehicles)
            {
                case "Bil":
                    {
                        filteredList = vehicleList.Where(v => v is Car);
                        break;
                    }
                case "MC":
                    {
                        filteredList = vehicleList.Where(v => v is MC);
                        break;
                    }
                case "Lastbil":
                    {
                        filteredList = vehicleList.Where(v => v is Truck); 
                        break;
                    }
                case "Alla":
                    {
                        filteredList = vehicleList;
                        break;
                    }
                default: { throw new ArgumentException("Ogiltlig fordonstyp"); }
            }

            //if (radioCarIsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v is Car).ToList();
            //}
            //else if (radioMCIsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v is MC).ToList();
            //}
            //else if (radioTruckIsChecked)
            //{
            //    filteredList = vehicleList.Where(v => v is Truck).ToList();
            //}
            //else
            //{
            //    // Om "Alla" är vald, visa hela listan
            //    filteredList = vehicleList;
            //}

            CollectionViewVehiclesItemsSource = new ObservableCollection<Vehicle>(filteredList);
        }

        private void OnSearchClicked()
        {
            string searchTerm = entrySearchRegistrationNumberText?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumberText = "Ange ett registreringsnummer för att söka.";
                OnPropertyChanged(nameof (entrySearchRegistrationNumberText));
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResultText = $"Fordon hittat:\n" + foundVehicle.GetDescription();
                OnPropertyChanged(nameof(labelSearchResultText));
            }
            else
            {
                labelSearchResultText = "Inget fordon hittades med det registreringsnumret.";
                OnPropertyChanged(nameof(labelSearchResultText));
            }
        }


        private void ClearTextFields()
        {
            entryRegistrationNumberText = string.Empty;
            entryManufacturerText = string.Empty;
            entryModelText = string.Empty;
            entryYearText = string.Empty;
            entryCategoryText = string.Empty;
            entryDoorsText = string.Empty;
            entryLoadCapacityText = string.Empty;

            OnPropertyChanged(nameof(entryRegistrationNumberText));
            OnPropertyChanged(nameof(entryManufacturerText));
            OnPropertyChanged(nameof(entryModelText));
            OnPropertyChanged(nameof(entryYearText));
            OnPropertyChanged(nameof(entryCategoryText));
            OnPropertyChanged(nameof(entryDoorsText));
            OnPropertyChanged(nameof(entryLoadCapacityText));
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

