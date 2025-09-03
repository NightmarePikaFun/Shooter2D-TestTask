using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    public bool canMove = false;
    #if UNITY_ANDROID
    private Vector2 touchStartPos;
    private Vector2 secondTouchPos;
    #endif

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;
#if !UNITY_ANDROID
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
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && Input.touchCount == 1)
            {
                touchStartPos = touch.position;
            }
            if(touch.phase == TouchPhase.Moved)
            {
                secondTouchPos = touch.position;
            }
            Vector2 movePos = secondTouchPos - touchStartPos;
            movePos = Vector2.ClampMagnitude(movePos, 100);
            movePos = movePos / 100;
            transform.Translate(movePos * speed * 0.15f);
        }
#endif
    }
}
