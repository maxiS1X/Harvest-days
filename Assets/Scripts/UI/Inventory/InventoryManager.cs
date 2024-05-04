using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform InventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>(); // �������� ������ ������
    private Camera mainCamera;
    public GameObject InventoryBackground;
    public bool isOpened;
    public float reachDistance = 3f; // ��������� � ������� ����� ������� �������

    private void Start()
    {
        InventoryBackground.SetActive(false);
        InventoryPanel.gameObject.SetActive(false);

        CameraSearch();
        ListFilling();
    }
    private void CameraSearch()
    {
        mainCamera = Camera.main; // ����� ������� �� �����
    }
    private void Update()
    {
        OpenAndCloseInventory();
        PickUpItem();
    }
    private void ListFilling()
    {
        // ���������� ������
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
        if (Input.GetKeyDown(KeyCode.Tab)) // ��������/�������� ��������� 
        {
            isOpened = !isOpened;

            if(isOpened)
            {
                InventoryBackground.SetActive(true);
                InventoryPanel.gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMouseMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None; // ������� ������
                Cursor.visible = true; // ������ �������
            }
            else
            {
                InventoryBackground.SetActive(false);
                InventoryPanel.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMouseMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked; // ����� ������
                Cursor.visible = false; // ������ ���������
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

                if (ComponentItem != null) // �������� �� ����������� � Item
                {
                    AddItem(ComponentItem.item, ComponentItem.amount);
                    Destroy(hit.collider.gameObject); // ���������� ����������� ������
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
        foreach (InventorySlot slot in slots) //���������� �� ���� ������
        {
            if (slot.item == _item) //��������� ��� �� ��������� ������ � ������
            {
                if(slot.amount + _amount <= _item.maxAmount)
                {
                    slot.amount += _amount; //��������� � ��� ��������� ������� ��, ��� ���������
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                break;
                
            }
        }
        foreach (InventorySlot slot in slots) //���������� �� ���� ������
        { 
            if (slot.isEmpty == true) //���� ��������� ����
            {
                //��������� �� ������ ���� � ����
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
