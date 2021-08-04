using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;
    [Range(0.0f,1.0f)]
    public float SmoothFactor =0.5f;
    public bool LookAtPlayer = true;

    public bool RotateArroundPlayer = true;
    [Range(0.0f,10.0f)]
    public float RotationSpeed=5.0f;
    void Start()
    {
        _cameraOffset=transform.position-PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos=PlayerTransform.position + _cameraOffset;
        transform.position=Vector3.Slerp(transform.position,newPos,SmoothFactor);

        if(RotateArroundPlayer){
Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*RotationSpeed, Vector3.up);
_cameraOffset=camTurnAngle*_cameraOffset;

        }
                if (LookAtPlayer||RotateArroundPlayer){
        transform.LookAt(PlayerTransform);

        }
    }
}
