using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingEdgeHit : MonoBehaviour
{
    public Rigidbody knifeRb;
    public Transform knifeTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            knifeRb.isKinematic = true;
        }
        if (other.gameObject.tag == "object")
        {
            knifeRb.angularVelocity = new Vector3(0, 0, 0);
            other.GetComponent<Object>().Split(other.gameObject);
            Destroy(other.gameObject);

        }
    }  
}

