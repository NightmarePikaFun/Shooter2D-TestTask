using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    public bool canMove = false;
    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * 0.05f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * 0.05f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * 0.05f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * 0.05f);
        }
    }
}
