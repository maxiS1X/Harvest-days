using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPaused : MonoBehaviour
{
    public GameObject menuPaused;
    [SerializeField] KeyCode keyMenuPaused;
    bool isMenuPaused = false;

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
        }

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
            Time.timeScale = 1f;
        }
    }

    public void MenuPausedContinue()
    {
        isMenuPaused = false;
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