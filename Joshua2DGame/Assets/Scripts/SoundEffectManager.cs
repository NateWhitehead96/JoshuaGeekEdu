using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance; // the instance of this class

    private void Awake() // singleton design pattern
    {
        if(instance != null) // if there is an istance destroy this one
        {
            Destroy(gameObject);
        }
        else // if there isnt then make this one the instance
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public AudioSource explosion;
    public AudioSource shoot;
    public AudioSource powerup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
