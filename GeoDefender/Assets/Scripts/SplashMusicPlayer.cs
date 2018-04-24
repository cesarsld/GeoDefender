using UnityEngine;
using System.Collections;

public class SplashMusicPlayer : MonoBehaviour {

    LevelManager Level;

    void Start() {
        Level = GameObject.FindObjectOfType<LevelManager>();
        StartCoroutine(timer());
    }

    public IEnumerator timer() {
        Debug.Log("timer started");
        yield return new WaitForSeconds(3f);
        Level.LoadLevel("01a Start");
    }
      
}
