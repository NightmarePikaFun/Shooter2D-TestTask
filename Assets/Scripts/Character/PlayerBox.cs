using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    private Action _triggeredAction;

    public void Init(Action action)
    {
        _triggeredAction = action;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _triggeredAction.Invoke();
    }
}
