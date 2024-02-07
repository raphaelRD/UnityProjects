using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointsManagerScript : MonoBehaviour
{
    int scoreTotal =0;
    public TextMeshProUGUI score;

    void Start()
    {

        score.text = "Score: "+scoreTotal;

    }
    public void updateScore()
    {
        Debug.LogError("Score antes "+scoreTotal);
        scoreTotal += 1;
        Debug.LogError("Score depois "+scoreTotal);
        score.text = "Score: "+scoreTotal;
    }
}
