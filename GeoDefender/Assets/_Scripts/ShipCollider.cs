using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour {
    private ShipShooter shipShooter;
	// Use this for initialization
	void Start () {
        shipShooter = GetComponentInChildren<ShipShooter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<AsteroidData>())
        {
            LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            levelManager.LoadLevel("03b Lose");
        }
        else if (obj.GetComponent<PowerUp>())
        {
            PowerUp powerUp = obj.GetComponent<PowerUp>();
            gameObject.GetComponentInChildren<ShipShooter>().AddPowerUp(powerUp.GetPowerType());
            obj.SetActive(false);
            GameObject.Find("GameManager").GetComponent<GameManager>().PowerUpConsumed();
        }
    }
}
