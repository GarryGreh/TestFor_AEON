using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    private float h, v;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        h = InputController.inputController.Horizontal;
        v = InputController.inputController.Vertical;
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(h * speed, rb.velocity.y, v * speed);
        rb.AddForce(move);
    }
}
