using UnityEngine;

public class PlantAndCollectSeeds : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private float reachDistance = 3f;
    [SerializeField] private GameObject hotbarPanel;
    private InventoryManager _inventoryManager;

    private void Start()
    {
        CameraSearch();
    }
    void Update()
    {
        PlantAndCollect();
    }
    private void CameraSearch()
    {
        _inventoryManager = gameObject.GetComponent<InventoryManager>();
        _mainCamera = Camera.main; // ����� ������� �� �����
    }
    private void PlantAndCollect()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // ������� ��� �� ������
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Physics.Raycast(ray, out hit, reachDistance) && _inventoryManager.isOpened == false) // ��� ������� �� RMB ������� ��������
            {
                Planting(hit);
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, reachDistance) && _inventoryManager.isOpened == false) // ��� ������� �� LMB ���������� ��������
            {
                Collecting(hit);
            }
        }

    }
    private void Planting(RaycastHit hit)
    {
        var field = hit.collider.gameObject.GetComponent<Field>(); // ��������� �� ������� ������
        var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // ��������� ����� � �������

        if (field != null && field.FieldIsEmpty == true && hotbarSlot.item != null) // �������� �� ��������� ���� � ������ � �������� ������ �� � �������������
        {
            Debug.Log("������ ������");
            string nameSeeds = hotbarSlot.item.itemName; // ��������� �������� Item � ����

            switch (nameSeeds) // ������� �������� Item � ���������� Item ��� ��������������
            {
                case "CornSeeds": // ���� � ����� ������� ���� ������ � ������ Carrot Seeds, ��...
                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // ������� ������ ������� � ������� ������ ����� � ������

                    field.FieldIsEmpty = false; // ������ ������ �� �����
                    field.GetCrop(0);

                    AmountUpdate();
                    break;

                case "ParsnipSeeds": // ����� ����������
                    Instantiate(field.cropsPrefabs[1], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;
                    field.GetCrop(1);

                    AmountUpdate();
                    break;

                case "BeetSeeds": // ����� ����������
                    Instantiate(field.cropsPrefabs[2], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;
                    field.GetCrop(2);

                    AmountUpdate();
                    break;

                case "CarrotSeeds": // ����� ����������
                    Instantiate(field.cropsPrefabs[3], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;
                    field.GetCrop(3);

                    AmountUpdate();
                    break;

                default:
                    Debug.Log("Item not found");
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
    private void Collecting(RaycastHit hit)
    {
        var plant = hit.collider.gameObject.GetComponent<PlantGrowth>();

        if (plant != null && plant.plantRipe == true)
        {
            int cropID = hit.collider.gameObject.GetComponentInParent<Field>().crop;
            switch (cropID)
            {
                case 0:
                    Instantiate(plant.cropsItemPrefabs[0], hit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(plant.cropsItemPrefabs[0].transform.rotation.x, Random.Range(0, 360), plant.cropsItemPrefabs[0].transform.rotation.z));
                    hit.collider.gameObject.GetComponentInParent<Field>().FieldIsEmpty = true;
                    Destroy(plant.gameObject);
                    break;

                case 1:
                    Instantiate(plant.cropsItemPrefabs[1], hit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, Random.Range(0, 360), 90));
                    hit.collider.gameObject.GetComponentInParent<Field>().FieldIsEmpty = true;
                    Destroy(plant.gameObject);
                    break;

                case 2:
                    Instantiate(plant.cropsItemPrefabs[2], hit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, Random.Range(0, 360), 90));
                    hit.collider.gameObject.GetComponentInParent<Field>().FieldIsEmpty = true;
                    Destroy(plant.gameObject);
                    break;

                case 3:
                    Instantiate(plant.cropsItemPrefabs[3], hit.collider.gameObject.transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(plant.cropsItemPrefabs[3].transform.rotation.x, Random.Range(0, 360), plant.cropsItemPrefabs[3].transform.rotation.z));
                    hit.collider.gameObject.GetComponentInParent<Field>().FieldIsEmpty = true;
                    Destroy(plant.gameObject);
                    break;

            }
        }
    }

}