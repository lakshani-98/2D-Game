using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    bool musicOn = true;
    private static MusicPlayer instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicEnabled"))
        {
            if (PlayerPrefs.GetString("MusicEnabled") == "True")
            {
                musicOn = true;
            }
            else if (PlayerPrefs.GetString("MusicEnabled") == "False")
            {
                musicOn = false;
            }
        }
        SceneManager.activeSceneChanged += changedActiveScene;
        TryPlayMusic();
    }

    void TryPlayMusic()
    {
        if (musicOn)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    public void ToggleMusic()
    {
        if (musicOn)
        {
            musicOn = false;
            PlayerPrefs.SetString("MusicEnabled", "False");
        }
        else
        {
            musicOn = true;
            PlayerPrefs.SetString("MusicEnabled", "True");
        }
        TryPlayMusic();
    }


    void changedActiveScene(Scene curent, Scene sceneGoingTo)
    {
        if (sceneGoingTo.name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }

}


