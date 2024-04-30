using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelGold : MonoBehaviour
{

    public int levelGold = 0;

    public int minGold = 30;
    public int maxGold = 10;
    private TMP_Text levelGoldText;


    void Start ()
    {
        levelGold = 0;
        levelGoldText = GameObject.Find("LevelGoldText").GetComponent<TextMeshProUGUI>();
        levelGoldText.text = "Gold: " + levelGold;
    }

    public void IncreaseGold()
    {
        int randomAmount = Random.Range(minGold, maxGold +1);
        levelGold += randomAmount;
        levelGoldText.text = "Gold: " + levelGold;
    }   




}
