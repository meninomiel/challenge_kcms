using Challenge_KCMS.Data;
using Challenge_KCMS.Interfaces.Services;
using Challenge_KCMS.Services;
using Challenge_KCMS.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Challenge_KCMS
{
    public partial class App : Application
    {
        IProductRepository _productRepository;
        public App()
        {
            InitializeComponent();

            // Aplicando a injeção de dependência nos serviços implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            // Criando uma instância do repositorio
            _productRepository = new ProductRepository();
            //invoca o evento 
            OnAppStart();
        }

        private void OnAppStart()
        {
            // Obtendo todos os dados 
            var getLocalDB = _productRepository.GetProductList();
            
            // Se existir dados então exibe a lista senão inclui dados
            if (getLocalDB.Count > 0)
            {
                MainPage = new NavigationPage(new ProductList());
            }
            else
            {
                MainPage = new NavigationPage(new AddProduct());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
