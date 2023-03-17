using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        private GameObject _target;
        private float _speed;
        private float _damage;

        public float Damage => _damage;
        public void Init(GameObject target, float speed, float damage)
        {
            _target = target;
            _speed = speed;
            _damage = damage;
            
            SetRotationToTarget();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject == _target)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            float step = _speed * Time.deltaTime * 10f;
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }
        
        private void SetRotationToTarget()
        {
            var dir = _target.transform.position - transform.position;
            dir = _target.transform.InverseTransformDirection(dir);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            
            transform.Rotate(0, 0, angle);
        }
    }
}