using App.Template;
namespace App.Observers
{
    public interface IObserver
    {
        void OnNotify(Actor actor, Event receiveEvent);
    }
}

