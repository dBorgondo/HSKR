using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed;
    public KeyCode Up;
    public KeyCode Down;
    public object OtherPlayer;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(transform.right*Speed);
        if (Input.GetKey(Down))
        {
            transform.Rotate(new Vector3(0, 0, -RotateSpeed));
        }
        else if (Input.GetKey(Up))
        {
            transform.Rotate(new Vector3(0, 0, RotateSpeed));
        }
    }
    void slow()
    {
        Speed -= 100;
        print("Worked");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("speed"))
        {
            print("A");
            Speed += 100;
            Destroy(other.gameObject);
            Invoke("slow", 5);

        }
    }
}
