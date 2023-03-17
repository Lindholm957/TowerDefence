using UnityEngine;

namespace Game.BasePlace
{
    public class EnemySearching : MonoBehaviour
    {
        public GameObject[] GetAllEnemies()
        {
            var objects = GameObject.FindGameObjectsWithTag("Enemy");
            return objects.Length > 0 ? objects : null;
        }

        public GameObject DefineTarget(GameObject[] enemies)
        {
            var target = new GameObject();
            var minDistance = CalculateDistance(gameObject, enemies[0]);
            
            foreach (var enemy in enemies)
            {
                var distance = CalculateDistance(gameObject, enemy);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = enemy;
                }
            }

            return target;
        }

        private float CalculateDistance(GameObject a, GameObject b)
        {
            var aRectPosition = a.GetComponent<RectTransform>().anchoredPosition;
            var bRectPosition = b.GetComponent<RectTransform>().anchoredPosition;

            return Vector2.Distance(aRectPosition, bRectPosition);
        }
    }
}
