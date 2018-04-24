using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy " + gameObject.name + " on scene load");
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += onLevelLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing Clip:" + thisLevelMusic);
        if (thisLevelMusic) { // If there's some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.volume = PlayerPrefsManager.GetMasterVolume();
            audioSource.Play();
        }

    }
    public void ChangeVolume(float value) {
        audioSource.volume = value;
    }
}
