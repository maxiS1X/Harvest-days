using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public bool FieldIsEmpty; // �������� ���������� ������
    public List<GameObject> cropsPrefabs = new List<GameObject>(); // ������ ��������, �������� ����� ���� ������� ������
    public int crop;

    private void Start()
    {
        FieldIsEmpty = true;
    }
    public void GetCrop(int cropID)
    {
        crop = cropID;
    }
}
