using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePrompt : MonoBehaviour
{
    public InputField textbox;
    public Button btn_OK;
    public GameObject prompt;
    // Start is called before the first frame update

    private void Awake()
    {
        btn_OK.onClick.AddListener(ClosePrompt);
    }

    private void ClosePrompt()
    {
        prompt.SetActive(false);
    }

    void Start()
    {
       
        if (Goal.GameOver)
            prompt.SetActive(true);
        else
            prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
