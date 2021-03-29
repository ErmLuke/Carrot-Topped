using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifeTime = 15;
    private float actualTime;
    private Rigidbody rb;
    public bool isObstacle;
    public bool isRollingPin;
    public bool isCanOne;
    public bool isCanTwo;
    public bool isNani;

    void Start()
    {

    }
    void Update()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (isCanOne)
        {
            rb.AddForce(700, -3, 0, ForceMode.Impulse);
            isCanOne = false;
        }
        if (isCanTwo)
        {
            rb.AddForce(100, -3, 0, ForceMode.Impulse);
            isCanTwo = false;
        }
        if (isNani)
        {
            rb.AddForce(1000, -3, 0, ForceMode.Impulse);
            isNani = false;
        }
        if (isRollingPin)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
            rb.AddForce(600, -3, 0, ForceMode.Impulse);
            isRollingPin = false;
        }

        actualTime += Time.deltaTime;
        if (lifeTime < actualTime)
        {
            Destroy(gameObject);
        }
    }
}
