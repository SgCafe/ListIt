using ListIt.Models;
using ListIt.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListIt.Viewmodels
{
    public class ProductViewmodel : BaseViewmodel
    {
        #region  properties
        private readonly IDataRepository<Product> _productrepository;

        private Product product;
        public Product ProductTlg
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        private string _selectedProduct;
        public string SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }


        private ObservableCollection<Product> _itemsList;
        public ObservableCollection<Product> ItemsList
        {
            get => _itemsList;
            set => SetProperty(ref _itemsList, value);
        }
        #endregion

        #region constructor
        public ProductViewmodel()
        {
            _productrepository = DependencyService.Get<IDataRepository<Product>>();
            PopulateList();

            NavAddProductCommand = new Command<Product>(ExecuteNavAddPageCommand);
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
            DeleteItemCommand = new Command<Product>(ExecuteDeleteItemCommand);
            UpdateItemCommand = new Command<Product>(ExecuteUpdateItemCommand);

            
        }
        #endregion


        #region commands
        public ICommand LoadItemsCommand { get; }
        public ICommand DeleteItemCommand { get; set; }
        public ICommand UpdateItemCommand { get; }
        public ICommand NavAddProductCommand { get; set; }
        #endregion

        #region methods
        public int ItemCount => ItemsList.Count;

        public double TotalValue => (double)ItemsList.Sum(item => item.Value);
        private void PopulateList()
        {
            ItemsList = new ObservableCollection<Product>()
            {
                //new Product
                //{
                //    Name = "teste",
                //    Category = "Mercado",
                //    Quantity= 1,
                //    Value = 200,
                //    Image = "ph_gear.png"
                //},
                //new Product
                //{
                //    Name = "Roda",
                //    Category = "Oficina",
                //    Quantity= 2,
                //    Value = 2400,
                //    Image = "ph_gear.png"
                //}

            };

            ItemsList.CollectionChanged += OnItemsListChanged;

            
        }

        private void OnItemsListChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ItemCount));
            OnPropertyChanged(nameof(TotalValue));

        }

        public async void ExecuteLoadItemsCommand()
        {
            var items = await _productrepository.GetAllAsync();
            ItemsList.Clear();

            foreach (var item in items)
            {
                ItemsList.Add(item);
            }
        }

        private async void ExecuteDeleteItemCommand(Product item)
        {
            await _productrepository.DeleteAsync(item);
            ExecuteLoadItemsCommand();
        }

        private async void ExecuteUpdateItemCommand(Product item)
        {
            try
            {
                var SelectedProduct = await _productrepository.UpdateAsync(item);
                await Shell.Current.GoToAsync($"//AddProductShell?SelectedProduct={item}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok!");
            }
        }


        //private async void ExecuteUpdateItemCommand(Product product)
        //{
        //    try   
        //    {
        //        if (IsBusy) { return; }
        //        IsBusy = true;

        //        //var existingitem = await App.SQLiteDb.GetProductAsync(product.Id);

        //        await Shell.Current.GoToAsync($"//AddProductShell?parametro_id={product}");
        //        //await App.SQLiteDb.UpdateProductAsync(product);

        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok!");
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }

        //    //var existingitem = await App.SQLiteDb.GetProductAsync(id.Id);
        //    //if (existingitem != null)
        //    //{
        //    //    existingitem.Name = product.Name;
        //    //    existingitem.Value = product.Value;
        //    //    existingitem.Quantity = product.Quantity;
        //    //    existingitem.Category = product.Category;
        //    //    existingitem.Image = product.Image;
        //    //    await Shell.Current.GoToAsync("//AddProductShell");
        //    //    await App.SQLiteDb.UpdateProductAsync(id);
        //    //}
        //}

        private async void ExecuteNavAddPageCommand(Product item)
        {
            await Shell.Current.GoToAsync("//AddProductShell");
        }
        #endregion
    }
}