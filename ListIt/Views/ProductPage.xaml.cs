using ListIt.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
            BindingContext = new ProductViewmodel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(BindingContext is ProductViewmodel viewmodel)
            {
                viewmodel.ExecuteLoadItemsCommand();
            }
        }
    }
}