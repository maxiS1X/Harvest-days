using UnityEngine;

public class TextNoSaves : MonoBehaviour
{
    [SerializeField] private GameObject _message; 
    
    private void SetActive()
    {
        _message.SetActive(false);
    }
    public void NoSaves()
    {
        Invoke("SetActive", 3);
    }
}
