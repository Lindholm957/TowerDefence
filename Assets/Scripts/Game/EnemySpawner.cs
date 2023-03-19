using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private RectTransform playground;
        [Space]
        [SerializeField] private float repeatRate = 1f;
        [SerializeField] private float minSpawnDistance = 860f;

        private void Awake()
        {
            StartSpawning();
        }
        
        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
            GlobalEventSystem.I.Subscribe(EventNames.Game.Restarted, OnGameRestarted);
        }

        private void OnGameOver(GameEventArgs arg0)
        {
            StopSpawning();
        }
        
        private void OnGameRestarted(GameEventArgs arg0)
        {
            StartSpawning();
        }

        private void StartSpawning()
        {
            InvokeRepeating("Spawn", 0, repeatRate);
        }

        public void StopSpawning()
        {
            CancelInvoke();
        }
        
        private void Spawn()
        {
            var randomPoint = new Vector2();
            var correctPos = false;
            
            while (!correctPos)
            {
                randomPoint = RandomPointInRect(playground);
                var distance = Vector2.Distance(Vector2.zero, randomPoint);
                
                if (minSpawnDistance < distance)
                {
                    correctPos = true;
                }
            }
            var enemy = Instantiate(enemyPrefab, randomPoint, Quaternion.identity, playground.transform);
            enemy.transform.localPosition = randomPoint;
        }

        private Vector2 RandomPointInRect(RectTransform rect)
        {
            return new Vector2(
                Random.Range(-rect.rect.width/2f, rect.rect.width/2f),
                Random.Range(-rect.rect.height/2f, rect.rect.height/2f)
            );
        }
    }
}
