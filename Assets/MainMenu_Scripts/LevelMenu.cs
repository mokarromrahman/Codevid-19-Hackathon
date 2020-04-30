using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Button btn_back;
    public string mainMenuScene;

    public Button btn_level1;
    public string level1Scene;

    public Button btn_level2;
    public Button btn_level3;
    public Button btn_level4;

    public void Awake()
    {
        btn_back.onClick.AddListener(GoToMainMenu);
        btn_level1.onClick.AddListener(GoToLevel1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene(level1Scene);
    }

}
