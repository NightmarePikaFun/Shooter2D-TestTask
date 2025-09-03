using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove
{
    public bool canMove { get; private set; } = false;

    private Transform _target;
    private Transform _enemy;

    public EnemyMove(Transform target, Transform enemy)
    {
        _target = target;
        _enemy = enemy;
    }

    public Vector3 GetMoveVector()
    {
        return Vector3.Normalize(_target.position - _enemy.position);
    }

    public void ActivateMove() => canMove = true;

}
