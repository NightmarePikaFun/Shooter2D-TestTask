using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponAttack
{
    public abstract void DoAttack(Vector3 attackVector);
}
