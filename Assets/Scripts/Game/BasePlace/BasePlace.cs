using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game.BasePlace
{
    [RequireComponent(typeof(EnemySearching))]
    [RequireComponent(typeof(Shooting))]
    public class BasePlace : MonoBehaviour
    {
        private EnemySearching _enemySearching;
        private Shooting _shooting;
        public GameObject _target;

        private State _curState = State.Idle;
        private enum State
        {
            Idle,
            EnemySearching,
            Attacking
        }

        private void Awake()
        {
            _enemySearching = GetComponent<EnemySearching>();
            _shooting = GetComponent<Shooting>();
        }

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Enemy.NonLethalDamaged, OnNonLethalDamaged);
            GlobalEventSystem.I.Subscribe(EventNames.Enemy.Died, OnEnemyDied);
        }

        private void Start()
        {
            SearchEnemy();
        }

        private void SearchEnemy()
        {
            _curState = State.EnemySearching;
            
            _target = GetTarget();
            if (_target != null)
            {
                Attack();
            }
        }
        
        private void Attack()
        {
            _curState = State.Attacking;
            _shooting.Shoot(_target);
        }

        private GameObject GetTarget()
        {
            var enemies = _enemySearching.GetAllEnemies();
            return _enemySearching.DefineTarget(enemies);
        }
        
        private void OnNonLethalDamaged(GameEventArgs arg0)
        {
            Attack();
        }
        
        private void OnEnemyDied(GameEventArgs arg0)
        {
            SearchEnemy();
        }
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Enemy.NonLethalDamaged, OnNonLethalDamaged);
        }
    }
}
