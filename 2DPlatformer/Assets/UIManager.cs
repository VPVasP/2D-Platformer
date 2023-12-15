using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        coinsText.text = "Coins: " + CurrencyManager.instance.currentCoins.ToString();
    }
    public void UpdateCoinsUI()
    {
        coinsText.text ="Coins: " + CurrencyManager.instance.currentCoins.ToString();
}
}
