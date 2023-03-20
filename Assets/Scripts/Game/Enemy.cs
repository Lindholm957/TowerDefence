using System;
using Events.Base;
using Events.Systems;
using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        private float _hp = 30f;
        private float _speed = 30f;
        private GameObject _target;

        private void Awake()
        {
            _target = GameObject.FindGameObjectWithTag("BasePlace");
        }

        private void OnEnable()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Game.Over, OnGameOver);
        }

        private void OnGameOver(GameEventArgs arg0)
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    
        private void Update()
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }
    }
}