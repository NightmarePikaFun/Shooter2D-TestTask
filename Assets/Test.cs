using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Enemy enemy;
    public Transform player;

    private Action testAct;
    private void Awake()
    {
        testAct = enemy.Init(player);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy.entity.Health.Subscribe(DisplayHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            testAct.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.H)) 
        {
            enemy.entity.Health.Value -= 1;
        }
    }

    private void DisplayHealth(int value)
    {
        Debug.Log(value);
    }
}
