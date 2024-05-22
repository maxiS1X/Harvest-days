using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartSeeds : MonoBehaviour
{
    public GameObject Seed;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            Destroy(Seed);
        }
    }

}
