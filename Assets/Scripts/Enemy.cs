using System;
using Events.Base;
using Events.Systems;
using Game;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _hp = 20f;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        var damage = col.GetComponent<Bullet>().Damage;
        TakeDamage(damage);
    }

    private void OnDestroy()
    {
        GlobalEventSystem.I.SendEvent(EventNames.Enemy.Died, new GameEventArgs(null));
    }
}