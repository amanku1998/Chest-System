using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotService
{
    private List<SlotController> slotList = new List<SlotController>();
    private SlotController unlockingSlot;

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

    public SlotController GetSlotController(int slotIndex) => slotList[slotIndex];   
    public int GetSlotIndex(SlotController SlotController) => slotList.IndexOf(SlotController);
    public void SetUnlockingSlot(SlotController slotController) => unlockingSlot = slotController;
}
