using System.Threading.Tasks;

namespace PrimeWeb.Core.Event
{
    public interface IEventHandler<T>
        where T: IEvent
    {
        Task HandleEvent(T param);
    }
}
