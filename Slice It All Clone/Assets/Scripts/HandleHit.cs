using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHit : MonoBehaviour
{
    public Rigidbody knifeRb;
    public Transform knifeTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            knifeRb.isKinematic = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "object")
        {
            StartCoroutine(IsTriggerCloseOpen(other.gameObject));
        }
    }
    private IEnumerator IsTriggerCloseOpen(GameObject other)
    {
        other.GetComponent<BoxCollider>().isTrigger = false;
        knifeRb.velocity = new Vector3(0, 2, -1.5f);
        knifeRb.angularVelocity = new Vector3(6f, 0, 0);
        yield return new WaitForSeconds(0.3f);
        other.GetComponent<BoxCollider>().isTrigger = true;
    }

}
