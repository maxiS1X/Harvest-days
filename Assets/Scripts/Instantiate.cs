using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
