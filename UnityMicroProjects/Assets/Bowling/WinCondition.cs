using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
   public ScoreBowlingManager score;
   public GameObject winner;


    public void show(){

            Destroy(score.pinScore);
            Instantiate(winner,GameObject.FindGameObjectWithTag("Canvas").transform);
    }   
}
