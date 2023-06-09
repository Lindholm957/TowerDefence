using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game
{
    public class GameStateChanger : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPrefab;
        [SerializeField] private GameObject basePlace;
        [SerializeField] private Transform UIPlayground;

        private GameObject _curGameOverScreen;

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameRestarted(GameEventArgs arg0)
        {
            Destroy(_curGameOverScreen);
            basePlace.SetActive(true);
        }

        private void OnGameOver(GameEventArgs arg)
        {
            _curGameOverScreen = Instantiate(gameOverPrefab, UIPlayground);
        }
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Restarted, OnGameRestarted);
        }
    }
}
