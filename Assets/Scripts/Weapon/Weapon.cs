using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create weapon", order = 1)]
public class Weapon : ScriptableObject, IWeaponAttack
{
#if UNITY_EDITOR
    [field: SerializeField] public MonoScript WeaponScript { get; private set; }
#endif
    [SerializeField]
    private string ClassName;
    [SerializeField]
    private string Name;
    [SerializeField]
    protected int Damage;
    [SerializeField]
    private float attackTime = 0.5f;
    [SerializeField]
    public Sprite weaponSprite;

    private IWeaponAttack weaponAttack;

    public float GetAttackTime() => attackTime;

    public virtual void DoAttack(Vector3 attackVector)
    {

        weaponAttack.DoAttack(attackVector);
    }

    public void CreateInstance()
    {
#if UNITY_EDITOR
        Type wsType = WeaponScript.GetClass();
        ClassName = wsType.AssemblyQualifiedName;
        EditorUtility.SetDirty(this);
#endif
        if (string.IsNullOrEmpty(ClassName))
            ClassName = "Pistol, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        Weapon tmp = (Weapon)Activator.CreateInstance(Type.GetType(ClassName));
        
        tmp.Name = Name;
        tmp.Damage = Damage;
        tmp.attackTime = attackTime;
        tmp.weaponSprite = weaponSprite;
        weaponAttack = tmp as IWeaponAttack;
    }
}
