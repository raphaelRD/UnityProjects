using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    public PointsManagerScript scoreManager;
    bool canHit=true;
    void OnTriggerEnter()
    {
        if(canHit== true){
        scoreManager.updateScore();
        Destroy(gameObject);
        canHit = false;
        }
        

    }

     void OnTriggerExit()
    {
        canHit = true;

    }
}
