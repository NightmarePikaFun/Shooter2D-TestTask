using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : Weapon, IWeaponAttack
{
    [SerializeField]
    private int bulletCount = 5;
    public override void DoAttack(Vector3 attackVector)
    {
        float bulletPadding = 0.15f;
        int counter = -bulletCount / 2;
        for (int i = 0; i < bulletCount; i++)
        {
            Bullet bullet = ObjectPool.Instance.GetBullet();
            bullet.Init(Damage, MathH.RotatePositionOnCircle(attackVector, bulletPadding*(counter+i)));
            bullet.gameObject.SetActive(true);
        }
    }
}
