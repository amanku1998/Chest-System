using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayChestData : MonoBehaviour
{
    [SerializeField] private TMP_Text noOfCoinsGetText;
    [SerializeField] private TMP_Text noOfGemsGetText;

    public void SetRewardedChestData(ChestScriptable chestScriptable)
    {
        noOfCoinsGetText.SetText($"{chestScriptable.minCoin} - {chestScriptable.maxCoin}");
        noOfGemsGetText.SetText($"{chestScriptable.minGem} - {chestScriptable.maxGem}");
    }
}
