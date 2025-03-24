using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Button chestSpawnButton;
    [SerializeField] private GameObject PopupGameObject;

    //SlotFull
    [SerializeField] private GameObject SlotFullPopup;
    [SerializeField] private Button slotFullCancelButton;


    private void Start()
    {
        PopupGameObject.SetActive(false);
        chestSpawnButton.onClick.AddListener(OnChestSpawnButtonClicked);
        slotFullCancelButton.onClick.AddListener(OnSoltFullCancelButtonClicked);
    }

    private void OnSoltFullCancelButtonClicked()
    {
        SlotFullPopup.SetActive(false);
        PopupGameObject.SetActive(false);
    }
    private void OnChestSpawnButtonClicked()
    {
        if (!ChestService.Instance.SpawnChestIfSlotAvaliable())
        {
            PopupGameObject.SetActive(true);
            SlotFullPopup.SetActive(true);
        }
    }

}
