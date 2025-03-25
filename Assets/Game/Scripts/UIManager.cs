using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Button chestSpawnButton;
    [SerializeField] public GameObject PopupGameObject;

    //SlotFull
    [SerializeField] private GameObject SlotFullPopup;
    [SerializeField] private Button slotFullCancelButton;

    [SerializeField] private ChestPopup chestPopup;
    [SerializeField] private TextMeshProUGUI coinsCount;
    [SerializeField] private TextMeshProUGUI gemsCount;

    [SerializeField] ChestUnlockScreen chestUnlockScreen;

    private int totalCoins=2000;
    private int totalGems=500;

    private void Start()
    {
        SetPopup(false);
        chestSpawnButton.onClick.AddListener(OnChestSpawnButtonClicked);
        slotFullCancelButton.onClick.AddListener(OnSoltFullCancelButtonClicked);
        coinsCount.text = totalCoins.ToString();
        gemsCount.text = totalGems.ToString();
    }


    public void EnableChestUnlockScreen(ChestDataSO data, ChestController controller)
    {
        SetPopup(true);
        chestUnlockScreen.gameObject.SetActive(true);
        chestUnlockScreen.Initialize(data, controller);
    }
    public void SetCoinsCount(int coinsToIncrease)
    {
        totalCoins += coinsToIncrease;
        coinsCount.text = totalCoins.ToString();
    }

    public void SetGemsCount(int gemsToIncrease)
    {
        totalGems += gemsToIncrease;
        gemsCount.text = totalGems.ToString();
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
