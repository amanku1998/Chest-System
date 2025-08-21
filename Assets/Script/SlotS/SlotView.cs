using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotView : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text emptySlotText;
    public TMP_Text openChestText;
    public TMP_Text lockedChestText;
    public TMP_Text timeToUnlockText;

    public DisplayChestData displayChestData;
    public UnlockChestByGem unlockChestByGem;
    private SlotController slotController;

    public TimerCountdownController timerController;

    public void SetSlotController(SlotController slotController)
    {
        this.slotController = slotController;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (slotController.IsSlotEmpty()) return;
        if (slotController.GetChestState() == ChestState.Collected) return;

        if(slotController.GetChestState() == ChestState.Unlocking)
        {
            unlockChestByGem.UpdateGemCount(slotController.GetGemCountByTime());
            unlockChestByGem.gameObject.SetActive(true);
            displayChestData.gameObject.SetActive(true);
        }
        else
        {
            displayChestData.gameObject.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        slotController.OnPointerClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (slotController.IsSlotEmpty()) return;

        if (slotController.GetChestState() == ChestState.Unlocking)
        {
            unlockChestByGem.gameObject.SetActive(false);
            displayChestData.gameObject.SetActive(false);
        }
        else
        {
            displayChestData.gameObject.SetActive(false);
        }
    }

    public void StartTimer(float time)
    {
        timeToUnlockText.enabled = false;
        timerController.gameObject.SetActive(true);
        timerController.SetTimeInSec(time);
        timerController.SetSlotController(slotController);
    }


    public void OpenChest()
    {
        openChestText.enabled = false;
        displayChestData.gameObject.SetActive(false);
        //undoButton.gameObject.SetActive(false);
        DestroyChest();
    }

    public void SetSlotInfo(ChestController chestController)
    {
        emptySlotText.transform.SetAsFirstSibling();
        lockedChestText.enabled = true;
        displayChestData.SetRewardedChestData(chestController.GetChestModel().GetChestScriptableObjectInfo());
    }

    public void DestroyChest()
    {
        Destroy(slotController.chestController.GetChestView().gameObject, 2);
        int slotIndex = GameService.Instance.GetSlotService.GetSlotIndex(slotController);
        //GameService.Instance.GetChestService.DeleteChestSavedData(slotIndex);
    }
}
