using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEffects : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddTorque(initialRotation);
    }

}
