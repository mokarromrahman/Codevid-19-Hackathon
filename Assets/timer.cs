using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float timeStart = 60;
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
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();

    }
}
