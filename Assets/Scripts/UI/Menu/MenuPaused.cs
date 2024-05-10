using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPaused : MonoBehaviour
{
    [SerializeField] private GameObject menuPaused;
    [SerializeField] private KeyCode keyMenuPaused;
    public bool isMenuPaused = false;

    private void Start()
    {
        menuPaused.SetActive(false);
    }
    private void Update()
    {
        ActiveMenu();
    }

    public void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
            if (isMenuPaused)
            {
                menuPaused.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else
            {
                menuPaused.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }
    public void MenuPausedContinue()
    {
        isMenuPaused = false;
        menuPaused.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
    public void MenuPausedSetting()
    {
        Debug.Log("Настройки");
    }
    public void MenuPausedMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}