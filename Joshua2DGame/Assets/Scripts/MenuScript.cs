using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject menuCanvas; // access to show and hide menu
    public GameObject settingsCanvas; // show and hide settings
    public Slider volumeSlider; // access to the slider
    // Start is called before the first frame update
    void Start()
    {
        settingsCanvas.SetActive(false); // hide settings to start
    }

    // Update is called once per frame
    void Update()
    {
        SoundEffectManager.instance.volume = volumeSlider.value; // set the volume of our sound effects
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1); // load our play scene
    }

    public void Settings()
    {
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void Return()
    {
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }
}
