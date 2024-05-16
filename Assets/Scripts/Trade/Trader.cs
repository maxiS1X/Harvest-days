using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public int _tradersID;
    [SerializeField] private GameObject _tradePanel;
    [SerializeField] private Transform _tradeSlots;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Money _money;
    public List<InventorySlot> slots = new List<InventorySlot>();

    void Start()
    {
        ListFilling();
        _tradePanel.SetActive(false);
    }
    private void ListFilling()
    {
        // Заполнение списка
        for (int i = 0; i < _tradeSlots.transform.childCount; i++)
        {
            if (_tradeSlots.transform.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(_tradeSlots.transform.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    public void DetermineID(int _tradersID)
    {
        switch (_tradersID)
        {
            case 0:
                _tradePanel.SetActive(true);
                _inventoryManager.OpenAndCloseInventory();
                break;

            case 1:
                BuyTrader();
                break;
        }
    }
    public void SellTrader()
    {
        int profit = 0;
        foreach (InventorySlot slot in slots)
        {
            if (slot.item != null)
            {
                if (slot.item.canSell == true)
                {
                    profit += slot.amount * slot.item.price;
                    Debug.Log(profit);

                    // убираем значения InventorySlot
                    slot.item = null;
                    slot.amount = 0;
                    slot.isEmpty = true;
                    slot.itemIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    slot.itemIcon.GetComponent<Image>().sprite = null;
                    slot.itemAmountText.text = "";
                }
            }
            _money.MoneyValue += profit;
            profit = 0;
        }
        _money.UpdateMoneyText();
    }
    private void BuyTrader()
    {

    }
}
