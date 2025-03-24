using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private ChestDataSO chestData;
   
    public ChestController(ChestDataSO chestData, ChestView chestView)
    {
        this.chestData = chestData;
        chestView.SetController(this);
        chestView.InitializeChest(chestData);
    }
}
