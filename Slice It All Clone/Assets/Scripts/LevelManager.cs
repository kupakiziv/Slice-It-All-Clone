using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels = new GameObject[5];
    public int currentLevelNumber = 0;
    public GameObject currentlevel;

    public void Start()
    {
        currentlevel = Instantiate(Levels[0]);
    }

    public void Nextlvl()
    {
        Destroy(currentlevel);
        currentLevelNumber++;
        if(currentLevelNumber > Levels.Length-1)
        {
            currentLevelNumber = 0;
        }
        currentlevel = Instantiate(Levels[currentLevelNumber]);
        FindObjectOfType<Move>().KnifeStartingPosition();

    }
    public void Restartlvl()
    {
        Destroy(currentlevel);
        currentlevel = Instantiate(Levels[currentLevelNumber]);
        FindObjectOfType<Move>().KnifeStartingPosition();
    }
}
