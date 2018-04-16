using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour {
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private GameObject bulletKeeper;
    [SerializeField]
    private float shooterRate = 0.25f;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        FireLaser();
	}

    private void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("SpawnBullet", 0.01f, shooterRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("SpawnBullet");
        }
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(laser, transform.position, transform.rotation, bulletKeeper.transform);
        //bullet
    }
}
