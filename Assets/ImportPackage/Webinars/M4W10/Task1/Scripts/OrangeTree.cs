using System.Collections;
using UnityEngine;

public class OrangeTree : MonoBehaviour
{
    [SerializeField] Orange _orangePrefab;
    [SerializeField] Transform _spawnPoint;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        yield return null;
    }
}
