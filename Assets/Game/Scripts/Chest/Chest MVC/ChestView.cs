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
    private ChestDataSO data;
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


    }

    private void OnChestSlotButtonClicked()
    {
        UIManager.Instance.SetupChestPopup(data);
    }
    void Start()
    {
          
    }

    public void SetController(ChestController controller)
    {
        chestController = controller;
    }


   
    // Update is called once per frame
    void Update()
    {
        
    }
}
