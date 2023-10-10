using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    public float tiltAngle = 30.0f;
    public float velocity = 2.4f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }


    }
    void FixedUpdate()
    {
        float clampedVerticalVelocity = Mathf.Clamp(rb.velocity.y, -velocity, velocity);
        float tiltZ = (clampedVerticalVelocity / velocity) * tiltAngle;

        if (clampedVerticalVelocity != 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, tiltZ);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

}
