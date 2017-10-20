using System.Threading.Tasks;

namespace PrimeWeb.Core.Event
{
    public interface IEventHandler<TEvent>
        where TEvent: IEvent
    {
        Task HandleEvent(TEvent param);
    }
}
