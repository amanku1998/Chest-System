using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject" , menuName = "ScriptableObjects/Chest")]
public class ChestScriptable : ScriptableObject
{
    public ChestType chestType;
    public int minCoin;
    public int maxCoin;
    public int minGem;
    public int maxGem;
    public int timeInMin;
}

public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary
}