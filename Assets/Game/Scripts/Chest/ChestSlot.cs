using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestSlot : MonoBehaviour
{
    private ChestView chestView;
    public bool isSlotEmpty;
    



    void Start()
    {
        isSlotEmpty = true; 
    }

    public void SpawnRandomChest(ChestDataSO chestData)
    {
        ChestController chestController ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnChestOpenButtonClicked()
    {

    }
}
