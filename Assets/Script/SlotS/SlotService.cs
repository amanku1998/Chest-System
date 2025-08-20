using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotService
{
    private List<SlotController> slotList = new List<SlotController>();

    public SlotService(SlotView slotPrefab, int totalNoOfSlots, Transform slotContentTransform)
    {
        CreateSlot(slotPrefab, totalNoOfSlots, slotContentTransform);
    }

    private void CreateSlot(SlotView slotPrefab, int totalNoOfSlots, Transform slotContentTransform)
    {
        for (int i = 0; i < totalNoOfSlots; i++)
        {
            SlotController slotController = new SlotController(slotPrefab, slotContentTransform);
            slotList.Add(slotController);
        }
    }

    public SlotController GetSlotController(int slotIndex)
    {
        return slotList[slotIndex];
    }
}
