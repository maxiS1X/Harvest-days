using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public bool FieldIsEmpty; // �������� ���������� ������
    public List<GameObject> cropsPrefabs = new List<GameObject>(); // ������ ��������, �������� ����� ���� ������� ������

    private void Start()
    {
        FieldIsEmpty = true;
    }
}
