using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerBox _box;
    [SerializeField]
    private PlayerMovment _playerMovment;
    [SerializeField]
    private PlayerAttack _playerAttack;
    private Entity _playerEntity;

    public void Init()
    {
        _playerEntity = new Entity(20);
        _playerEntity.Health.Subscribe(DisplayHealth);
        _box.Init(OnEnemyCollioson);
        _playerAttack.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnemyCollioson()
    {
        _playerEntity.Health.Value -= 1;
    }

    private void DisplayHealth(int value)
    {
        Debug.Log("PH->"+value);
    }
}
