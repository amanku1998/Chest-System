using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotView : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text emptySlotText;
    public TMP_Text openChestText;
    public TMP_Text lockedChestText;
    public TMP_Text timeToUnlockText;

    public DisplayChestData displayChestData;
    public UnlockChestByGem unlockChestByGem;
    private SlotController slotController;
    public Button undoButton;
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
        slotController.SetCurrentUpdatedGemsRequiredToUnlockChest(slotController.GetGemCountByTime());
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
        undoButton.gameObject.SetActive(false);
        DestroyChest();
    }

    public void UnlockChestByGems()
    {
        timerController.gameObject.SetActive(false);
        unlockChestByGem.gameObject.SetActive(false);
        timeToUnlockText.enabled = false;
        lockedChestText.enabled = false;
        openChestText.enabled = true;
        undoButton.gameObject.SetActive(true);
    }

    public void UnlockChest()
    {
        timerController.gameObject.SetActive(false);
        unlockChestByGem.gameObject.SetActive(false);
        timeToUnlockText.enabled = false;
        lockedChestText.enabled = false;
        openChestText.enabled = true;
    }

    public void SetSlotInfo(ChestController chestController)
    {
        emptySlotText.transform.SetAsFirstSibling();
        lockedChestText.enabled = true;
        displayChestData.SetRewardedChestData(chestController.GetChestModel().GetChestScriptableObjectInfo());
        UpdateSlotTimeText();
    }

    public void ClickOnUndoButton()
    {
        slotController.UndoUnlockingChest();
    }

    public void UndoUnlocking()
    {
        timeToUnlockText.enabled = true;
        lockedChestText.enabled = true;
        openChestText.enabled = false;
        undoButton.gameObject.SetActive(false);
    }

    public void UpdateSlotTimeText()
    {
        timeToUnlockText.enabled = true;
        float totalSeconds = slotController.timeNeededToUnlockChest;

        int hours = Mathf.FloorToInt(totalSeconds / 3600f);
        int minutes = Mathf.CeilToInt((totalSeconds % 3600f) / 60f);

        if (hours > 0)
        {
            // Show hours and minutes
            timeToUnlockText.SetText($"{hours}Hrs{minutes}Min");
        }
        else
        {
            // Show only minutes
            timeToUnlockText.SetText($"{minutes}Min");
        }
    }

    public void DestroyChest()
    {
        Destroy(slotController.chestController.GetChestView().gameObject, 2);
        int slotIndex = GameService.Instance.GetSlotService.GetSlotIndex(slotController);
        //Debug.Log("slotIndex :" + slotIndex);
    }
}
