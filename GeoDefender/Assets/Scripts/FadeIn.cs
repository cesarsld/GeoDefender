using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

    public float fadeInTime;
    public float FadeInDuration;

    private Image fadePanel;
    private Color currentColor = Color.black;

    // Use this for initialization
    void Start()
    {
        fadePanel = GetComponent<Image>();
        currentColor.a = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            if (Time.timeSinceLevelLoad > FadeInDuration) { 
            // Fade in
            float alphaChange = Time.deltaTime / FadeInDuration;
            currentColor.a += alphaChange;
            fadePanel.color = currentColor;
            }

        }
       
    }
}