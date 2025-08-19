using UnityEngine;

public class SlotController 
{
    private SlotView slotView;

    public SlotController(SlotView slotPrefab, Transform slotContentTransform)
    {
        slotView = Object.Instantiate(slotPrefab, slotContentTransform);
        slotView.transform.SetParent(slotContentTransform);
        slotView.SetSlotController(this);
    }
}
