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
            bullet.Init(Damage, CalcPosition(attackVector, bulletPadding*(counter+i)));
            bullet.gameObject.SetActive(true);
        }
    }

    private Vector3 CalcPosition(Vector3 vector, float angle)
    {
        float x = vector.x*Mathf.Cos(angle)-vector.y*Mathf.Sin(angle);
        float y = vector.x*Mathf.Sin(angle)+vector.y*Mathf.Cos(angle);
        return new Vector3(x, y); 
    }
}
