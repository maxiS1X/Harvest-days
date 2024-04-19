using UnityEngine;

public enum ItemType {Crop, Seeds, Instrument} //Типы предметов
public class ItemScriptableObject : ScriptableObject
{
    //Общие характеристи предметов
    public ItemType type;
    public GameObject itemPrefab;
    public string itemName;
    public string itemDescription;
    public int maxAmount = 30;
}
