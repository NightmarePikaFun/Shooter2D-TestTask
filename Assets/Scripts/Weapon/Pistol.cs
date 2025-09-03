using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon, IWeaponAttack
{
    public override void DoAttack(Vector3 attackVector)
    {
        Debug.Log("Pistol attack");
        Bullet bullet = ObjectPool.Instance.GetBullet();
        if(bullet == null )
            return;
        bullet.Init(Damage, attackVector);
        bullet.gameObject.SetActive(true);
    }
}
