using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

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
    private CurrencyHandler currencyHandler;

    // Start is called before the first frame update
    void Start()
    {
        slotService = new SlotService(emptySlotPrefab, totalNoOfSlots, slotContentTransform);
        chestService = new ChestService();
        currencyHandler = new CurrencyHandler(coinsText, gemsText);

    }

    public SlotService GetSlotService { get { return slotService; } }
    public ChestService GetChestService { get { return chestService; } }
    public CurrencyHandler GetCurrencyHandler { get { return currencyHandler; } }

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
