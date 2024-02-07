using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallScript : MonoBehaviour
{
    public float forwardForce;
    public float leftBorder;
    public float rightBorder;
    public float moveIncrement;
    public Rigidbody rig;

    void Start(){

    }

    void Update(){

        if(transform.position.y < 0){
         Reset();
        }
        
    }

    public void Reset(){
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
            transform.position = new Vector3(0,1,-7);
            transform.rotation = Quaternion.identity;

    }
    public void Bowl()
    {
        rig.AddForce(transform.forward*forwardForce,ForceMode.Impulse);
    }

    public void MoveLeft()
    {
        if(transform.position.x > leftBorder)
        transform.position += new Vector3(-moveIncrement,0,0);
    }

    
    public void MoveRight()
    {
        if(transform.position.x < rightBorder)
        transform.position += new Vector3(moveIncrement,0,0);
    }
}
