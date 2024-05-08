using UnityEngine;

public class PlantCreator : MonoBehaviour
{
    [SerializeField] Plant _plantPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.GetComponent<FarmSpot>() != null)
                {
                    Instantiate(_plantPrefab, hit.point, Quaternion.Euler(0, Random.Range(0, 360), 0));                   
                }
            }
        }
    }
}
