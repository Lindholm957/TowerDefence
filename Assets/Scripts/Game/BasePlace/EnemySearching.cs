using Game.Data;
using UnityEngine;

namespace Game.BasePlace
{
    public class EnemySearching : MonoBehaviour
    {
        [SerializeField] private float minAttackDistance = 200f;
        
        private const float UpgradeIndex = 100f;

        public GameObject[] GetAllEnemies()
        {
            var objects = GameObject.FindGameObjectsWithTag("Enemy");
            return objects.Length > 0 ? objects : null;
        }

        public GameObject DefineTarget(GameObject[] enemies)
        {
            var target = enemies[0];
            var attackDistance = minAttackDistance + (PlayerData.I.AttackDistanceLvl * UpgradeIndex);
            var minDistanceToEnemy = CalculateDistance(gameObject, enemies[0]);

            foreach (var enemy in enemies)
            {
                var distance = CalculateDistance(gameObject, enemy);
                if (distance < minDistanceToEnemy)
                {
                    minDistanceToEnemy = distance;
                    target = enemy;
                }
            }

            if (minDistanceToEnemy >= attackDistance)
            {
                target = null;
            }
            
            return target;
        }

        private float CalculateDistance(GameObject a, GameObject b)
        {
            var aRectPosition = new Vector2(a.transform.position.x, a.transform.position.y);
            var bRectPosition = new Vector2(b.transform.position.x, b.transform.position.y);

            return Vector2.Distance(aRectPosition, bRectPosition);
        }
    }
}
