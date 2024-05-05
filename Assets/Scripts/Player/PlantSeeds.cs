using UnityEngine;

public class PlantSeeds : MonoBehaviour
{
    private Camera _mainCamera;
    public float reachDistance = 3f;
    public GameObject hotbarPanel;


    void Update()
    {
        CameraSearch();
        Plant();
    }
    private void CameraSearch()
    {
        _mainCamera = Camera.main; // ����� ������� �� �����
    }
    private void Plant()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // ������� ��� �� ������
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKey(KeyCode.F)) // ��� ������� �� F ������� ��������
            {
                var field = hit.collider.gameObject.GetComponent<Field>(); // ��������� �� ������� ������
                var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // ��������� ����� � �������

                if (field != null) // �������� �� ��������� ���� � ������
                {
                    if (field.FieldIsEmpty == true) // �������� ������ �� � �������������
                    {
                        Debug.Log("������ ������");
                        if (hotbarSlot.item != null) // �������� �� ������� ���������� Item � ����� �������
                        {
                            string nameSeeds = hotbarSlot.item.itemName; // ��������� �������� Item � ����

                            switch (nameSeeds) // ������� �������� Item � ���������� Item ��� ��������������
                            {
                                case "Carrot Seeds": // ���� � ����� ������� ���� ������ � ������ Carrot Seeds, ��...
                                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // ������� ������ ������� � ������� ������ ����� � ������
                                    field.FieldIsEmpty = false; // ������ ������ �� �����

                                    if (hotbarSlot.amount <= 1)
                                    {
                                        hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData(); // ������� ��� � �����, ��� ������ ���������
                                    }
                                    else
                                    {
                                        hotbarSlot.amount--; // �������� ���������� ����� �� ���� � ����� �������
                                        hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString(); // ��������� ����� � ����� �������
                                    } 
                                    break;
                                case "Potato seeds": // ����� ����������
                                    Instantiate(field.cropsPrefabs[1], hit.collider.gameObject.transform);

                                    field.FieldIsEmpty = false;

                                    if (hotbarSlot.amount <= 1)
                                    {
                                        hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
                                    }
                                    else
                                    {
                                        hotbarSlot.amount--;
                                        hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString();
                                    }
                                    break;
                            }
                        }
                        //Instantiate();
                    }
                }
            }
        }
    }
}