using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create enemy", order = 1)]
public class EnemyBase : ScriptableObject
{
    [field: SerializeField]
    public int HP { get; private set; }
    [field: SerializeField]
    public int Damage { get; private set; }
    [field: SerializeField]
    public float Speed { get; private set; }
    [field: SerializeField]
    public Sprite Image { get; private set; }

}
