using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public List<GameObject> cropsItemPrefabs = new List<GameObject>();
    public bool plantRipe = false;
    public int crop;

    public void GetCrop(int cropID)
    {
        crop = cropID;
    }
}