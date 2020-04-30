using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public static int CurrentScore = 0;

    public Text scoreText;

    void Start()
    {
        scoreText.text = CurrentScore.ToString();
    }

    private void Update()
    {
        scoreText.text = CurrentScore.ToString();
    }
}
