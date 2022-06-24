using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to UI elements

public class HUDScript : MonoBehaviour
{
    public Text SurvivalText;
    public Text scoreText;
    public float timer;
    public static int score; // any other script can use this variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString(); // display Score: xxxxx
        SurvivalText.text = "Time: " + timer.ToString("n0"); // show whole numbers and display time = Time: xxx
        timer += Time.deltaTime; // increase our timer
    }
}
