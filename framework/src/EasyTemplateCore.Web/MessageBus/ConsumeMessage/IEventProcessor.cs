using System.Threading.Tasks;

namespace EasyTemplateCore.Web.MessageBus.ConsumeMessage
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}