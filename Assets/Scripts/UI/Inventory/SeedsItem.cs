using UnityEngine;

// ����������� ��� �����
[CreateAssetMenu(fileName = "Seeds Item", menuName = "Inventory/Items/New Seed Item")]
public class SeedsItem : ItemScriptableObject
{
    private void Start()
    {
        type = ItemType.Seeds;
    }
}
