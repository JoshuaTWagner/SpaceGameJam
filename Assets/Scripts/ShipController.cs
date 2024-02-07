using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipController : MonoBehaviour
{

    Rigidbody2D rb2d;
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    Vector2 moveVector;
    public float rotationSpeed;
    public float moveSpeed;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        GetBodyMovement();
        rb2d.velocity = (Vector2)transform.up * moveVector.y * moveSpeed * Time.deltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -moveVector.x * rotationSpeed * Time.deltaTime));

        // if (Input.GetKey(KeyCode.W))
        // {
        //     rb2d.velocity = Vector2.up;
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     rb2d.velocity = Vector2.down;
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * -1));
        // }
    }
    private void GetBodyMovement()
    {  
        moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMoveBody?.Invoke(moveVector.normalized);
    }
    public void HandleMoveBody(Vector2 moveVector)
    {
        this.moveVector = moveVector;
    }
}
