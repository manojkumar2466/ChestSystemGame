using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDataSO : ScriptableObject
{
    public EChestType chestType;
    [SerializeField] private int minCoins;
    [SerializeField] private int maxCoins;
    [SerializeField] private int minGems;
    [SerializeField] private int maxGems;
    public float unlockTimeInMins;
    public int unloackCost;
}
