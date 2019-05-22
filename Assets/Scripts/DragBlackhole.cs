using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlackhole : MonoBehaviour
{
    public float GravityForce;
    private CircleCollider2D Event;
    // Start is called before the first frame update
    void Start()
    {
        Event = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().AddForce((transform.position - other.transform.position).normalized*(GravityForce/ ((transform.position - other.transform.position).magnitude)));

    }
}
