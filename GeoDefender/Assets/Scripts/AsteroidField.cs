using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour {
    public GameObject ast;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        GameObject obj = Instantiate(ast, Vector3.zero, Quaternion.identity, gameObject.transform);
        obj.GetComponent<AsteroidData>().InitAsteroid(3);
        obj.GetComponent<AsteroidMovement>().SetVelocity(Vector3.up, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
    }
}
