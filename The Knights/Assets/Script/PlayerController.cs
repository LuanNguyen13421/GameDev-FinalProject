using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;
    Vector2 faceDirection = Vector2.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 temp = direction;
        if (direction == Vector2.zero && temp != Vector2.zero)
        {
            faceDirection = temp;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
