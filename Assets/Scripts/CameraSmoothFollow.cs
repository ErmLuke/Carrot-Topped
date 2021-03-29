using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.01F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = (new Vector3(target.transform.position.x - 0f, 0f, 0f));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}