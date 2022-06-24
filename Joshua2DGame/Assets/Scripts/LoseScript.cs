using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // let us move to other scenes, and also reload our current scene

public class LoseScript : MonoBehaviour
{
    public void RestartGame()
    {
        HUDScript.score = 0; // reset the score
        SceneManager.LoadScene(0); // loads the scene by build index or buy scene name
    }
}
