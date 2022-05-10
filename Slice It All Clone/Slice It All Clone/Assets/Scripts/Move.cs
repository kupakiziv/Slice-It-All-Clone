using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    bool touched;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && GameManager.start)
        {
            touched = true;
            rb.isKinematic = false;
            rb.velocity = new Vector3(0,5,2);
            rb.angularVelocity = new Vector3(6.6f,0,0);
        }
        if (touched)
        {
            rb.isKinematic = false;
            Invoke("TouchedFalse", 0.1f);
        }
    }
    public void KnifeStartingPosition()
    {
        transform.position = new Vector3(0, 2, -22f);
        transform.eulerAngles = new Vector3(41, 0, 0);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    void TouchedFalse()
    {
        touched = false;
    }
        
}
