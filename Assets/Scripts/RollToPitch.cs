using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollToPitch : MonoBehaviour
{
    public AudioSource rollNoise;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            rollNoise.pitch = rb.velocity.magnitude*2;
        }
        else if (rb.velocity.magnitude < 0)
        {
            rollNoise.pitch = (rb.velocity.magnitude*2) * -1;
        }

        if (rollNoise.pitch > 1)
        {
            rollNoise.pitch = 1;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        float collisionForce = collision.impulse.magnitude / Time.fixedDeltaTime;


        if (collision.collider.tag == "Obstacle")
        {
            if (collisionForce > 100f)
            {
                Soundmanager.PlaySound("canHit");
            }
        }
        if (collision.collider.tag == "Floor")
        {
            rollNoise.volume = 2f;
        }

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            rollNoise.volume = 0f;
        }
    }

}
