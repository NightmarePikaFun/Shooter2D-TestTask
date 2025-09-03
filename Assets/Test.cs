using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Entity test;
    // Start is called before the first frame update
    void Start()
    {
        test = new Entity(10);
        test.Health.Subscribe(DisplayHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            test.Health.Value += 1;
        }
        if(Input.GetKeyDown(KeyCode.H)) 
        {
            test.Health.Value -= 1;
        }
    }

    private void DisplayHealth(int value)
    {
        Debug.Log(value);
    }
}
