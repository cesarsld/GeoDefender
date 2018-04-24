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

    private float powerUpTimer = 12f;
    private float timer = 0;
    [SerializeField]
    private bool isPowerUpOn;
    [SerializeField]
    private PowerUpType powerUpType;

    private GameObject shipExtensions;

	// Use this for initialization
	void Start () {
        isPowerUpOn = false;
        shipExtensions = GameObject.Find("ShipExtensions");
        shipExtensions.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        FireLaser();
        UpdateTimer();
	}

    private void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPowerUpOn && powerUpType == PowerUpType.FireRate) shooterRate = 0.125f;
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
        if (isPowerUpOn && powerUpType == PowerUpType.Power)
        {
            bullet.GetComponent<LaserBullet>().MultiplyDamage(2);
            //change colour?
            bullet.GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
            bullet.GetComponentInChildren<SpriteGlow.SpriteGlowEffect>().GlowColor = Color.magenta;

        }
        if (isPowerUpOn && powerUpType == PowerUpType.TripleShot)
        {
            Vector3 offsetVectorRight = new Vector3(transform.position.x + 0.9f, transform.position.y - 0.3f, transform.position.z);
            Vector3 offsetVectorLeft = new Vector3(transform.position.x - 0.9f, transform.position.y - 0.3f, transform.position.z);
            bullet = Instantiate(laser, RotateAroundPivot(offsetVectorRight, transform.position, transform.rotation), transform.rotation, bulletKeeper.transform);
            bullet = Instantiate(laser, RotateAroundPivot(offsetVectorLeft, transform.position, transform.rotation), transform.rotation, bulletKeeper.transform);
        }
    }

    private void UpdateTimer()
    {
        if (isPowerUpOn)
        {
            timer += Time.deltaTime;
            if (timer >= powerUpTimer)
            {
                isPowerUpOn = false;
                timer = 0f;
                if (powerUpType == PowerUpType.FireRate)
                {
                    shooterRate = 0.25f;
                    CancelInvoke("SpawnBullet");
                    if (Input.GetKey(KeyCode.Space))
                    {
                        InvokeRepeating("SpawnBullet", 0.01f, shooterRate);
                    }
                }
                else if (powerUpType == PowerUpType.TripleShot)
                {
                    shipExtensions.SetActive(false);
                }
            }
        }
    }

    public void AddPowerUp(PowerUpType powerUp)
    {
        isPowerUpOn = true;
        powerUpType = powerUp;
        timer = 0f;
        if (powerUp == PowerUpType.TripleShot)
        {
            shipExtensions.SetActive(true);
        }
        else if (powerUp == PowerUpType.FireRate)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                shooterRate = 0.125f;
                CancelInvoke("SpawnBullet");
                InvokeRepeating("SpawnBullet", 0.01f, shooterRate);
            }
        }
    }

    private Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        Vector3 direction = point - pivot;
        direction = angle * direction;
        point = direction + pivot;
        return point;

    }
}
