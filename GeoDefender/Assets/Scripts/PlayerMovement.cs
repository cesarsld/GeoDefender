using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    private float movementSpeed = 5f;

    private float rotationSpeed = 90f;

    private float dampFactor = 1.5f;

    private Vector3 veloctyVector;
    private bool inputReceived;
    // Use this for initialization
    void Start () {
        veloctyVector = Vector3.zero;
        inputReceived = false;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateShipPosition();
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log(veloctyVector);
        }
    }


    private void UpdateRoration()
    {
        float inputValue = Input.GetAxis("Horizontal");
        if (inputValue == 0) return;
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= inputValue * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
    }

    private void UpdateVelocity()
    {
        float inputValue = Input.GetAxis("Vertical");
        if (inputValue != 0) inputReceived = true;
        else return;
        Vector3 velocity = new Vector3(0, inputValue * movementSpeed * Time.deltaTime, 0);
        velocity = transform.rotation * velocity;
        veloctyVector += velocity;
    }

    private void UpdateShipPosition()
    {
        UpdateRoration();
        UpdateVelocity();
        transform.position += veloctyVector * Time.deltaTime;
        DampenVelocity();
        WarpPosition();
        inputReceived = false;
    }

    private void DampenVelocity()
    {
        if (!inputReceived)
        {
            if (veloctyVector.magnitude <= 0.01f)
            {
                veloctyVector = Vector3.zero;
                return;
            }
            float divider = dampFactor / veloctyVector.magnitude;
            veloctyVector -= new Vector3(veloctyVector.x, veloctyVector.y, veloctyVector.z) * divider * Time.deltaTime;
            
        }
    }

    private void WarpPosition()
    {
        if (Mathf.Abs(transform.position.y) > 10) transform.position = new Vector3(transform.position.x, -1 * transform.position.y, transform.position.z);
        if (Mathf.Abs(transform.position.x) > 16) transform.position = new Vector3(-1 * transform.position.x, transform.position.y, transform.position.z);
    }

}
