using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public ReactiveProperty<int> Health { get; private set; }
    
    public Entity(int helath)
    {
        Health = new ReactiveProperty<int>(helath);
    }

    public void ChangeHealth(int value)
    {
        Health.Value += value;
    }
}
