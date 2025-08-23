using System.Collections.Generic;

public class ChestService 
{
    private List<ChestController> chestControllerList = new List<ChestController>();

    public ChestService(){
    }

    public void CreateChest()
    {
        bool isChestCreated = false;

        for (int i = 0; i < GameService.Instance.GetSlotCount(); i++)
        {
            SlotController slotController = GameService.Instance.GetSlotService.GetSlotController(i);

            if(slotController.IsSlotEmpty())
            {
                ChestPrefabData chestData = GameService.Instance.GetChestPrefabData(i);

                ChestModel chestModel = new ChestModel(chestData.chestScriptable);
                ChestController chestController = new ChestController(chestData.chestPrefab, chestModel, slotController );
                chestControllerList.Add(chestController);
                slotController.SetChestInfoInSlot(chestController);

                isChestCreated = true;
                break;
            }
        }

        if (!isChestCreated)
        {
            GameService.Instance.GetEventService.OnFailedUnlock.InvokeEvent(FailedStringType.ChestFailed);
        }
    }
}

[System.Serializable]
public class ChestPrefabData
{
    public ChestType chestType;
    public ChestScriptable chestScriptable;
    public ChestView chestPrefab;
}

[System.Serializable]
public enum ChestState
{
    Locked,
    Unlocking,
    Unlocked,
    Collected
}