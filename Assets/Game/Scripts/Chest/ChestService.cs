using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EChestType
{
    Common, 
    Rare,
    Epic,
    Lengendary
}

public enum EChestStatus
{
    Locked,
    Unlocking,
    Unlocked
}

public class ChestService : GenericSingleton<ChestService>
{

    [SerializeField] private List<ChestDataSO> chestDataList;
    public bool SpawnChestIfSlotAvaliable()
    {
        ChestSlot avaliableSlot = ChestSlotManager.Instance.GetChestSlot();
        if (avaliableSlot)
        {
            int randomChestIndex = Random.RandomRange(0, chestDataList.Count);
            ChestDataSO chestData = chestDataList[randomChestIndex];
            ChestController chestController = new ChestController(chestData, avaliableSlot.gameObject.GetComponent<ChestView>());
            avaliableSlot.isSlotEmpty = false;
            return true;
        }
        return false;

        //create the chest controller using this data
    }
}
