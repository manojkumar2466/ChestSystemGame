using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    [SerializeField]private Image currentChestIcon;
    private ChestSlot chestSlot;
    [SerializeField] private Button ChestSlotButton;
    [SerializeField] private TextMeshProUGUI chestStatusText;
    [SerializeField] private TextMeshProUGUI arenaGameobject;
    [SerializeField] private TextMeshProUGUI openNowText;
    [SerializeField] private GameObject unlockNowGameobject;
    [SerializeField] private TextMeshProUGUI unlockGemsText;
    [SerializeField] private EChestStatus chestStatus;
    [SerializeField] private TextMeshProUGUI unlockGemCountText;
    private ChestDataSO data;
    public bool isUnlockTimerStarted= false;
    private float timer;
    private bool timerToggle = true;
    int gemsToUnlock;
    public void InitializeChest(ChestDataSO data)
    {
        this.data = data;
        chestStatus = EChestStatus.Locked;
        ChestSlotButton.onClick.AddListener(OnChestSlotButtonClicked);
        chestStatusText.gameObject.SetActive(true);
        chestStatusText.text = chestStatus.ToString();
        arenaGameobject.gameObject.SetActive(true);
        openNowText.gameObject.SetActive(false);
        unlockNowGameobject.SetActive(false);
        currentChestIcon.gameObject.SetActive(true);
        currentChestIcon.sprite = data.chestLockedIcon;
        timer = data.unlockTimeInMins;
        chestSlot = GetComponent<ChestSlot>();
    }

    public void OnChestRewardCollected()
    {
        chestStatusText.gameObject.SetActive(false);
        arenaGameobject.gameObject.SetActive(false);
        openNowText.gameObject.SetActive(false);
        unlockNowGameobject.SetActive(false);
        currentChestIcon.gameObject.SetActive(false);
        chestSlot.isSlotEmpty = true;
    }
    private void OnChestSlotButtonClicked()
    {
        ChestSlotManager.Instance.currentChestController = chestController;
        if (chestStatus == EChestStatus.Unlocked)
        {
            chestController.CollectReward();

        }
        else if(chestStatus==EChestStatus.Locked)
        {
            chestStatus = EChestStatus.Unlocked;
            UIManager.Instance.SetupChestPopup(data);
        }
        else if(chestStatus==EChestStatus.Unlocking)
        {
            if (UIManager.Instance.GetTotalGems() < gemsToUnlock)
            {
                UIManager.Instance.EnableInsufficentResoursePopup();
                return;
            }

            OpenChestUsingGems();
        }
        
        
    }

    public void OpenChestUsingGems()
    {
        chestStatus = EChestStatus.Opened;
        UIManager.Instance.UseGems(gemsToUnlock);
        chestController.CollectReward();
    }

   

    public void SetController(ChestController controller)
    {
        chestController = controller;
    }


    private IEnumerator StartUnlockingChestUsingTimer()
    {
        yield return new WaitForSeconds(1);
        if (chestStatus == EChestStatus.Unlocking)
        {            
            timer--;
            chestStatusText.text = "Unlocks in " + timer.ToString();
            timerToggle = true;
            gemsToUnlock = Mathf.CeilToInt(timer / 10);
            unlockGemCountText.text = gemsToUnlock.ToString();
            if (timer <= 0 )
            {
                OnChestUnlocked();
            }
        }
        
    }

    private void OnChestUnlocked()
    {
        chestStatusText.text = "Unlocked!";
        isUnlockTimerStarted = false;
        currentChestIcon.sprite = data.chestUnlockedIcon;
        unlockNowGameobject.SetActive(false);
        arenaGameobject.gameObject.SetActive(true);
        arenaGameobject.text = "Open";
        chestStatus = EChestStatus.Unlocked;
    }

    public void EnableTimer()
    {
        isUnlockTimerStarted = true;
        chestStatus = EChestStatus.Unlocking;
        unlockNowGameobject.SetActive(true);
        arenaGameobject.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isUnlockTimerStarted)
        {
            if (timerToggle)
            {
                StartCoroutine(StartUnlockingChestUsingTimer());
                timerToggle = false;
            }         
        }
    }
}
