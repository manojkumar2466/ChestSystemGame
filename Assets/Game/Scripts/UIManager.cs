using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Button chestSpawnButton;
    [SerializeField] public GameObject PopupGameObject;

    //SlotFull
    [SerializeField] private GameObject SlotFullPopup;
    [SerializeField] private Button slotFullCancelButton;

    [SerializeField] private ChestPopup chestPopup;


    private void Start()
    {
        SetPopup(false);
        chestSpawnButton.onClick.AddListener(OnChestSpawnButtonClicked);
        slotFullCancelButton.onClick.AddListener(OnSoltFullCancelButtonClicked);
    }

    private void OnSoltFullCancelButtonClicked()
    {
        SlotFullPopup.SetActive(false);
        SetPopup(false);
    }
    private void OnChestSpawnButtonClicked()
    {
        if (!ChestService.Instance.SpawnChestIfSlotAvaliable())
        {
            SetPopup(true); ;
            SlotFullPopup.SetActive(true);
        }
    }


    public void SetupChestPopup(ChestDataSO data)
    {
        SetPopup(true);
        chestPopup.gameObject.SetActive(true);
        chestPopup.Initialize(data);
    }

    public void SetPopup(bool toogle)
    {
        PopupGameObject.SetActive(toogle);
    }
}
