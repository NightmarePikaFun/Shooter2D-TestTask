using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField]
    private PlayerBox _box;
    [SerializeField]
    private PlayerMovment _playerMovment;
    [SerializeField]
    private PlayerAttack _playerAttack;
    [SerializeField]
    private HealthBar _healthBar;
    private Entity _playerEntity;

    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        _playerEntity = new Entity(20);
        _playerEntity.Health.Subscribe(_healthBar.Init(_playerEntity.Health.Value));
        _box.Init(OnEnemyCollioson);
        _playerAttack.Init();
    }

    private void OnEnemyCollioson(int value)
    {
        _playerEntity.Health.Value -= value;
    }
}
