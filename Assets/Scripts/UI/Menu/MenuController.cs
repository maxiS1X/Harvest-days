using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private float _volume;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void NewGame()
    {
        SceneManager.LoadScene(2);

    }
    public void Settings()
    {
        SceneManager.LoadScene(4);

    }
    public void SureStart()
    {
        SceneManager.LoadScene(3);

    }
    public void Continue()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);

    }

    public void SureExit()
    {
        SceneManager.LoadScene(5);
    }
    public void Exit()
    {
        Application.Quit();
    }


    public void GameStartMenu()
    {
        SceneManager.LoadScene(1);

    }
}
