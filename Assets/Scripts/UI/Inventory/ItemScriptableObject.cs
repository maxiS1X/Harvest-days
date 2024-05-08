using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    //����� ������������ ���������
    public GameObject itemPrefab;
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public int maxAmount = 30;
}
