using UnityEngine;

public class SlotController 
{
    private SlotView slotView;

    public SlotController(SlotView slotPrefab, Transform slotTransform)
    {
        slotView = Object.Instantiate(slotPrefab, slotTransform);
        slotView.transform.SetParent(slotTransform);
        slotView.SetSlotController(this);
    }
}
