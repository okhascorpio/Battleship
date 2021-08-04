using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newController : MonoBehaviour
{
    public Transform Motor;
    [Range(1500.0f,2500.0f)]
    public float speed=1500f;
[Range(1500.0f,2500.0f)]
   
    public float steerSpeed=1500f;
    public Rigidbody boatBody;
    public Vector3 movement;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        boatBody=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
     //float h=Input.GetAxis("Vertical");
     float v=Input.GetAxis("Horizontal");
    movement=new Vector3(0.0f,0.0f,Input.GetAxis("Vertical"));
    rotation=new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
    boatBody.AddRelativeForce(movement*speed*Time.deltaTime);
    boatBody.AddForceAtPosition(-v*transform.right*steerSpeed*Time.deltaTime,Motor.position);
    
    }
   /*  void FixedUpdate(){
        moveCharacter(movement);
        steerBoat(rotation);
    }

    void moveCharacter(Vector3 direction){
            //boatBody.AddForce(direction*speed);
        
    }

    void steerBoat(Vector3 direction){

        boatBody.AddTorque(direction*steer);
    }*/
}
