using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : Weapon
{
    [SerializeField]
    private int bulletCount = 5;
    public void Attack(Vector3 attackVector, int damage)
    {
        float bulletPadding = 0.1f;
        for (int i = 0; i < bulletCount; i++)
        {
            Bullet bullet = ObjectPool.Instance.GetBullet();
            bullet.Init(damage, attackVector+new Vector3(bulletPadding*i,0,0));//TODO: Tmp padding
            bullet.gameObject.SetActive(true);
        }
    }
}
