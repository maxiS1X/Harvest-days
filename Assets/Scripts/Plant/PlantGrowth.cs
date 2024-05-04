using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float maxSize = 5;
    public float speed = 1;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (transform.lossyScale.x < maxSize)
        {
            transform.localScale += Vector3.one * Time.deltaTime * speed;
        }
    }
}