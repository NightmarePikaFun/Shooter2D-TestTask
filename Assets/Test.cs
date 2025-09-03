using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Player player;

    private Action testAct;
    private void Awake()
    {
        //testAct = enemy.Init(player.transform);
        player.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            testAct.Invoke();
        }
    }

    private void DisplayHealth(int value)
    {
        Debug.Log(value);
    }
}
