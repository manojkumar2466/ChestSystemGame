using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChestUnlockScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardCountText;
    [SerializeField] private TextMeshProUGUI rewardTypeCountText;
    [SerializeField] Image rewardTypeImage;
    [SerializeField] Sprite goldImage;
    [SerializeField] Sprite gemImage;
    [SerializeField] Image chestUnlockImage;
    [SerializeField] Button chestButton;
    private int rewardCount=1;
    ChestDataSO data;
    ChestController chestController;

    public void Initialize(ChestDataSO data, ChestController controller)
    {
        this.data = data;
        CollectReward();
        chestController = controller;
        chestUnlockImage.sprite = data.chestUnlockedIcon;

    }
   

    public void CollectReward()
    {
        if (rewardCount == 1)
        {
            rewardTypeImage.sprite = goldImage;
            int random = Random.Range(data.minCoins, data.maxCoins);
            UIManager.Instance.SetCoinsCount(random);
            rewardCountText.text = rewardCount.ToString();
            rewardTypeCountText.text = random.ToString();
            rewardCount++;
        }
        else if (rewardCount == 2)
        {
            rewardTypeImage.sprite = gemImage;
            int random = Random.Range(data.minGems, data.maxGems);
            UIManager.Instance.SetGemsCount(random);
            rewardCountText.text = rewardCount.ToString();
            rewardTypeCountText.text = random.ToString();
            rewardCount++;
            

        }else
        {
            UIManager.Instance.SetPopup(false);
            this.gameObject.SetActive(false);
            chestController.RewardCollected();
            rewardCount = 1;
        }
        


    }
}
