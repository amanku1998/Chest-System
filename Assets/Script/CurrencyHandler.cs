using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyHandler
{
    private int coin;
    private int gem;
    private TMP_Text coinText;
    private TMP_Text gemText;

    public CurrencyHandler(TMP_Text coinText, TMP_Text gemText)
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        gem = PlayerPrefs.GetInt("Gem", 0);

        this.coinText = coinText;
        this.coinText.SetText(coin.ToString());

        this.gemText = gemText;
        this.gemText.SetText(gem.ToString());
    }

    public int GetCoins()
    {
        return coin;
    }
    public int GetGems()
    {
        return gem;
    }
    public void AddCoins(int value)
    {
        coin += value;
        UpdateCoins();
    }

    public void UpdateCoins()
    {
        PlayerPrefs.SetInt("Gem", gem);
        gemText.SetText(gem.ToString());
    }

    public void AddGems(int value)
    {
        gem += value;
        UpdateGems();
    }

    public void UpdateGems()
    {
        PlayerPrefs.SetInt("Gem", gem);
        gemText.SetText(gem.ToString());
    }

    public void SpendGems(int value)
    {
        gem -= value;
        if (gem < 0)
        {
            gem = 0;
        }

        UpdateGems();
    }
}
