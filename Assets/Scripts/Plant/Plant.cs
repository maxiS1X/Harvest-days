using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public List<GameObject> cropsItemPrefabs = new List<GameObject>();
    public bool plantRipe = false;
    [SerializeField] private float _ripeTime = 5f;
    [SerializeField] private GameObject _smallPlant;
    [SerializeField] private GameObject _mediumPlant;
    [SerializeField] private GameObject _bigPlant;
    [SerializeField] private GameObject _readyPlant;
    [SerializeField] private GameObject _fruitPrefab;

    void Start()
    {
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        var wait = new WaitForSeconds(_ripeTime);

        yield return wait;
        _smallPlant.SetActive(false);
        _mediumPlant.SetActive(true);

        yield return wait;
        _mediumPlant.SetActive(false);
        _bigPlant.SetActive(true);

        yield return wait;
        _bigPlant.SetActive(false);
        _readyPlant.SetActive(true);
        plantRipe = true;

        //yield return wait;
        //_readyPlant.SetActive(false);

        //for (int i = 0; i < 3; i++)
        //{
        //    Vector3 spawnPosition = Random.insideUnitSphere + transform.position + Vector3.up * 1.5f;
        //    Instantiate(_fruitPrefab, spawnPosition, Random.rotation);
        //}
        //Destroy(gameObject);
    }
}
