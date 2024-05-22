using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>(); // Создание списка слотов
    [SerializeField] private float _reachDistance = 3f; // Дистанция с которой можно поднять предмет
    [SerializeField] private GameObject _inventoryBackground;
    [SerializeField] private List<Trader> _trade = new List<Trader>();
    [SerializeField] private Transform _inventoryPanel;
    [SerializeField] private Transform _hotbarPanel;
    [SerializeField] private MenuPaused _menuManager;
    private Camera _mainCamera;
    public bool isOpened;


    private void Start()
    {
        _inventoryBackground.SetActive(false);
        _inventoryPanel.gameObject.SetActive(false);

        CameraSearch();
        ListFilling();
    }
    private void CameraSearch()
    {
        _mainCamera = Camera.main; // Поиск каммеры на сцене
    }
    private void Update()
    {
        PickUpItem();

        if (Input.GetKeyDown(KeyCode.Tab) && _menuManager.isMenuPaused == false)
        {
            OpenAndCloseInventory();
        }
    }
    private void ListFilling()
    {
        // Заполнение списка
        for (int i = 0; i < _hotbarPanel.childCount; i++)
        {
            if (_hotbarPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(_hotbarPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        for (int i = 0; i < _inventoryPanel.childCount; i++)
        {
            if (_inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(_inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        
    }
    public void OpenAndCloseInventory()
    {
        isOpened = !isOpened;

        if (isOpened)
        {
            _inventoryBackground.SetActive(true);
            _inventoryPanel.gameObject.SetActive(true);
            gameObject.GetComponent<PlayerMouseMove>().enabled = false;
            Cursor.lockState = CursorLockMode.None; // Анлочит курсор
            Cursor.visible = true; // Делает видимым
        }
        else
        {
            _inventoryBackground.SetActive(false);
            _inventoryPanel.gameObject.SetActive(false);
            _trade[0]._tradePanel.SetActive(false);
            _trade[1]._tradePanel.SetActive(false);
            
            gameObject.GetComponent<PlayerMouseMove>().enabled = true;
            gameObject.GetComponent<Player>().canMove = true;

            Cursor.lockState = CursorLockMode.Locked; // Лочит курсор
            Cursor.visible = false; // Делает невидимым
            
        }
    }
    private void PickUpItem()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, _reachDistance, 7))
            {
                var ComponentItem = hit.collider.gameObject.GetComponent<Item>();

                if (ComponentItem != null) // Проверка на сталкивание с Item
                {
                    AddItem(ComponentItem.item, ComponentItem.amount, hit);
                    Destroy(hit.collider.gameObject); // Уничтожает подобранный объект
                }

                Debug.DrawRay(ray.origin, ray.direction * _reachDistance, Color.green);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * _reachDistance, Color.red);
            }
        }
    }
    private void AddItem(ItemScriptableObject _item, int _amount, RaycastHit hit)
    {
        foreach (InventorySlot slot in slots) //Проходимся по всем слотам
        {
            if (slot.item == _item) //Проверяем нет ли подобного айтема в слотах
            {
                if (slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount; //Добавляем к уже имеющимся айтемам те, что подобрали
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                continue;

            }
        }
        foreach (InventorySlot slot in slots) //Проходимся по всем слотам
        {
            if (slot.isEmpty == true) //Ищем свободный слот
            {
                //Заполняем всё нужную инфу в слот
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.itemSprite);
                slot.itemAmountText.text = _amount.ToString();
                return;
            }
            continue;
        }
        Instantiate(hit.collider.gameObject, gameObject.transform.position + Vector3.up + gameObject.transform.forward, hit.collider.gameObject.transform.rotation);
    }
}
