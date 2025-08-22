using UnityEngine;

public class ChestModel 
{
    public ChestScriptable chestScriptable;
    public ChestState chestState = ChestState.Locked;

    public ChestModel(ChestScriptable chestScriptable, ChestState chestState = ChestState.Locked)
    {
        this.chestScriptable = chestScriptable;
        this.chestState = chestState;
    }

    public ChestScriptable GetChestScriptableObjectInfo() => chestScriptable;
    
    public ChestState GetChestState() => chestState;

    public void SetChestState(ChestState chestState) => this.chestState = chestState;

    public void GetChestReward()
    {
        int coins = Random.Range(chestScriptable.minCoin, chestScriptable.maxCoin + 1);
        int gems = Random.Range(chestScriptable.minGem, chestScriptable.maxGem + 1);

        GameService.Instance.GetCurrencyHandler.AddCoins(coins);
        GameService.Instance.GetCurrencyHandler.AddGems(gems);
    }
}
