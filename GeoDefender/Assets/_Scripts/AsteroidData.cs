using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidData : MonoBehaviour {

    [SerializeField]
    private int health;
    [SerializeField]
    private int size;

    [SerializeField]
    private Sprite[] spriteArray;
    [SerializeField]
    GameObject asteroidBluePrint;
    private SpriteRenderer sr;

    private GameObject AsteroidField;
	// Use this for initialization
	void Start () {
        AsteroidField = GameObject.Find("AsteroidField");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LaserBullet laser = collision.gameObject.GetComponent<LaserBullet>();
        if (laser)
        {
            TakeDamage(laser.GetDamage());
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SetupNewAsteroids();
            Destroy(gameObject);
        }
    }

    public void SetupNewAsteroids()
    {
        if (size == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ReduceTotalSize();
            return;
        }
        AsteroidMovement am = GetComponent<AsteroidMovement>();
        int neg = 1;
        for (int i = 0; i < 2; i++)
        {
            float angleRange = Random.Range(15, 45) * i;
            Quaternion newAngle = Quaternion.Euler(0, 0, angleRange);
            GameObject newAsteroid = Instantiate(asteroidBluePrint, transform.position, transform.rotation, AsteroidField.transform);
            newAsteroid.GetComponent<AsteroidMovement>().SetVelocity(am.GetVelocity() * Random.Range(1.5f, 2.5f), newAngle, transform.rotation);
            if (neg == -1)
            {
                newAsteroid.GetComponent<AsteroidMovement>().ReverseRotation();
            }
            neg *= -1;
            newAsteroid.GetComponent<AsteroidData>().InitAsteroid(size);
        }
    }

    public void InitAsteroid(int _size)
    {
        size = _size - 1;
        health = (size + 1) * 45;
        //SetSprite();
    }

    private void SetSprite()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteArray[size];
    }
}
