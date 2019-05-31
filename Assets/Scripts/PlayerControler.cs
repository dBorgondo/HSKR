using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float Speed;
    private float initialSpeed;
    private float fuel;
    public float RotateSpeed;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Use;
    public KeyCode Booster;
    public GameObject Bomb;
    public GameObject littleFuel;
    public object OtherPlayer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private string bonusUp;
    private bool damaged;
    void Start()
    {
        bonusUp="None";
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        damaged = false;
        initialSpeed = Speed;
    }

    void Update()
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
        if (Input.GetKeyDown(Use))
        {
            switch (bonusUp)
            {
                case "Bomb":
                    Instantiate(Bomb, new Vector3(transform.position.x-(transform.right.x*1.2f),transform.position.y - (transform.right.y*1.2f), 0), Quaternion.identity);
                    print("created");
                    bonusUp = "None";
                    break;
                default:
                    break;
          
            }
        }
        if ((Input.GetKeyDown(Booster)) & (fuel > 0))
        {
            anim.SetBool("isBoosted", true);
            Speed *= 1.5f;
        }
        if ((Input.GetKey(Booster)))
        {
            if (fuel > 0)
            {
                fuel -= 0.5f;
                print(fuel);
                if (((fuel % 30)==0)&(fuel!=0))
                {
                    Instantiate(littleFuel, new Vector3(transform.position.x - (transform.right.x * 1.2f), transform.position.y - (transform.right.y * 1.2f), 0), Quaternion.identity);
                }
            }
        }
        if ((Input.GetKeyUp(Booster)) ^ (fuel == 0))
        {
            anim.SetBool("isBoosted", false);
            Speed = initialSpeed;
        }
        if (damaged)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("speed"))
        {
            fuel += 40;
            if (fuel > 100)
            {
                fuel = 100;
            }
            Destroy(other.gameObject);
            //anim.SetBool("isBoosted", true);
            //Invoke("resetSpeed", 5);

        }
        if (other.gameObject.CompareTag("bomb"))
        {
            bonusUp="Bomb";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("mine"))
        {
            damaged = true;
            Speed *= 0.65f;
            Destroy(other.gameObject);
            Invoke("resetSpeed", 5);
        }
    }

    void resetSpeed()
    {
        Speed = initialSpeed;
        anim.SetBool("isBoosted", false);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
