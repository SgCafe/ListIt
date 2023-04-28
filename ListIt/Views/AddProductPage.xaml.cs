using ListIt.Models;
using ListIt.Viewmodels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage()
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();
        }
    }
}