using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveProperty<T>
{
    public T Value {
        get
        {
            return Value;
        }
        set
        {
            Value = value;
            foreach(var sub in Subscribers)
            {
                sub.Invoke(Value);
            }
        }
    }

    private List<Action<T>> Subscribers;
    
    public ReactiveProperty()
    {
        Value = default(T);
        Subscribers = new List<Action<T>>();
    }

    public ReactiveProperty(T value)
    {
        Value = value;
    }

    public void Subscribe(Action<T> action)
    {
        Subscribers.Add(action);
    }

    public void Dispose(Action<T> action)
    {
        if(Subscribers.Contains(action)) 
            Subscribers.Remove(action);
    }
}
