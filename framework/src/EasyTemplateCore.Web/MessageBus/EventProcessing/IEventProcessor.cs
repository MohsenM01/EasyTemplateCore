using System.Threading.Tasks;

namespace EasyTemplateCore.Web.MessageBus.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}