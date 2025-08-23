using TMPro;
using UnityEngine;

public class UnlockChestByGem : MonoBehaviour
{
    [SerializeField] private TMP_Text noOfGemsToUnlockChestText;

    public void UpdateGemCount(int val)
    {
        noOfGemsToUnlockChestText.SetText(val.ToString());
    }
}
