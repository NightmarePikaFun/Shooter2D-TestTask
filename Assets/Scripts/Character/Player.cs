using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerBox box;
    [SerializeField]
    private PlayerMovment playerMovment;

    private Entity _playerEntity;

    public void Init()
    {
        _playerEntity = new Entity(20);
        _playerEntity.Health.Subscribe(DisplayHealth);
        box.Init(OnEnemyCollioson);
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
