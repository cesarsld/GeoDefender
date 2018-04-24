using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    FireRate,
    Power,
    TripleShot
}
public class PowerUp : MonoBehaviour {
    [SerializeField]
    private PowerUpType powerUpType;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPowerUpType(PowerUpType type)
    {
        powerUpType = type;
    }

    public PowerUpType GetPowerType()
    {
        return powerUpType;
    }
}
