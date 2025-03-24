using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotManager : GenericSingleton<ChestSlotManager>
{
    [SerializeField] private List<ChestSlot> chestSlotList;
    void Start()
    {
        
    }


    public ChestSlot GetChestSlot()
    {
        if(chestSlotList!=null)
        {
            for(int index=0; index<chestSlotList.Count; index++)
            {
                if (chestSlotList[index].isSlotEmpty)
                {
                    return chestSlotList[index];
                   
                }
            }
        }
        return null;
    }
    public void SpawnChest()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
