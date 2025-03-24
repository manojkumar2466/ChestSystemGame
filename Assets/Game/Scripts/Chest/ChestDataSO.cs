using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="ChestData", menuName ="Chest/ChestData")]
public class ChestDataSO : ScriptableObject
{
    public Sprite chestLockedIcon;
    public Sprite chestUnlockedIcon;
    public EChestType chestType;
    [SerializeField] public int minCoins;
    [SerializeField] public int maxCoins;
    [SerializeField] public int minGems;
    [SerializeField] public int maxGems;
    public float unlockTimeInMins;
}
