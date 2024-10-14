using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 3.0f;
    private bool isWalking;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +0.1f;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10.0f;
        isWalking = moveDirection != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
        Debug.Log(inputVector);
        Debug.Log(moveDirection);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
