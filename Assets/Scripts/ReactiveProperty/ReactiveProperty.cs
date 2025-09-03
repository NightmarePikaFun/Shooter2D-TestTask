using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveProperty<T>
{
    private T _value;
    public T Value {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            foreach(var sub in Subscribers)
            {
                sub.Invoke(_value);
            }
        }
    }

    private List<Action<T>> Subscribers = new List<Action<T>>();
    
    public ReactiveProperty()
    {
        _value = default(T);
    }

    public ReactiveProperty(T value)
    {
        _value = value;
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
