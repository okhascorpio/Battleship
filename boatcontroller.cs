using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(floating))]
public class boatcontroller : MonoBehaviour
{
    public Vector3 COM;
    [Space(15)]
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;

    public float movementThreshold = 10.0f;

    Transform m_COM;
    float verticalInput;
    float horizontalInput;
    float movementFactor;
    float steerFactor;
    // Update is called once per frame
    void Update()
    {
        Balance();
        Movement();
        Steer();

    }
    void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);


        }
        m_COM.position = COM + transform.position;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;

    }
    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime);
        transform.Translate(0.0f, 0.0f, movementFactor * speed);
    }

    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput, Time.deltaTime);
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
    }
}

