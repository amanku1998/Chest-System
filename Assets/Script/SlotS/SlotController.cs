using UnityEngine;

public class SlotController 
{
    private SlotView slotView;
    public ChestController chestController;
    public float timeNeededToUnlockChest;

    public SlotController(SlotView slotPrefab, Transform slotTransform)
    {
        slotView = Object.Instantiate(slotPrefab, slotTransform);
        slotView.transform.SetParent(slotTransform);
        slotView.SetSlotController(this);
    }

    public SlotView GetSlotView() => slotView;
    public ChestState GetChestState() => chestController.GetChestModel().GetChestState();


    public void SetChestInfoInSlot(ChestController chestController)
    {
        this.chestController = chestController;
        slotView.SetSlotInfo(chestController);
    }

    public bool IsSlotEmpty()
    {
        return chestController == null;
    }

    public void OnPointerClick()
    {
        if (IsSlotEmpty()) return;

        if (GetChestState() == ChestState.Unlocked)
        {
            OpenChest();
        }
        else if (GetChestState() == ChestState.Unlocking)
        {
            //UnlockChestByGem();
        }
        else if (GetChestState() == ChestState.Locked)
        {
            //if (GetUnlockingSlot() == null)
            //{
            //    OpenChestUnlockPopup();
            //}
            //else
            //{
            //    GameService.Instance.EventService.OnFailedString.InvokeEvent(FailedStringType.UnlockedChestFailed);
            //}
        }
    }

    //public int GetGemCountByTime()
    //{
    //    if (GetChestState() == ChestState.Unlocking)
    //    {
    //        float time = slotView.timerController.GetTime();
    //        return Mathf.CeilToInt(time / 10);
    //    }
    //}
    public void SetChestState(ChestState chestState)
    {
        chestController.GetChestModel().SetChestState(chestState);
    }

    public void SetUnlockingSlot()
    {
        GameService.Instance.GetSlotService.SetUnlockingSlot(this);
    }

    private void OpenChest()
    {
        SetChestState(ChestState.Collected);
        chestController.OpenChest();
        slotView.OpenChest();
    }

    public int GetGemCountByTime()
    {
        if (GetChestState() == ChestState.Unlocking)
        {
            float time = slotView.timerController.GetTimeInMin();
            return Mathf.CeilToInt(time / 10);
        }

        return Mathf.CeilToInt((timeNeededToUnlockChest / 60) / 10); ;
    }

    public void StartTimerForUnlockChest()
    {
        slotView.StartTimer(timeNeededToUnlockChest);
        SetChestState(ChestState.Unlocking);
        SetUnlockingSlot();
    }
}
