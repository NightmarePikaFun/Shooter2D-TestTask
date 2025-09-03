using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerBox : MonoBehaviour
{
    protected Action<int> _triggeredAction;

    public void Init(Action<int> action)
    {
        _triggeredAction = action;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DestroyEntity();
            _triggeredAction.Invoke(1);
        }
    }
}
