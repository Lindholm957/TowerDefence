using System.Collections;
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
        private GameObject _target;

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
            StartCoroutine(StartSearchEnemy());
        }

        private IEnumerator StartSearchEnemy()
        {
            _curState = State.EnemySearching;

            yield return new WaitUntil(() => GetTarget() != null);
            
            _target = GetTarget();
            
            // Attack();
        }

        private void Attack()
        {
            _curState = State.Attacking;
            _shooting.Shoot(_target);
        }

        private GameObject GetTarget()
        {
            var enemies = _enemySearching.GetAllEnemies();
            return enemies == null ? null : _enemySearching.DefineTarget(enemies);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                GlobalEventSystem.I.SendEvent(EventNames.Game.Over, new GameEventArgs(null));
            }
        }
        
        private void OnNonLethalDamaged(GameEventArgs arg0)
        {
            Attack();
        }
        
        private void OnEnemyDied(GameEventArgs arg0)
        {
            StartCoroutine(StartSearchEnemy());
        }
        
        private void OnDisable()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Enemy.NonLethalDamaged, OnNonLethalDamaged);
        }
    }
}
