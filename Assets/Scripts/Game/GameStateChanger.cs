using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game
{
    public class GameStateChanger : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPrefab;
        [SerializeField] private GameObject basePlacePrefab;
        [SerializeField] private Transform playground;

        private GameObject _curGameOverScreen;

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameRestarted(GameEventArgs arg0)
        {
            Destroy(_curGameOverScreen);
            Instantiate(basePlacePrefab, playground);
        }

        private void OnGameOver(GameEventArgs arg)
        {
            _curGameOverScreen = Instantiate(gameOverPrefab, playground);
        }
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Unsubscribe(EventNames.Game.Restarted, OnGameRestarted);
        }
    }
}
