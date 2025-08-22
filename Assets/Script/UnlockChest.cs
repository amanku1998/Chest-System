using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    [SerializeField] private TMP_Text gemCount;
    private SlotController slotController;

    private void OnEnable()
    {
        GameService.Instance.GetEventService.OnSlotSelect.AddListener(SetGemCount);
    }

    private void OnDisable()
    {
        GameService.Instance.GetEventService.OnSlotSelect.RemoveListener(SetGemCount);
    }

    private void SetGemCount(SlotController slotController)
    {
        this.slotController = slotController;
        gemCount.text = slotController.GetGemCountByTime().ToString();
    }

    public void StartTimer()
    {
        if (slotController != null)
        {
            slotController.StartTimerForUnlockChest();
            int slotIndex = GameService.Instance.GetSlotService.GetSlotIndex(slotController);
        }
    }

    public void UnlockedChestByGem()
    {
        if (slotController != null)
        {
            slotController.UnlockChestByGem();
        }
    }
}
