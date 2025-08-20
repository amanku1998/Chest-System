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


}
