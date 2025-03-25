using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private ChestDataSO chestData;
    private ChestView chestView;
    private ChestUnlockScreen unlockScreen;
   
    public ChestController(ChestDataSO chestData, ChestView chestView)
    {
        this.chestData = chestData;
        chestView.SetController(this);
        chestView.InitializeChest(chestData);
        this.chestView = chestView;
    }

    public void StartTimerOnChest()
    {
        chestView.EnableTimer();
    }

    public void CollectReward()
    {
        UIManager.Instance.EnableChestUnlockScreen(chestData, this);
    }

    public void RewardCollected()
    {
        ChestService.Instance.DeleteController(this);
        
    }

}
