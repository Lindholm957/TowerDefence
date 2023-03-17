using UnityEngine.Events;

namespace Events.Base
{
    public interface IEventSystem
    {
        public void SendEvent(string eventName, GameEventArgs args);
        public void Subscribe(string eventName, UnityAction<GameEventArgs> listener);
        public void Unsubscribe(string eventName, UnityAction<GameEventArgs> listener);
    }
}