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
    public Button btn_highScore;
    public string newGameSceneName;
    public string levelSceneName;
    public string highscoreSceneName;

    private void Awake()
    {
        btn_start.onClick.AddListener(NewGame);
        btn_levels.onClick.AddListener(OpenLevels);
        btn_exit.onClick.AddListener(ExitGame);
        btn_highScore.onClick.AddListener(HighScore);
    }

    private void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    private void OpenLevels()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    private void HighScore()
    {
        SceneManager.LoadScene(highscoreSceneName);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    
}
