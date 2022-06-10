using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // let us move to other scenes, and also reload our current scene

public class LoseScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0); // loads the scene by build index or buy scene name
    }
}
