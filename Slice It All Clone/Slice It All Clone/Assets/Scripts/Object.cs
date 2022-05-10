using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject halfForm;
    public void Split(GameObject other)
    {
        GameObject halfObj = Instantiate(halfForm, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), halfForm.transform.rotation);
        halfObj.transform.SetParent(other.gameObject.transform.parent);
        foreach (Transform child in halfObj.transform)
        {
            if(child.gameObject.tag == "right")
                child.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);
            if (child.gameObject.tag == "left")
                child.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 0);
        }

    }
}
