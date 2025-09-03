using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _moveVector;
    private int _damage;

    public void Init(int damage, Vector3 vector)
    {
        _damage = damage;
        _moveVector = vector;
        transform.position = _moveVector*2;//TODO: add player pos
    }


    public void StoreBullet() => _moveVector = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_moveVector);
    }
}
