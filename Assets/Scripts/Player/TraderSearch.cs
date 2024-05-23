using UnityEngine;

public class TradeSearch : MonoBehaviour
{
    [SerializeField] private float reachDistance;
    private Camera _mainCamera;

    void Start()
    {
        SearchCamera();
    }
    private void SearchCamera()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Search();
    }
    private void Search()
    {
        Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward); // Пускаем луч из камеры
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, reachDistance) && hit.collider.GetComponent<Trader>() != null)
            {
                hit.collider.GetComponent<Trader>().OpenTradePanel();
            }
        }
    }
}
