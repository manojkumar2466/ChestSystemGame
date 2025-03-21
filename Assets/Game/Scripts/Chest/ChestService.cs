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

public class ChestService : GenericSingleton<ChestService>
{

    [SerializeField] private List<ChestDataSO> chestsList;
    
    public void OnSpawnChestClicked()
    {
        int randomChestIndex = Random.RandomRange(0, chestsList.Count);
        //create the chest controller using this data
    }
}
