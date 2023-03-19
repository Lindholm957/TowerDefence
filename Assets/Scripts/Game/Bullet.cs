using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 300f;
        private GameObject _target;
        private float _damage;

        public float Damage => _damage;
        public void Init(GameObject target, float damage)
        {
            _target = target;
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
            float step = speed * Time.deltaTime;
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