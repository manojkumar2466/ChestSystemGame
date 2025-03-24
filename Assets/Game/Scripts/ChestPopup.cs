using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestPopup : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] private TextMeshProUGUI goldCountText;
    [SerializeField] private TextMeshProUGUI gemCountText;
    [SerializeField] private TextMeshProUGUI unlockGemCountText;
    [SerializeField] private TextMeshProUGUI timerCountText;
    [SerializeField] private Button cancelButton;

    public void Initialize(ChestDataSO data)
    {
        cancelButton.onClick.AddListener(OnCancelButtonClicked);
        chestImage.sprite = data.chestLockedIcon;
        goldCountText.text = data.minCoins.ToString() + " to " + data.maxCoins;
        gemCountText.text = data.minGems.ToString() + " to " + data.maxGems;
        float gemCount = Mathf.Abs( data.unlockTimeInMins / 10);
        unlockGemCountText.text = gemCount.ToString();
        timerCountText.text = data.unlockTimeInMins.ToString();
    }

    private void OnCancelButtonClicked()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.SetPopup(false);
    }
}
