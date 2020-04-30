using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NamePrompt : MonoBehaviour
{
    public Button btn_back;
    public InputField textbox;
    public Button btn_OK;
    public GameObject prompt;

    public static string name_input;

    // Start is called before the first frame update

    private void Awake()
    {
        btn_OK.onClick.AddListener(ClosePrompt);
        btn_back.onClick.AddListener(GoToMainMenu);
    }

    private void ClosePrompt()
    {
        prompt.SetActive(false);

        name_input = textbox.text;
    }

    private void GoToMainMenu()
    {
        UnityEngine.Debug.Log("Go to main menu");

        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
       
        if (Goal.GameOver)
        {
            prompt.SetActive(true);
            Goal.GameOver = false;
        }            
        else
            prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
