using System;
using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game
{
    public class GameStateChanger : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPrefab;
        [SerializeField] private Transform playground;

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameRestarted(GameEventArgs arg0)
        {
            Time.timeScale = 1;
            
        }

        private void OnGameOver(GameEventArgs arg)
        {
            Time.timeScale = 0;
            Instantiate(gameOverPrefab, playground);
        }
    }
}
