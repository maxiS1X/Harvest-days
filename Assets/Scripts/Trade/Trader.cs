using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public int _tradersID;
    public GameObject _tradePanel;
    public List<InventorySlot> slots = new List<InventorySlot>(); 
    [SerializeField] private List<GameObject> _product = new List<GameObject>();
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _tradeSlots;
    [SerializeField] private Transform _spawnProductPoint;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Money _money;
    

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
                _player.GetComponent<Player>().enabled = false;
                break;

            case 1:
                _tradePanel.SetActive(true);
                _inventoryManager.OpenAndCloseInventory();
                _player.GetComponent<Player>().enabled = false;
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
    public void BuyTrader(int ID)
    {
        switch(ID)
        {
            case 0:
                if(_money.MoneyValue >= _product[0].GetComponent<Item>().item.price)
                {
                    Instantiate(_product[0], _spawnProductPoint.position, Quaternion.identity);
                    _money.MoneyValue -= _product[0].GetComponent<Item>().item.price;
                }
                break;

            case 1:
                if (_money.MoneyValue >= _product[1].GetComponent<Item>().item.price)
                {
                    Instantiate(_product[1], _spawnProductPoint.position, Quaternion.identity);
                    _money.MoneyValue -= _product[1].GetComponent<Item>().item.price;
                }
                break; 

            case 2:
                if (_money.MoneyValue >= _product[2].GetComponent<Item>().item.price)
                {
                    Instantiate(_product[2], _spawnProductPoint.position, Quaternion.identity);
                    _money.MoneyValue -= _product[2].GetComponent<Item>().item.price;
                }
                break; 

            case 3:
                if (_money.MoneyValue >= _product[3].GetComponent<Item>().item.price)
                {
                    Instantiate(_product[3], _spawnProductPoint.position, Quaternion.identity);
                    _money.MoneyValue -= _product[3].GetComponent<Item>().item.price;
                }
                break;

            case 4:
                if (_money.MoneyValue >= _product[4].GetComponent<Item>().item.price)
                {
                    Instantiate(_product[4], _spawnProductPoint.position, Quaternion.identity);
                    _money.MoneyValue -= _product[4].GetComponent<Item>().item.price;
                }
                break;
        }
        _money.UpdateMoneyText();
    }
}
