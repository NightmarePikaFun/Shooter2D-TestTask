using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyBox _entityBox;
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private SpriteRenderer _sprite;

    public Entity entity { get; private set; }

    private EnemyBase _enemyBase;
    private EnemyMove _moveLogic;
    private Transform _target;
    private float _speed = 0.05f;
    private int _damage = 1;

    public Action Init(EnemyBase enemyBase,  Transform target)
    {
        _enemyBase = enemyBase;
        entity = new Entity(_enemyBase.HP);
        _speed = _enemyBase.Speed;
        _damage = _enemyBase.Damage;
        _sprite.sprite = _enemyBase.Image;
        entity.Health.Subscribe(healthBar.Init(entity.Health.Value));
        _entityBox.Init(GetDamage);
        _target = target;
        _moveLogic = new EnemyMove(_target, transform);
        return _moveLogic.ActivateMove;
    }

    public void DestroyEntity()
    {
        ObjectPool.Instance.AddEnemyToPool(this);
        GameManager.Instance.RemoveEnemy(this);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_moveLogic.canMove)
        {
            transform.Translate(_moveLogic.GetMoveVector() * _speed);
        }
    }

    public int DamageToPlayer() => _damage;

    private void GetDamage(int value)
    {
        Debug.Log(value);
        entity.ChangeHealth(-value);
        if(entity.Health.Value <= 0)
        {
            DestroyEntity();
        }
    }
}
