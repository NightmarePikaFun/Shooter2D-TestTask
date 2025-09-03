using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : PlayerBox
{
    public new void Init(Action<int> action)
    {
        _triggeredAction = action;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet;
        collision.gameObject.TryGetComponent<Bullet>(out bullet);
        if(bullet != null)
        {
            bullet.StoreBullet();
            _triggeredAction.Invoke(bullet.damage);
        }
    }
}
