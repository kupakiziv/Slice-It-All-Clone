using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject winPanel, losePanel, marketPanel, startPanel, restart;
    public TMP_Text goldText, marketGoldText, currentLevelText, collectedGoldText;
    public GameObject goldImage;
    LevelManager levelManager;
    GameManager gameManager;
    public List<Transform> goldTransformList;
    bool isWin;
    float a = 0;
    private void Start()
    {
        goldText.text = GameManager.gold.ToString();
        levelManager = Object.FindObjectOfType<LevelManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        currentLevelText.text = (levelManager.currentLevelNumber + 1).ToString() + ". LEVEL";
    }
    private void Update()
    {
        if (isWin)
        {
            a = Mathf.Lerp(a, GameManager.collectedGold, 0.005f);
            collectedGoldText.text = "+" + ((int)(a + 1)).ToString();
        }
    }
    public void WinPanel()
    {
        isWin = true;
        restart.SetActive(false);
        winPanel.SetActive(true);
        GameManager.start = false;
        StartCoroutine(GoldSpawn());
        GameManager.gold += GameManager.collectedGold;
        PlayerPrefs.SetInt("gold", GameManager.gold);
        goldText.text = GameManager.gold.ToString();


    }
    public void LosePanel()
    {
        restart.SetActive(false);
        losePanel.SetActive(true);
        GameManager.start = false;
    }
    public void NextButtonClicked()
    {

        winPanel.SetActive(false);
        startPanel.SetActive(true);
        restart.SetActive(false);
        FindObjectOfType<Move>().rb.isKinematic = false;
        levelManager.Nextlvl();
        currentLevelText.text = (levelManager.currentLevelNumber + 1).ToString() + ". LEVEL";
    }
    public void RestartButtonClicked()
    {
        GameManager.start = false;
        losePanel.SetActive(false);
        startPanel.SetActive(true);
        restart.SetActive(false);
        levelManager.Restartlvl();
        currentLevelText.text = (levelManager.currentLevelNumber + 1).ToString() + ". LEVEL";
    }
    public void MarketPanel()
    {
        marketGoldText.text = GameManager.gold.ToString();
        startPanel.SetActive(false);
        marketPanel.SetActive(true);
        GameManager.start = false;
    }
    public void ExitMarketPanel()
    {
        startPanel.SetActive(true);
        marketPanel.SetActive(false);
        startPanel.SetActive(true);
        gameManager.KnifeSpawn();
    }
    public void StartClicked()
    {
        a = 0;
        isWin = false;
        GameManager.collectedGold = 0;
        restart.SetActive(true);
        startPanel.SetActive(false);
        GameManager.start = true;
    }
    public void Gold()
    {
        GameManager.collectedGold += 1;
        GameManager.gold += 1;
        PlayerPrefs.SetInt("gold", GameManager.gold);
        goldText.text = GameManager.gold.ToString();
    }
    private IEnumerator GoldSpawn()
    {
        foreach(Transform t in goldTransformList)
        {
            GameObject gold = Instantiate(goldImage, t.transform.position, Quaternion.identity, t.parent);
            Destroy(gold,4f);
            yield return new WaitForSeconds(0.2f);
        }
    }

}
