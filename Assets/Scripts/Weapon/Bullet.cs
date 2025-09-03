using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _moveVector;
    private int _damage;
    private Vector3 _startPoint;
    private int _baseRange = 5;
    private float _coef = 1.0f;

    public void Init(int damage, Vector3 vector)
    {
        _damage = damage;
        _coef = _baseRange/ Vector3.Magnitude(vector);
        _moveVector = vector.normalized;
        transform.position = _moveVector*1.5f;//TODO: add player pos
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
        transform.Translate(_moveVector*_coef);
        if (Vector3.Distance(transform.position, _startPoint) > 20)
            StoreBullet();
    }
}
