using System.Threading.Tasks;

namespace EasyTemplateCore.MessageBus.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}