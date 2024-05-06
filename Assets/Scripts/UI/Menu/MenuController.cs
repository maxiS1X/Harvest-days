using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private float _volume;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        SaveSound();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(2);
        SaveSound();
    }
    public void Settings()
    {
        SceneManager.LoadScene(4);
        SaveSound();
    }
    public void SureStart()
    {
        SceneManager.LoadScene(3);
        SaveSound();
    }
    public void Continue()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);
        SaveSound();
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        if (GlobalVolume.volume != 0)
        {
            _volume = GlobalVolume.volume;
        }
    }

    private void SaveSound()
    {
        var volume = _volume;
    }
    public void GameStartMenu()
    {
        SceneManager.LoadScene(1);
        SaveSound();
    }
}
