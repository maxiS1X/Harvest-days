using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NewGame()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(1);
    }
    public void Continue()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);
    }
}
