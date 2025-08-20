using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Animator chestAnim;
    private ChestController chestController;

    void Start()
    {
        chestAnim.enabled = false;
    }

    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
    }

    public Animator GetChestAnimator()
    {
        return chestAnim;
    }

}
