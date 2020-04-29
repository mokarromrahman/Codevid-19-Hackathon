using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timeStart = 5;
    public Text textBox;
    // Start is called before the first frame update
    //here is a script comment
    void Start()
    {
        textBox.text = timeStart.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart == 0){
            timeStart = 5;
        }
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();

    }
}
