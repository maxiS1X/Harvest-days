using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform hotbarPanel;
    public List<HotbarSlot> slots = new List<HotbarSlot>();//�������� ������ ������
    private Camera mainCamera;
    private void Start()
    {
        ListFilling();
    }
    public void ListFilling()
    {
        //���������� ������
        for (int i = 0; i < hotbarPanel.childCount; i++)
        {
            if (hotbarPanel.GetChild(i).GetComponent<HotbarSlot>() != null)
            {
                slots.Add(hotbarPanel.GetChild(i).GetComponent<HotbarSlot>());
            }
        }
    }
}
