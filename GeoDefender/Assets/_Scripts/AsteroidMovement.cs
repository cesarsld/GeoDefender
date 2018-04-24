using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    private Vector3 velocityVector;
    private Vector3 steadyRotation;
	// Use this for initialization
	void Awake () {
        steadyRotation = new Vector3(0, 0, -45f);
        //velocityVector = Vector3.zero;
        //velocityVector = Vector3.up;
    }
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();
        WarpPosition();
        UpdateRotation();
	}

    private void UpdateRotation()
    {
        transform.Rotate(steadyRotation * Time.deltaTime);
    }

    private void UpdatePosition()
    {
        transform.position += velocityVector * Time.deltaTime;
    }

    public void SetVelocity(Vector3 newVector, Quaternion newAngle, Quaternion parentRotation)
    {
        velocityVector = newAngle * newVector;
        transform.rotation = parentRotation;
    }
    public void RandomVelocityVector()
    {
        velocityVector = new Vector3(Random.Range(0.25f, 1f) * Mathf.Sign(Random.Range(-1, 1)), Random.Range(0.25f, 1f) * Mathf.Sign(Random.Range(-1, 1)), 0);
        transform.position = new Vector3(Random.Range(-12, 12f), Random.Range(-8, 8f), 0);
    }

    public void ReverseRotation()
    {
        steadyRotation *= -1;
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
