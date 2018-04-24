using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private int bulletDamage = 15;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBulletPosition();
        CheckForAutoDestroy();
	}

    private void UpdateBulletPosition()
    {
        Vector3 velocityVector = new Vector3(0, bulletSpeed, 0);
        velocityVector = transform.rotation * velocityVector;
        transform.position += velocityVector * Time.deltaTime;
    }

    private void CheckForAutoDestroy()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
        if (distance > 20f)
        {
            Destroy(gameObject);
        }
    }

    public void MultiplyDamage(int value)
    {
        bulletDamage += value;
    }

    public int GetDamage()
    {
        return bulletDamage;
    }

}
