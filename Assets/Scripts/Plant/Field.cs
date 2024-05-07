using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public bool FieldIsEmpty; // Параметр засеяности грядки
    public List<GameObject> cropsPrefabs = new List<GameObject>(); // Список префабов, которыми может быть засеяна грядка
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
