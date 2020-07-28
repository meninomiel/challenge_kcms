using Challenge_KCMS.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_KCMS.Services
{
    class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await Challenge_KCMS.App.Current.MainPage.DisplayAlert("Produtos", message, "Ok");
        }

        public async Task ShowAsync(string title, string message, string primaryText)
        {
            await Challenge_KCMS.App.Current.MainPage.DisplayAlert(title, message, primaryText);
        }

        public async Task ShowAsync(string title, string message, string primaryText, string secondaryText)
        {
            await Challenge_KCMS.App.Current.MainPage.DisplayAlert(title, message, primaryText, secondaryText);
        }

        public async Task<bool> ShowAsyncBool(string title, string message, string primaryText, string secondaryText)
        {
            return await Challenge_KCMS.App.Current.MainPage.DisplayAlert(title, message, primaryText, secondaryText);
        }
    }
}
