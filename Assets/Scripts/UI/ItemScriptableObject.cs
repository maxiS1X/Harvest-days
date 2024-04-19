using UnityEngine;

public enum ItemType {Crop, Seeds, Instrument} //���� ���������
public class ItemScriptableObject : ScriptableObject
{
    //����� ������������ ���������
    public ItemType type;
    public GameObject itemPrefab;
    public string itemName;
    public string itemDescription;
    public int maxAmount = 30;
}
