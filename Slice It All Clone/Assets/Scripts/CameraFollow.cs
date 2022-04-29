using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    public Transform playerTransform;
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z - 2f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

    }
}
