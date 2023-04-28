using ListIt.Models;
using ListIt.Repository;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListIt.Viewmodels
{
    internal class AddProductViewModel : BaseViewmodel
    {
        #region properties
        private readonly IDataRepository<Product> _productRepository;

        private ObservableCollection<Product> _categoriesList;
        public ObservableCollection<Product> CategoriesList
        {
            get => _categoriesList;
            set => SetProperty(ref _categoriesList, value);
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set => SetProperty(ref _nome, value);
        }

        private Product _categoria;

        public Product Categoria
        {
            get => _categoria;
            set => SetProperty(ref _categoria, value).ToString();
        }


        private int? _quantidade;
        public int? Quantidade
        {

            get { return _quantidade; }
            set => SetProperty(ref _quantidade, value);
        }

        private double? _valor;
        public double? Valor
        {
            get { return _valor; }
            set => SetProperty(ref _valor, value);
        }
        #endregion

        #region Constructor
        public AddProductViewModel()
        {
            _productRepository = DependencyService.Get<IDataRepository<Product>>();
            CategoryList();
            BackProductPageCommand = new Command(ExecuteBackProductPageCommand);
            SaveProductCommand = new Command(ExecuteSaveProductCommand);
            
        }
        #endregion

        #region commands
        public ICommand BackProductPageCommand { get; set; }
        public ICommand SaveProductCommand { get; set; }
        #endregion


        #region methods

        private void CategoryList()
        {
            CategoriesList = new ObservableCollection<Product>()
            {
                new Product
                {
                    Category = "Mercado",
                    Image = "ps_cart.png"
                },
                new Product
                {
                    Category = "Eletronicos",
                    Image = "computer_simbolo.png"
                },
                new Product
                {
                    Category = "Oficina",
                    Image = "ph_gear.png"
                },
                new Product
                {
                    Category = "Farmácia",
                    Image = "mdi_health.png"
                },
            };

        }

        private async void ExecuteSaveProductCommand()
        {
            var item = new Product
            {
                Name = Nome,
                Quantity = Quantidade,
                Value = Valor,
                Category = Categoria.Category,
                Image = Categoria.Image,
            };

            await _productRepository.InsetAsync(item);
            
            Nome = string.Empty;
            Quantidade = null;
            Valor = null;
            Categoria = null;

            ExecuteBackProductPageCommand();
        }

        private async void ExecuteBackProductPageCommand()
        {
            await Shell.Current.GoToAsync("//ProductPageShell");
        }

        #endregion
    }
}