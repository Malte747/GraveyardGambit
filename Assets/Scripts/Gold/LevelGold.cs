using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelGold : MonoBehaviour
{

    public int levelGold = 0;

    public int minGold = 30;
    public int maxGold = 10;
    private TMP_Text levelGoldText;
    Upgrades upgrades;
    SzeneManager szeneManager;


    void Start ()
    {
        levelGold = 0;
        levelGoldText = GameObject.Find("LevelGoldText").GetComponent<TextMeshProUGUI>();
        upgrades = GameObject.Find("PlayerData").GetComponent<Upgrades>();
        szeneManager = GameObject.Find("PlayerData").GetComponent<SzeneManager>();
        levelGoldText.text = "Gold: " + levelGold;
    }

    public void IncreaseGold()
    {
        int randomAmount = Random.Range(minGold, maxGold +1);
        levelGold += randomAmount;
        levelGoldText.text = "Gold: " + levelGold;
    }   

    public void LoseGame()
    {
        levelGold = 0;
        levelGoldText.text = "Gold: " + levelGold;
        szeneManager.LoadMenu();
        upgrades.LoseALife();
    }

    public void WinGame()
    {
        upgrades.AddGold();
        szeneManager.RaidCount();
        szeneManager.LoadMenu();
    }




}
