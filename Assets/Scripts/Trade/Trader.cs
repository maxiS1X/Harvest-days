using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();
    [SerializeField] private List<GameObject> _product = new List<GameObject>();

    public int _tradersID;
    public GameObject _tradePanel;

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _tradeSlots;
    [SerializeField] private Transform _spawnProductPoint;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Money _money;
    private AudioSource _sound;


    void Start()
    {
        ListFilling();
        _tradePanel.SetActive(false);
        _sound = GetComponent<AudioSource>();
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
    public void OpenTradePanel()
    {
        _tradePanel.SetActive(true);
        _player.GetComponent<Player>().canMove = false;
        _inventoryManager.OpenAndCloseInventory();
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
        _sound.Play();
    }
    public void BuyTrader(int ID)
    {
        if (_money.MoneyValue >= _product[ID].GetComponent<Item>().item.price)
        {
            Instantiate(_product[ID], _spawnProductPoint.position, Quaternion.identity);
            _money.MoneyValue -= _product[ID].GetComponent<Item>().item.price;
            _sound.Play();
        }
        _money.UpdateMoneyText();
    }
}
