using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float controllerPosX { get { return transform.position.x; } }
    public float controllerPosY { get { return transform.position.y; } }
    Rigidbody2D rb;
    Vector2 direction;
    Vector2 faceDirection = Vector2.zero;
    public float horizontal;
    public float vertical;
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    public void PlayerTransform(float x, float y)
    {
        rb.position.Set(x,y);
    }
    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
