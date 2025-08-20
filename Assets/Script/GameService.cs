using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text gemsText;
    [SerializeField] private int totalNoOfSlots = 4;
    [SerializeField] private Transform slotContentTransform;
    [SerializeField] private SlotView emptySlotPrefab;

    [SerializeField] private List<ChestPrefabData> chestPrefabDataList;

    private SlotService slotService;
    private ChestService chestService;

    // Start is called before the first frame update
    void Start()
    {
        slotService = new SlotService(emptySlotPrefab, totalNoOfSlots, slotContentTransform);
        chestService = new ChestService();
    }

    public SlotService GetSlotService { get { return slotService; } }

    public int GetSlotCount() => totalNoOfSlots;

    public void CreateChest()
    {
        chestService.CreateChest();
    }

    public ChestPrefabData GetChestPrefabData(int chestIndex)
    {
        return chestPrefabDataList[chestIndex];
    }
}
