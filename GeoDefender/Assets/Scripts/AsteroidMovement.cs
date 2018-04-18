using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Vector3 velocityVector;
	// Use this for initialization
	void Start () {
        //velocityVector = Vector3.zero;
        //velocityVector = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        WarpPosition();
	}

    private void UpdatePosition()
    {
        transform.position += velocityVector * Time.deltaTime;
    }

    public void SetVelocity(Vector3 newVector, Quaternion newAngle)
    {
        velocityVector = newAngle * newVector;
    }

    public Vector3 GetVelocity()
    {
        return velocityVector;
    }

    private void WarpPosition()
    {
        if (Mathf.Abs(transform.position.y) > 10) transform.position = new Vector3(transform.position.x, -1 * transform.position.y, transform.position.z);
        if (Mathf.Abs(transform.position.x) > 16) transform.position = new Vector3(-1 * transform.position.x, transform.position.y, transform.position.z);
    }
}
