using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    private Text myText;
    private int StarCount = 500;

    public enum Status { SUCCESS, FAILURE};
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        myText.text = "Stars : " + StarCount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        StarCount += amount;
        myText.text = "Stars : " + StarCount.ToString();
    }

    public Status UseStars(int amount)
    {
        if (StarCount >= amount)
        {
            StarCount -= amount;
            myText.text = "Stars : " + StarCount.ToString();
            return Status.SUCCESS;
        }
            return Status.FAILURE;
    }
}
