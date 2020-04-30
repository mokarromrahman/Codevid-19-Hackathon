using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mainmenu : MonoBehaviour
{
    public Button btn_start;
    public Button btn_levels;
    public Button btn_exit;
    public string newGameSceneName;
    public string levelSceneName;

    public void Awake()
    {
        btn_start.onClick.AddListener(NewGame);
        btn_levels.onClick.AddListener(OpenLevels);
        btn_exit.onClick.AddListener(ExitGame);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    public void OpenLevels()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
