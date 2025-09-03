using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerBox : MonoBehaviour
{
    protected Action<int> _triggeredAction;

    public void Init(Action<int> action)
    {
        _triggeredAction = action;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy;
        collision.gameObject.TryGetComponent<Enemy>(out enemy);
        if (enemy != null)
        {
            enemy.DestroyEntity();
            _triggeredAction.Invoke(enemy.DamageToPlayer());
        }
    }
}
