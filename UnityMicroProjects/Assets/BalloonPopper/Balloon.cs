using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Balloon : MonoBehaviour
{
    public int scoreToGive = 1;
    public int clickToPop = 5;
    public float scaleIncreasePerClick = 0.1f;
    public ScoreManager scoreManager;

    void OnMouseDown()
    {
        clickToPop -=1;
        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if(clickToPop == 0){

            scoreManager.increaseScore(scoreToGive);
            Destroy(gameObject);
        }

    }
   
}
