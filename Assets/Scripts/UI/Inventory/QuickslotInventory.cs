﻿using UnityEngine;
using UnityEngine.UI;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    [SerializeField] private Transform quickslotParent;
    [SerializeField] private InventoryManager inventoryManager;
    public int currentQuickslotID = 0;
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite notSelectedSprite;
    [SerializeField] private MenuPaused _menuManager;

    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw < 0.1 && _menuManager.isMenuPaused == false)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= quickslotParent.childCount-1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:

        }
        if (mw > -0.1 && _menuManager.isMenuPaused == false)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount-1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:
            
        }
        // Используем цифры
        for(int i = 0; i < quickslotParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyDown((i + 1).ToString()) && _menuManager.isMenuPaused == false) {
                // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentQuickslotID == i)
                {
                    // Ставим картинку "selected" на слот если он "not selected" или наоборот
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    }
                }
                // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                }
            }
        }
        //// Используем предмет по нажатию на левую кнопку мыши
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().item != null)
        //    {
        //        if (!inventoryManager.isOpened && quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == selectedSprite)
        //        {

        //            if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount <= 1)
        //            {
        //                quickslotParent.GetChild(currentQuickslotID).GetComponentInChildren<DragAndDropItem>().NullifySlotData();
        //            }
        //            else
        //            {
        //                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount--;
        //                quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().itemAmountText.text = quickslotParent.GetChild(currentQuickslotID).GetComponent<InventorySlot>().amount.ToString();
        //            }
        //        }
        //    }
        //}
    }

}
