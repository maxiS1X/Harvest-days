using UnityEngine;

public class LockMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState =  CursorLockMode.Locked;
    }

   
}
