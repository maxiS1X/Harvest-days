using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>(); // Создание списка слотов
    private Camera mainCamera;
    public GameObject InventoryBackground;
    public bool isOpened;
    public float reachDistance = 3f; // Дистанция с которой можно поднять предмет

    private void Start()
    {
        InventoryBackground.SetActive(false);
        InventoryPanel.gameObject.SetActive(false);

        CameraSearch();
        ListFilling();
    }
    private void CameraSearch()
    {
        mainCamera = Camera.main; // Поиск каммеры на сцене
    }
    private void Update()
    {
        OpenAndCloseInventory();
        PickUpItem();
    }
    private void ListFilling()
    {
        // Заполнение списка
        for (int i = 0; i < InventoryPanel.childCount; i++)
        {
            if (InventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(InventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    private void OpenAndCloseInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Открытие/закрытие инвентаря 
        {
            isOpened = !isOpened;

            if(isOpened)
            {
                InventoryBackground.SetActive(true);
                InventoryPanel.gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMouseMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None; // Анлочит курсор
                Cursor.visible = true; // Делает видимым
            }
            else
            {
                InventoryBackground.SetActive(false);
                InventoryPanel.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMouseMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked; // Лочит курсор
                Cursor.visible = false; // Делает невидимым
            }
        }
    }
    private void PickUpItem()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward); // mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                var ComponentItem = hit.collider.gameObject.GetComponent<Item>();

                if (ComponentItem != null) // Проверка на сталкивание с Item
                {
                    AddItem(ComponentItem.item, ComponentItem.amount);
                    Destroy(hit.collider.gameObject); // Уничтожает подобранный объект
                }

                Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
            }
        }
    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots) //Проходимся по всем слотам
        {
            if (slot.item == _item) //Проверяем нет ли подобного айтема в слотах
            {
                if(slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount; //Добавляем к уже имеющимся айтемам те, что подобрали
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
                
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
                break;
            }
        }
    }
}
