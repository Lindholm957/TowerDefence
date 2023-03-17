using System;
using System.Collections;
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
    }
}
