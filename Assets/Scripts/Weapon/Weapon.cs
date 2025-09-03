using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create weapon", order = 1)]
public class Weapon : WeaponBase<Pistol>, IWeaponAttack
{
    [SerializeField]
    private string Name;
    [SerializeField]
    protected int Damage;
    [SerializeField]
    public Sprite weaponSprite;

    public virtual void Attack(Vector3 attackVector)
    {
        Debug.Log("Attack!");
    }
}
