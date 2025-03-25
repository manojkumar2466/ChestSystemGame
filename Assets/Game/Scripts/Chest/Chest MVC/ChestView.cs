using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            UIManager.Instance.SetupChestPopup(data);
        }
        
        
    }
    void Start()
    {
          
    }

    public void SetController(ChestController controller)
    {
        chestController = controller;
    }


    private IEnumerator StartUnlockingChestUsingTimer()
    {
        yield return new WaitForSeconds(1);
        timer--;
        chestStatusText.text = "Unlocks in " + timer.ToString();
        timerToggle = true;
        int counter = (int) Mathf.Abs(timer / 10);
        unlockGemCountText.text = counter.ToString();
        if (timer <= 0)
        {
            OnChestUnlocked();
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
