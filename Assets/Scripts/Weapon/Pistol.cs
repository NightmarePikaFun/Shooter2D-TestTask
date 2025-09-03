using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Attack(Vector3 attackVector)
    {
        Bullet bullet = ObjectPool.Instance.GetBullet();
        bullet.Init(Damage, attackVector);
        bullet.gameObject.SetActive(true);
    }
}
