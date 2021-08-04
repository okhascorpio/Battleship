﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Rigidbody))]
public class floating : MonoBehaviour
{
    // Start is called before the first frame update
public Transform FloatPoint1;
public Transform FloatPoint2;
public Transform FloatPoint3;
public Transform FloatPoint4;

    public float waterlevel = 0.0f;
    public float floatThreshold = 2.0f;
    public float waterDensity = 2.0f;
    public float downForce =0.0f;

    float forceFactor;
    Vector3 floatForce;
    // Update is called once per frame
    void FixedUpdate()
    {
        forceFactor = 1.0f -((transform.position.y-waterlevel)/ floatThreshold);

        if (forceFactor>0.0f){
            floatForce = -Physics.gravity *GetComponent<Rigidbody> ().mass * (forceFactor - GetComponent<Rigidbody> ().velocity.y * waterDensity);
            floatForce += new Vector3 (0.0f, -downForce*GetComponent<Rigidbody> ().mass, 0.0f);
            GetComponent<Rigidbody> ().AddForceAtPosition (floatForce, transform.position);
        }
        
    }
}
