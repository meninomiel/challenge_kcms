using System.Threading.Tasks;

namespace Challenge_KCMS.Interfaces.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
        Task ShowAsync(string title, string message, string primaryText);
        Task ShowAsync(string title, string message, string primaryText, string secondaryText);
        Task<bool> ShowAsyncBool(string title, string message, string primaryText, string secondaryText);
    }
}
