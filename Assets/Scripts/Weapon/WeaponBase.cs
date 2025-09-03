using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class WeaponBase<T> : ScriptableObject where T : class
{
    [field: SerializeField] public MonoScript MonoScript { get; private set; }
    public Type ClassType => typeof(T);
}
