using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float timer;
    private LevelManager levelManager;
    
    private Slider slider;
    private new AudioSource audio;
    private bool isEndofLEvel = false;
    private GameObject WinLabel;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audio = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
        WinLabel = GameObject.Find("Win");
        WinLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
        slider.value = Time.timeSinceLevelLoad / timer;
        TimerCheck(Time.timeSinceLevelLoad);
	}

    void TimerCheck(float realTimer)
    {
        if (realTimer >= timer && !isEndofLEvel)
        {
            WinLabel.SetActive(true);
            audio.Play();
            Invoke("LoadNextLevel", audio.clip.length);
            isEndofLEvel = true;
            
        }
    }
    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
