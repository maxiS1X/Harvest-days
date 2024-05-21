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
        _mainCamera = Camera.main; // Поиск каммеры на сцене
    }
    private void PlantAndCollect()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // Пускаем луч из камеры
        RaycastHit hit;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Physics.Raycast(ray, out hit, reachDistance) && _inventoryManager.isOpened == false) // При нажатии на RMB садится растение
            {
                Planting(hit);
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, reachDistance) && _inventoryManager.isOpened == false) // При нажатии на LMB собирается растение
            {
                Collecting(hit);
            }
        }

    }
    private void Planting(RaycastHit hit)
    {
        var field = hit.collider.gameObject.GetComponent<Field>(); // Компонент из объекта грядки
        var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // Компонент слота в хотбаре

        if (field != null && field.FieldIsEmpty == true && hotbarSlot.item != null) // Проверка на попадения луча в грядку и проверка грядки на её незасеянность
        {
            Debug.Log("Грядка пустая");
            string nameSeeds = hotbarSlot.item.itemName; // Заполняем название Item в поле

            switch (nameSeeds) // Сверяем название Item с доступными Item для взаимодействия
            {
                case "CornSeeds": // Если в слоте хотбара есть объект с именем Carrot Seeds, то...
                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // Спавним префаб лежащий в скрипте грядки прямо в грядке

                    field.FieldIsEmpty = false; // Теперь грядка не пуста
                    field.GetCrop(0);

                    AmountUpdate();
                    break;

                case "ParsnipSeeds": // Сдесь аналогично
                    Instantiate(field.cropsPrefabs[1], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;
                    field.GetCrop(1);

                    AmountUpdate();
                    break;

                case "BeetSeeds": // Сдесь аналогично
                    Instantiate(field.cropsPrefabs[2], hit.collider.gameObject.transform);

                    field.FieldIsEmpty = false;
                    field.GetCrop(2);

                    AmountUpdate();
                    break;

                case "CarrotSeeds": // Сдесь аналогично
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
                hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData(); // Очищаем ифу в слоте, ибо семена кончились
            }
            else
            {
                hotbarSlot.amount--; // Понижаем количество семян на один в слоте хотбара
                hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString(); // Обновляем текст в слоте хотбара
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