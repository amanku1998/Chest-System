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
    [SerializeField] private UnlockChest unlockedChest;

    [SerializeField] private List<ChestPrefabData> chestPrefabDataList;
    [SerializeField] private DisplayInstructionTextHandler displayInstructionTextHandler;

    private SlotService slotService;
    private ChestService chestService;
    private EventService eventService;
    private CurrencyHandler currencyHandler;

    // Start is called before the first frame update
    void Start()
    {
        slotService = new SlotService(emptySlotPrefab, totalNoOfSlots, slotContentTransform);
        chestService = new ChestService();
        currencyHandler = new CurrencyHandler(coinsText, gemsText);
        eventService = new EventService();

        displayInstructionTextHandler.SubscribeEvent();
    }

    public SlotService GetSlotService { get { return slotService; } }
    public ChestService GetChestService { get { return chestService; } }
    public CurrencyHandler GetCurrencyHandler { get { return currencyHandler; } }
    public EventService GetEventService { get { return eventService; } }
    public int GetSlotCount() => totalNoOfSlots;
    public void CreateChest() => chestService.CreateChest();
    public void OpenUnlockChestPopup() => unlockedChest.gameObject.SetActive(true);
    public ChestPrefabData GetChestPrefabData(int chestIndex) => chestPrefabDataList[chestIndex];
   
}
