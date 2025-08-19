using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text gemsText;
    [SerializeField] private int totalNoOfSlots = 4;
    [SerializeField] private Transform slotContentTransform;
    [SerializeField] private SlotView emptySlotPrefab;

    private SlotService slotService;

    // Start is called before the first frame update
    void Start()
    {
        slotService = new SlotService(emptySlotPrefab, totalNoOfSlots, slotContentTransform);
    }

    public SlotService GetSlotService { get { return slotService; } }
}
