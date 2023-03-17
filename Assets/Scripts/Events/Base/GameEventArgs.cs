using UnityEngine;

namespace Events.Base
{
    public class GameEventArgs
    {
        public GameObject Sender { get; }
        
        public GameEventArgs(GameObject sender)
        {
            Sender = sender;
        }
    }
}