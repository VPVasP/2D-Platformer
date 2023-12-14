using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int currentCoins;
    private string coins = "Coins: ";
    public TextMeshProUGUI coinsText;
    private void Start()
    {
        currentCoins = 0;
        coinsText.text = coins + currentCoins.ToString();
    }
}
