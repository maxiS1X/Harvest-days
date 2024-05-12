using System.Collections.Generic;
using UnityEngine;

public class TradeSearch : MonoBehaviour
{
    [SerializeField] private float reachDistance;
    [SerializeField] private Transform _tradePanel;
    [SerializeField] private Money _money;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private Camera _mainCamera;

    void Start()
    {
        SearchCamera();
    }
    private void SearchCamera()
    {
        _mainCamera = Camera.main;
    }
    private void ListFilling()
    {
        // Заполнение списка
        for (int i = 0; i < _tradePanel.childCount; i++)
        {
            if (_tradePanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(_tradePanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    void Update()
    {
        Search();
    }
    private void Search()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // Пускаем луч из камеры
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetMouseButton(1) && hit.collider.GetComponent<Trader>() != null)
            {
                DetermineID(hit.collider.GetComponent<Trader>()._tradersID);
            }
        }
    }
    public void DetermineID(int _tradersID)
    {
        switch (_tradersID)
        {
            case 0:
                SellTrader();
                break;

            case 1:
                BuyTrader();
                break;
        }
    }
    private void SellTrader()
    {
        int profit = 0;
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                if (slot.item.canSell == true)
                {
                    profit += slot.amount * slot.item.price;
                    return;
                }
                continue;
            }
            _money.MoneyValue += profit;
        } 
    }
    private void BuyTrader()
    {

    }
}
