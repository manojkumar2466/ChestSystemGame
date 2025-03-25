using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestPopup : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] TextMeshProUGUI chestName;
    [SerializeField] private TextMeshProUGUI goldCountText;
    [SerializeField] private TextMeshProUGUI gemCountText;
    [SerializeField] private TextMeshProUGUI unlockGemCountText;
    [SerializeField] private TextMeshProUGUI timerCountText;
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button timerStartButton;
    [SerializeField] private Button GemUnlcokButton;

    private ChestController chestController;

    public void Initialize(ChestDataSO data)
    {
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
        timerStartButton.onClick.AddListener(OnTimerStartButtonClicked);
        GemUnlcokButton.onClick.AddListener(OnGemUnlockButtonClicked);
        chestImage.sprite = data.chestLockedIcon;
        chestName.text = data.chestType.ToString() + " Chest";
        goldCountText.text = data.minCoins.ToString() + " to " + data.maxCoins;
        gemCountText.text = data.minGems.ToString() + " to " + data.maxGems;
        float gemCount = Mathf.Abs( data.unlockTimeInMins / 10);
        unlockGemCountText.text = gemCount.ToString();
        timerCountText.text = data.unlockTimeInMins.ToString();
        chestController = ChestSlotManager.Instance.currentChestController;
    }

    private void OnCancelButtonClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.SetPopup(false);
        ChestSlotManager.Instance.currentChestController = null;
    }

    private void OnTimerStartButtonClicked()
    {
        chestController.StartTimerOnChest();
        OnCancelButtonClicked();
    }

    private void OnGemUnlockButtonClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.SetPopup(false);
        ChestSlotManager.Instance.currentChestController.OpenChestUsingGems();
    }
}
