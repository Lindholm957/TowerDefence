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

        private void TakeDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                GlobalEventSystem.I.SendEvent(EventNames.Enemy.NonLethalDamaged, new GameEventArgs(null));
            }
        }
    
        private void Update()
        {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Bullet"))
            {
                var damage = col.GetComponent<Bullet>().Damage;
                TakeDamage(damage);
            }
        }

        private void OnDestroy()
        {
            GlobalEventSystem.I.SendEvent(EventNames.Enemy.Died, new GameEventArgs(null));
        }
    }
}