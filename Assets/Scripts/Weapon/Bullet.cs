using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _moveVector;
    private int _damage;
    private Vector3 _startPoint;

    public void Init(int damage, Vector3 vector)
    {
        _damage = damage;
        _moveVector = vector.normalized;
        transform.position = _moveVector*2;//TODO: add player pos
        _startPoint = transform.position;
    }


    public void StoreBullet()
    {
        _moveVector = Vector3.zero;
        ObjectPool.Instance.AddBulletToPool(this);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_moveVector);
        if (Vector3.Distance(transform.position, _startPoint) > 20)
            StoreBullet();
    }
}
