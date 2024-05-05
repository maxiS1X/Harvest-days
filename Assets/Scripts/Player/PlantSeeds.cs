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
        _mainCamera = Camera.main; // Поиск каммеры на сцене
    }
    private void Plant()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // Пускаем луч из камеры
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (Input.GetKey(KeyCode.F)) // При нажатии на F садится растение
            {
                var field = hit.collider.gameObject.GetComponent<Field>(); // Компонент из объекта грядки
                var hotbarSlot = hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponent<InventorySlot>(); // Компонент слота в хотбаре

                if (field != null) // Проверка на попадения луча в грядку
                {
                    if (field.FieldIsEmpty == true) // Проверка грядки на её незасеянность
                    {
                        Debug.Log("Грядка пустая");
                        if (hotbarSlot.item != null) // Проверка на наличие выбранного Item в слоте хотбара
                        {
                            string nameSeeds = hotbarSlot.item.itemName; // Заполняем название Item в поле

                            switch (nameSeeds) // Сверяем название Item с доступными Item для взаимодействия
                            {
                                case "Carrot Seeds": // Если в слоте хотбара есть объект с именем Carrot Seeds, то...
                                    Instantiate(field.cropsPrefabs[0], hit.collider.gameObject.transform); // Спавним префаб лежащий в скрипте грядки прямо в грядке
                                    field.FieldIsEmpty = false; // Теперь грядка не пуста

                                    if (hotbarSlot.amount <= 1)
                                    {
                                        hotbarPanel.transform.GetChild(hotbarPanel.GetComponent<QuickslotInventory>().currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData(); // Очищаем ифу в слоте, ибо семена кончились
                                    }
                                    else
                                    {
                                        hotbarSlot.amount--; // Понижаем количество семян на один в слоте хотбара
                                        hotbarSlot.itemAmountText.text = hotbarSlot.amount.ToString(); // Обновляем текст в слоте хотбара
                                    } 
                                    break;
                                case "Potato seeds": // Сдесь аналогично
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