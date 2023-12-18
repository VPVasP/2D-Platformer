using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI coinsText; //refrence to our coins text
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        coinsText.text = "Coins: " + CurrencyManager.instance.currentCoins.ToString(); //we set the text value to our current coins from currency manager
    }
    public void UpdateCoinsUI()
    {
        coinsText.text ="Coins: " + CurrencyManager.instance.currentCoins.ToString();
}
}
