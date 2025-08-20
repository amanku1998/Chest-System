using UnityEngine;

public class SlotController 
{
    private SlotView slotView;
    public ChestController chestController;

    public SlotController(SlotView slotPrefab, Transform slotTransform)
    {
        slotView = Object.Instantiate(slotPrefab, slotTransform);
        slotView.transform.SetParent(slotTransform);
        slotView.SetSlotController(this);
    }

    public SlotView GetSlotView()
    {
        return slotView;
    }

    public void SetChestInfoInSlot(ChestController chestController)
    {
        this.chestController = chestController;
        //slotView.SetSlotInfo(chestController);
    }

    public bool IsSlotEmpty()
    {
        return chestController == null;
    }
}
