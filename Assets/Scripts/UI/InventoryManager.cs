using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>(); //Создание списка слотов
    private Camera mainCamera;
    public GameObject UIPanel;
    private bool isOpened;
    public float reachDistance = 3f; //Дистанция с которой можно поднять предмет

    private void Start()
    {
        CameraSearch();
        ListFilling();
    }
    private void Update()
    {
        OpenAndCloseInventory();
        PickUpItem();
    }
    private void CameraSearch()
    {
        mainCamera = Camera.main; //Поиск каммеры на сцене
    }
    private void ListFilling()
    {
        //Заполнение списка
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpened = !isOpened;

            if(isOpened)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }
    }
    private void PickUpItem()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.green);
            var ComponentItem = hit.collider.gameObject.GetComponent<Item>();

            if(ComponentItem != null)
            {
                AddItem(ComponentItem.item, ComponentItem.amount);
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.red);
        }
    }
    private void AddItem(ItemScriptableObject _item, int _amount)
    {
        foreach (InventorySlot slot in slots) //Проходимся по всем слотам
        {
            if (slot.item == _item) //Проверяем нет ли подобного айтема в слотах
            {
                slot.amount += _amount; //Добавляем к уже имеющимся айтемам те, что подобрали
                return;
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
                return;
            }
        }
    }
}
