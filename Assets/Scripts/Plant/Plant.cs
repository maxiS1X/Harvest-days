using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private float _ripeTime = 5f;
    [SerializeField] private GameObject _smallPlant;
    [SerializeField] private GameObject _mediumPlant;
    [SerializeField] private GameObject _bigPlant;
    [SerializeField] private GameObject _readyPlant;

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

        GetComponentInParent<PlantGrowth>().plantRipe = true;
    }
    
}
