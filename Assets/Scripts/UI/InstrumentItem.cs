using UnityEngine;

//����������� ��� ����������� (� ����� ������ ������ �����)
[CreateAssetMenu(fileName = "Instrument Item", menuName = "Inventory/Items/New Instrument Item")]
public class InstrumentItem : ItemScriptableObject
{
    private void Start()
    {
        type = ItemType.Instrument;
    }
}
