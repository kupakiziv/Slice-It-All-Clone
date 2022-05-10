using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool start = false;
    public static int gold;
    public static int collectedGold;
    public static GameObject knife;
    public Dictionary<GameObject, int> knifesDict;
    public List<GameObject> knifes;
    GameObject currentKnife;
    public ParticleSystem particleEffect;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("knife0") == 0)
        {
            PlayerPrefs.SetInt("knife0", 2);
        }
        gold = PlayerPrefs.GetInt("gold");
    }
    private void Start()
    {
        KnifeSpawn();
    }
    public void KnifeSpawn()
    {
        if (PlayerPrefs.GetInt("knife0") == 2)
        {
            knife = knifes[0];
        }
        else if (PlayerPrefs.GetInt("knife1") == 2)
        {
            knife = knifes[1];
        }
        else if (PlayerPrefs.GetInt("knife2") == 2)
        {
            knife = knifes[2];
        }
        Destroy(currentKnife);
        currentKnife = Instantiate(knife);
    }
}
