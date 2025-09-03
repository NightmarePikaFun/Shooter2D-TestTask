using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerBox box;
    [SerializeField]
    private float speed = 1.0f;

    private Entity playerEntity;

    public void Init()
    {
        playerEntity = new Entity(20);
        playerEntity.Health.Subscribe(DisplayHealth);
        box.Init(OnEnemyCollioson);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            transform.Translate(Vector3.up * speed*0.05f);
        }
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            transform.Translate(Vector3.down * speed * 0.05f);
        }
    }

    private void OnEnemyCollioson()
    {
        playerEntity.Health.Value -= 1;
    }

    private void DisplayHealth(int value)
    {
        Debug.Log("PH->"+value);
    }
}
