using WebApp.Models;
using WebApp.Data;
namespace WebApp.Services
{
    public interface ITextMessageService: IService<TextMessage>
    {
        Task CreateMessage(WebHookResponseModel request);
    }
}