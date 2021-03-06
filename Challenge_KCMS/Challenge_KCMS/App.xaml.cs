﻿using Challenge_KCMS.Interfaces.Repositories;
using Challenge_KCMS.Interfaces.Services;
using Challenge_KCMS.Services;
using Challenge_KCMS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Challenge_KCMS
{
    public partial class App : Application
    {
        ICategoryRepository _categoryRepository;
        public App()
        {
            InitializeComponent();

            // Aplicando a injeção de dependência nos serviços implementados
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();

            // Criando uma instância do repositorio
            _categoryRepository = new CategoryRepository();

            //invoca o evento 
            OnAppStart();
        }

        private void OnAppStart()
        {            
            MainPage = new NavigationPage(new CategoryList());
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
