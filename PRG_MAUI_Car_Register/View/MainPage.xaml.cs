using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}