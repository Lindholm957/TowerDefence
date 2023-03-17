using System;
using UnityEngine;

namespace Game.Bullet
{
    public class Bullet : MonoBehaviour
    {
        public void SetRotationToTarget(GameObject target)
        {
            var bulletStartPos = new Vector2(transform.position.x, transform.position.y);
            
            var dir = target.transform.position - transform.position;
            dir = target.transform.InverseTransformDirection(dir);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            
            transform.Rotate(0, 0, angle);
            Debug.Log(angle);
        }
    }
}