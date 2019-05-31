using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private BoxCollider MovingPoint;
    private bool HasCollided;
    public float CameraSpeed;

    void Start()
    {
        HasCollided = false;
        MovingPoint = GetComponent<BoxCollider>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
            if ((other.GetComponent<Rigidbody2D>().velocity.x>0)&(other.gameObject.CompareTag("Player"))&(HasCollided==false))
            {
                transform.position = new Vector3(transform.position.x + (other.GetComponent<Rigidbody2D>().velocity.x) / (100-CameraSpeed), transform.position.y, transform.position.z);
                HasCollided = true;
            }
    }

    void Update()
    {
        HasCollided = false;

    }
}