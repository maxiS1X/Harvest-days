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
        _mainCamera = Camera.main; // Поиск каммеры на сцене
    }
    private void PlantAndCollect()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // Пускаем луч из камеры
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKey(KeyCode.Mouse1)) // При нажатии на RMB садится растение
            {
                Plant(hit);
            }
            if (Input.GetKey(KeyCode.Mouse0)) // При нажатии на LMB садится растение
            {
                Collect(hit);
            }
        }
    }
    private void Plant(RaycastHit hit)
    {
        var field = hit.collider.gameObject.GetComponent<Field>(); // Компонент из объекта грядки
        var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // Компонент слота в хотбаре

        if (field != null && field.FieldIsEmpty == true && hotbarSlot.item != null) // Проверка на попадения луча в грядку и проверка грядки на её незасеянность
        {
            Debug.Log("Грядка пустая");
            string nameSeeds = hotbarSlot.item.itemName; // Заполняем название Item в поле

            switch (nameSeeds) // Сверяем название Item с доступными Item для взаимодействия
            {
                case "Carrot Seeds": // Если в слоте хотбара есть объект с именем Carrot Seeds, то...
                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // Спавним префаб лежащий в скрипте грядки прямо в грядке

                    field.FieldIsEmpty = false; // Теперь грядка не пуста

                    AmountUpdate();
                    break;

                case "Potato seeds": // Сдесь аналогично
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
                hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData(); // Очищаем ифу в слоте, ибо семена кончились
            }
            else
            {
                hotbarSlot.amount--; // Понижаем количество семян на один в слоте хотбара
                hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString(); // Обновляем текст в слоте хотбара
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