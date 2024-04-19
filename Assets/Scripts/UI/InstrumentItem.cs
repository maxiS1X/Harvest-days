using UnityEngine;

//Заготовочка для инструмента (в нашем случае только топор)
[CreateAssetMenu(fileName = "Instrument Item", menuName = "Inventory/Items/New Instrument Item")]
public class InstrumentItem : ItemScriptableObject
{
    private void Start()
    {
        type = ItemType.Instrument;
    }
}
