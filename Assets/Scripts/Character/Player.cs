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
    private Entity _playerEntity;

    public void Init()
    {
        Instance = this;
        _playerEntity = new Entity(20);
        _playerEntity.Health.Subscribe(DisplayHealth);
        _box.Init(OnEnemyCollioson);
        _playerAttack.Init();
    }

    private void OnEnemyCollioson(int value)
    {
        _playerEntity.Health.Value -= value;
    }

    private void DisplayHealth(int value)
    {
        Debug.Log("PH->"+value);
    }
}
