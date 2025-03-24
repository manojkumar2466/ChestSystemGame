using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    public Sprite chestIcon { get; private set; }
    public EChestType chestType { get; private set; }
    [SerializeField] public int minCoins { get; private set; }
    [SerializeField] public int maxCoins { get; private set; }
    [SerializeField] public int minGems { get; private set; }
    [SerializeField] public int maxGems { get; private set; }
    public float unlockTimeInMins;
    public int unloackCost { get; private set; }

    public ChestModel(ChestDataSO data)
    {
        chestIcon = data.chestLockedIcon;
        chestType = data.chestType;
        minCoins = data.minCoins;
        maxCoins = data.maxCoins;
        minGems = data.minGems;
        maxGems = data.maxGems;
        unlockTimeInMins = data.unlockTimeInMins;
    }
   
}
