using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHit : MonoBehaviour
{
    public Rigidbody knifeRb;
    public Transform knifeTransform;
    UIManager uiManager;

    private void Start()
    {
        uiManager = Object.FindObjectOfType<UIManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blankSpace" || other.gameObject.tag == "thorn")
        {
            Object.FindObjectOfType<AudioManager>().cutFailVoice.Play();
            uiManager.LosePanel();
        }
        else if (other.gameObject.tag == "plane")
        {
            knifeRb.isKinematic = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "object" || other.gameObject.tag == "finish")
        {
            Object.FindObjectOfType<AudioManager>().cutFailVoice.Play();
            StartCoroutine(IsTriggerCloseOpen(other.gameObject));
        }
    }
    private IEnumerator IsTriggerCloseOpen(GameObject other)
    {
        other.GetComponent<BoxCollider>().isTrigger = false;
        knifeRb.velocity = new Vector3(0, 2, -1.5f);
        knifeRb.angularVelocity = new Vector3(6f, 0, 0);
        yield return new WaitForSeconds(0.3f);
        if (other != null)
        {
            other.GetComponent<BoxCollider>().isTrigger = true;
        }
        
    }

}
