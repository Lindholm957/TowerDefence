using UnityEngine;

namespace Game.BasePlace
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;

        public void Shoot(GameObject target)
        {
            var bulletStartPos = new Vector2(transform.position.x, transform.position.y);

            var bullet = Instantiate(bulletPrefab, bulletStartPos,
                Quaternion.identity, transform.parent);

            bullet.GetComponent<Bullet>().Init(target, 20f, 10f);
        }

    }
}
