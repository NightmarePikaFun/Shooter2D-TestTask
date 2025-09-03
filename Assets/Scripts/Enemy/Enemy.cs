using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Entity entity { get; private set; } 
    private EnemyMove _moveLogic;
    private Transform _target;
    private float _speed = 0.05f;

    public Action Init(Transform target)
    {
        entity = new Entity(10);
        _target = target;
        _moveLogic = new EnemyMove(_target, transform);
        return _moveLogic.ActivateMove;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveLogic.canMove)
        {
            transform.Translate(_moveLogic.GetMoveVector() * _speed);
        }
    }
}
