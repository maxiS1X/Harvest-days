using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    //Общие характеристи предметов
    public GameObject itemPrefab;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public int maxAmount = 30;
}
