using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private float _volume;
    [SerializeField] TextNoSaves _text;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        SceneManager.LoadScene(4);

    }
    public void SureStart()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey("Money");
    }
    public void Continue()
    {

        if (!PlayerPrefs.HasKey("Money"))
        {
            _text.NoSaves();
        }
        else
        {
            SceneManager.LoadScene(1);
        }

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
