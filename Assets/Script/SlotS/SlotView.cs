using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    public TMP_Text emptySlotText;
    public TMP_Text openChestText;
    public TMP_Text lockedChestText;
    public TMP_Text timeToUnlockText;

    public DisplayChestData displayChestData;
    public UnlockChestByGem UnlockChestByGem;
    private SlotController slotController;

    public void SetSlotController(SlotController slotController)
    {
        this.slotController = slotController;
    }
}
