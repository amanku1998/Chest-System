using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ChestController
{
    private ChestView chestView;
    private ChestModel chestModel;
    private SlotController slotController;

    public ChestController(ChestView chestPrefab, ChestModel chestModel, SlotController slotController)
    {
        Transform slotTransform = slotController.GetSlotView().transform;

        chestView = GameObject.Instantiate(chestPrefab, slotTransform);
        chestView.transform.SetAsLastSibling();

        Vector3 pos = chestView.transform.localPosition;
        pos.y -= 78f;  
        chestView.transform.localPosition = pos;

        chestView.SetChestController(this);
        this.chestModel = chestModel;
        this.slotController = slotController;
    }

    public ChestView GetChestView() => chestView;   
    public ChestModel GetChestModel() => chestModel;
    public SlotController GetSlotController() => slotController;

    public void OpenChest()
    {
        chestView.GetChestAnimator().enabled = true;
        chestModel.GetChestReward();
    }
}
