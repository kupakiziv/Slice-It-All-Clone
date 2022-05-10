using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingEdgeHit : MonoBehaviour
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
            Object.FindObjectOfType<GameManager>().particleEffect.Stop();
            uiManager.LosePanel();
        }
        else if (other.gameObject.tag == "object")
        {
            uiManager.Gold();
            knifeRb.angularVelocity = new Vector3(0, 0, 0);
            other.GetComponent<Object>().Split(other.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "finish")
        {
            FindObjectOfType<Move>().transform.GetChild(3).gameObject.SetActive(false);
            knifeRb.isKinematic = true;
            switch (other.gameObject.name)
            {
                case "1x":
                    GameManager.collectedGold *= 1;
                    break;
                case "10x":
                    GameManager.collectedGold *= 10;
                    break;
                case "2x":
                    GameManager.collectedGold *= 2;
                    break;
                case "50x":
                    GameManager.collectedGold *= 50;
                    break;
                case "6x":
                    GameManager.collectedGold *= 6;
                    break;
                case "12x":
                    GameManager.collectedGold *= 12;
                    break;
                case "5x":
                    GameManager.collectedGold *= 5;
                    break;
            }
            
            uiManager.WinPanel();
        }
        else if (other.gameObject.tag == "plane")
        {
            FindObjectOfType<Move>().transform.GetChild(3).gameObject.SetActive(false);
            knifeRb.isKinematic = true;
        }
    }
}

