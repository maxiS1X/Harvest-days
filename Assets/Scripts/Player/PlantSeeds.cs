using UnityEngine;

public class PlantSeeds : MonoBehaviour
{
    private Camera _mainCamera;
    public float reachDistance = 3f;
    public GameObject hotbarPanel;

    void Update()
    {
        CameraSearch();
        PlantAndCollect();
    }
    private void CameraSearch()
    {
        _mainCamera = Camera.main; // ����� ������� �� �����
    }
    private void PlantAndCollect()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // ������� ��� �� ������
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKey(KeyCode.Mouse1)) // ��� ������� �� RMB ������� ��������
            {
                Plant(hit);
            }
            if (Input.GetKey(KeyCode.Mouse0)) // ��� ������� �� LMB ������� ��������
            {
                Collect(hit);
            }
        }
    }
    private void Plant(RaycastHit hit)
    {
        var field = hit.collider.gameObject.GetComponent<Field>(); // ��������� �� ������� ������
        var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // ��������� ����� � �������

        if (field != null && field.FieldIsEmpty == true && hotbarSlot.item != null) // �������� �� ��������� ���� � ������ � �������� ������ �� � �������������
        {
            Debug.Log("������ ������");
            string nameSeeds = hotbarSlot.item.itemName; // ��������� �������� Item � ����

            switch (nameSeeds) // ������� �������� Item � ���������� Item ��� ��������������
            {
                case "Carrot Seeds": // ���� � ����� ������� ���� ������ � ������ Carrot Seeds, ��...
                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // ������� ������ ������� � ������� ������ ����� � ������

                    field.FieldIsEmpty = false; // ������ ������ �� �����

                    AmountUpdate();
                    break;

                case "Potato seeds": // ����� ����������
                    Instantiate(field.cropsPrefabs[1], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;

                    AmountUpdate();
                    break;
            }
        }
        void AmountUpdate()
        {
            if (hotbarSlot.amount <= 1)
            {
                hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData(); // ������� ��� � �����, ��� ������ ���������
            }
            else
            {
                hotbarSlot.amount--; // �������� ���������� ����� �� ���� � ����� �������
                hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString(); // ��������� ����� � ����� �������
            }
        }
    }
    private void Collect(RaycastHit hit)
    {
        var plant = hit.collider.gameObject.GetComponent<PlantGrowth>();
        if (hit.collider.gameObject.GetComponent<PlantGrowth>() != null)
        {
            if (hit.collider.gameObject.GetComponent<PlantGrowth>().plantRipe == true)
            {

            }
        }
    }

}