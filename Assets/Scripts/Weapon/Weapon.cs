using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create weapon", order = 1)]
public class Weapon : ScriptableObject, IWeaponAttack
{
    [field: SerializeField] public MonoScript WeaponScript { get; private set; }
    [SerializeField]
    private string Name;
    [SerializeField]
    protected int Damage;
    [SerializeField]
    private float attackTime = 0.5f;
    [SerializeField]
    public Sprite weaponSprite;

    private IWeaponAttack weaponAttack;

    public virtual void DoAttack(Vector3 attackVector)
    {

        weaponAttack.DoAttack(attackVector);
    }

    public void CreateInstance()
    {
        Type wsType = WeaponScript.GetClass();
        Weapon tmp = (Weapon)Activator.CreateInstance(Type.GetType(wsType.AssemblyQualifiedName));
        weaponAttack = tmp as IWeaponAttack;
    }
}
