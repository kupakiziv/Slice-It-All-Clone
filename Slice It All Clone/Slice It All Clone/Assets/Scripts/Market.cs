using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public TMP_Text goldText, knife0Text, knife1Text, knife2Text;
    public Image knife0Image, knife1Image, knife2Image;
    
    private void Start()
    {
        goldText.text = GameManager.gold.ToString();
        KnifeButtonsShow();
    }
    void KnifeButtonsShow()
    {
        switch(PlayerPrefs.GetInt("knife0"))
        {
            case 0:
                knife0Text.text = "$0";
                break;
            case 1:
                knife0Text.text = "USE";
                knife0Image.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
                break;
            case 2:
                knife0Text.text = "SELECTED";
                knife0Image.color = new Color(1, 0.94f, 0.30f, 0.5f);
                break;
        }
        switch (PlayerPrefs.GetInt("knife1"))
        {
            case 0:
                knife1Text.text = "$500";
                break;
            case 1:
                knife1Text.text = "USE";
                knife1Image.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
                break;
            case 2:
                knife1Text.text = "SELECTED";
                knife1Image.color = new Color(1, 0.94f, 0.30f, 0.5f);
                break;
        }
        switch (PlayerPrefs.GetInt("knife2"))
        {
            case 0:
                knife2Text.text = "$1000";
                break;
            case 1:
                knife2Text.text = "USE";
                knife2Image.color = new Color(0.4f, 0.4f, 0.4f, 0.5f);
                break;
            case 2:
                knife2Text.text = "SELECTED";
                knife2Image.color = new Color(1, 0.94f, 0.30f, 0.5f);
                break;
        }

    }
    public void Knife0Clicked()
    {
        switch (PlayerPrefs.GetInt("knife0"))
        {
            case 1:
                PlayerPrefs.SetInt("knife0", 2);
                if(PlayerPrefs.GetInt("knife1")==2)
                {
                    PlayerPrefs.SetInt("knife1", 1);
                }
                if (PlayerPrefs.GetInt("knife2") == 2)
                {
                    PlayerPrefs.SetInt("knife2", 1);
                }
                break;
            case 2:
                break;
        }
        KnifeButtonsShow();
    }
    public void Knife1Clicked()
    {
        switch (PlayerPrefs.GetInt("knife1"))
        {
            case 0:
                if (GameManager.gold >= 500)
                {
                    GameManager.gold -= 500;
                    goldText.text = GameManager.gold.ToString();
                    PlayerPrefs.SetInt("gold", GameManager.gold);
                    PlayerPrefs.SetInt("knife1", 2);
                    if (PlayerPrefs.GetInt("knife0") == 2)
                    {
                        PlayerPrefs.SetInt("knife0", 1);
                    }
                    if (PlayerPrefs.GetInt("knife2") == 2)
                    {
                        PlayerPrefs.SetInt("knife2", 1);
                    }
                }
                break;
            case 1:
                PlayerPrefs.SetInt("knife1", 2);
                if (PlayerPrefs.GetInt("knife0") == 2)
                {
                    PlayerPrefs.SetInt("knife0", 1);
                }
                if (PlayerPrefs.GetInt("knife2") == 2)
                {
                    PlayerPrefs.SetInt("knife2", 1);
                }
                break;
            case 2:
                break;
        }
        KnifeButtonsShow();
    }
    public void Knife2Clicked()
    {
        switch (PlayerPrefs.GetInt("knife2"))
        {
            case 0:
                if (GameManager.gold >= 1000)
                {
                    GameManager.gold -= 1000;
                    goldText.text = GameManager.gold.ToString();
                    PlayerPrefs.SetInt("gold", GameManager.gold);
                    PlayerPrefs.SetInt("knife2", 2);
                    if (PlayerPrefs.GetInt("knife0") == 2)
                    {
                        PlayerPrefs.SetInt("knife0", 1);
                    }
                    if (PlayerPrefs.GetInt("knife1") == 2)
                    {
                        PlayerPrefs.SetInt("knife1", 1);
                    }
                }
                break;
            case 1:
                PlayerPrefs.SetInt("knife2", 2);
                if (PlayerPrefs.GetInt("knife0") == 2)
                {
                    PlayerPrefs.SetInt("knife0", 1);
                }
                if (PlayerPrefs.GetInt("knife1") == 2)
                {
                    PlayerPrefs.SetInt("knife1", 1);
                }
                break;
            case 2:
                break;
        }
        KnifeButtonsShow();
    }
}
