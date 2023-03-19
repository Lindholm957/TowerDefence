using Events.Base;
using Events.Systems;
using UnityEngine;

namespace UI
{
    public class RestartGameButton : MonoBehaviour
    {
        public void OnClick()
        {
            GlobalEventSystem.I.SendEvent(EventNames.Game.Restarted, new GameEventArgs(null));
        }
    }
}