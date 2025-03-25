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
    Unlocked,
    Opened
}

public class ChestService : GenericSingleton<ChestService>
{

    [SerializeField] private List<ChestDataSO> chestDataList;
    private List<ChestController> controllersList = new List<ChestController>();
    public bool SpawnChestIfSlotAvaliable()
    {
        ChestSlot avaliableSlot = ChestSlotManager.Instance.GetChestSlot();
        if (avaliableSlot)
        {
            int randomChestIndex = Random.RandomRange(0, chestDataList.Count);
            ChestDataSO chestData = chestDataList[randomChestIndex];
            ChestController chestController = new ChestController(chestData, avaliableSlot.gameObject.GetComponent<ChestView>());
            controllersList.Add(chestController);
            avaliableSlot.isSlotEmpty = false;
            return true;
        }
        return false;

        //create the chest controller using this data
    }

    public void DeleteController(ChestController controller)
    {
        controllersList.Remove(controller);
    }
}
