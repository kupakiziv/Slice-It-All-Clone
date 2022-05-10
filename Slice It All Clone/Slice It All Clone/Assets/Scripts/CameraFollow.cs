using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed;
    public Transform playerTransform;
    private void Start()
    {
        playerTransform = FindObjectOfType<Move>().transform;
    }
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, playerTransform.position.y + 1.5f, playerTransform.position.z - 2f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            playerTransform = FindObjectOfType<Move>().transform;
        }

    }
}
