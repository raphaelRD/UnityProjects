using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    void Start (){

        updateScoreText();
    }
    public void increaseScore(int amount){
        score += amount;
        updateScoreText();
    }

    void updateScoreText(){

        scoreText.text = "Score: "+score;
    }
}
