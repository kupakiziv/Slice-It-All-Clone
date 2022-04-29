using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _rb.isKinematic = false;
            _rb.velocity = new Vector3(0,5,2);
            _rb.angularVelocity = new Vector3(6.6f,0,0);
        }
    }
}
