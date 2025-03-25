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
    [SerializeField] private Button cancelButton;

    [SerializeField] private ChestPopup chestPopup;
    [SerializeField] private TextMeshProUGUI coinsCount;
    [SerializeField] private TextMeshProUGUI gemsCount;

    [SerializeField] public ChestUnlockScreen chestUnlockScreen;
    [SerializeField] GameObject insufficientResourceGameObject;

    private int totalCoins=2000;
    private int totalGems=500;

    private void Start()
    {
        SetPopup(false);
        chestSpawnButton.onClick.AddListener(OnChestSpawnButtonClicked);
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
        insufficientResourceGameObject.GetComponentInChildren<Button>().onClick.AddListener(OnCancelButtonClicked);
        coinsCount.text = totalCoins.ToString();
        gemsCount.text = totalGems.ToString();
    }

    public int GetTotalGems()
    {
        return totalGems;
    }

    public void UseGems(int gemsUsed)
    {
        totalGems -= gemsUsed;
    }
    public void EnableInsufficentResoursePopup()
    {
        insufficientResourceGameObject.SetActive(true);
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

    private void OnCancelButtonClicked()
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
