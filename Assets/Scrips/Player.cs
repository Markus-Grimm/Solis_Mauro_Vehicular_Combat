using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    float accelpower = 5f;
    [SerializeField]
    float steeringpower = 5f;
    float steeringAmount, speed, direction;

    public GameController a;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GameController.FindObjectOfType<GameController>();

    }

    void Update()
    {
        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accelpower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringpower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
                        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Object")
        {
            a.AumentoScore();
        }
    }
}
