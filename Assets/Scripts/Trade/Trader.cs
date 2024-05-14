using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public int _tradersID;
    [SerializeField] private Transform _tradeSlots;
    [SerializeField] private GameObject _tradePanel;
    [SerializeField] private Money _money;
    public List<InventorySlot> slots = new List<InventorySlot>();

    void Start()
    {
        ListFilling();
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
                }
            }
            _money.MoneyValue += profit;
            profit = 0;
        }
    }
    private void BuyTrader()
    {

    }
}
