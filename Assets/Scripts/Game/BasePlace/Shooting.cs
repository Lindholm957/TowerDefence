using System.Collections;
using Game.Data;
using UnityEngine;

namespace Game.BasePlace
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minDamage = 10f;
        [SerializeField] private float maxReloadSpeed = 0.3f;

        private const float ReloadUpgradeIndex = 3f;
        private GameObject _target;

        public void StartShooting(GameObject target)
        {
            _target = target;
            var delay =  (ReloadUpgradeIndex - PlayerData.I.AttackSpeedLvl) / maxReloadSpeed;

            StartCoroutine(DelayBeforeShooting(delay));
        }

        private void Shoot()
        {
            var bulletStartPos = new Vector2(transform.position.x, transform.position.y);

            var bullet = Instantiate(bulletPrefab, bulletStartPos,
                Quaternion.identity, transform.parent);
            
            var damage = minDamage * PlayerData.I.TotalDamageLvl;
            
            bullet.GetComponent<Bullet>().Init(_target, damage);
        }

        private IEnumerator DelayBeforeShooting(float delay)
        {
            yield return new WaitForSeconds(delay);
            Shoot();
        }
    }
}
