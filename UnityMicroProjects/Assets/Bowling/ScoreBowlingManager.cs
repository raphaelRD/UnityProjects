using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBowlingManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI pinScore;
    public WinCondition win;

    void Start()
    {
        pinScore.text = "Score: "+score;
    
    }

    public void updateScore()
    {
       
            score +=1;
            pinScore.text = "Score: "+score;
            if(score ==5){
            win.show();
        }
        
          
    }
}
