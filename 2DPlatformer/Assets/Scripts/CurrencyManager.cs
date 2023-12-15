using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public int currentCoins;
    private string coins = "Coins: ";
 
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentCoins = 0;
        
          
           
        
    }
    public void AddCoins()
    {
        currentCoins += 1;
        
    }
}
