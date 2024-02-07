using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BowlingPinScript : MonoBehaviour
{
    public int score;
    public ScoreBowlingManager scoreManager;



    void Update()
    {
          if(transform.position.y <0)
          {
            scoreManager.updateScore();
            Destroy(gameObject);
          }
          
        
    }

 
}
