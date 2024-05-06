using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public List<GameObject> cropsItemPrefabs = new List<GameObject>();
    public float maxSize = 5;
    public float speed = 1;
    public bool plantRipe = false;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (transform.lossyScale.x < maxSize)
        {
            transform.localScale += Vector3.one * Time.fixedDeltaTime * speed;
        }
        else
        {
            plantRipe = true;
        }
    }
}