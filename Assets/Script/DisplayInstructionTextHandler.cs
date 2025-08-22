using TMPro;
using UnityEngine;

public class DisplayInstructionTextHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text instructionText;
    [SerializeField] private string chestFailedString;
    [SerializeField] private string unlockedChestFailedString;
    [SerializeField] private string unlockedChestByGemFailedString;

    public void SubscribeEvent()
    {
        GameService.Instance.GetEventService.OnFailedUnlock.AddListener(UpdateTextOnFailed);
    }

    private void OnDisable()
    {
        GameService.Instance.GetEventService.OnFailedUnlock.RemoveListener(UpdateTextOnFailed);
    }

    private void UpdateTextOnFailed(FailedStringType failedStringType)
    {
        string failedText = "";

        switch (failedStringType)
        {
            case FailedStringType.ChestFailed:
                failedText = chestFailedString;
                break;
            case FailedStringType.UnlockedChestFailed:
                failedText = unlockedChestFailedString;
                break;
            case FailedStringType.UnlockedChestByGemFailed:
                failedText = unlockedChestByGemFailedString;
                break;
            default:
                break;
        }

        instructionText.enabled = true;
        instructionText.text = failedText;
        Invoke(nameof(DisableOverLayText), 3f);
    }

    private void DisableOverLayText()
    {
        instructionText.enabled = false;
    }
}

[System.Serializable]
public enum FailedStringType
{
    ChestFailed,
    UnlockedChestFailed,
    UnlockedChestByGemFailed
}
