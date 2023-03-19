using Game.Data;
using UnityEngine;

namespace Game.BasePlace
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float minAttackSpeed = 20f;
        [SerializeField] private float minDamage = 10f;

        private const float UpgradeIndex = 5f;

        public void Shoot(GameObject target)
        {
            var bulletStartPos = new Vector2(transform.position.x, transform.position.y);

            var bullet = Instantiate(bulletPrefab, bulletStartPos,
                Quaternion.identity, transform.parent);
            
            var speed = minAttackSpeed + (PlayerData.I.AttackSpeedLvl * UpgradeIndex);
            var damage = minDamage * PlayerData.I.TotalDamageLvl;
            
            bullet.GetComponent<Bullet>().Init(target, speed, damage);
        }

    }
}
