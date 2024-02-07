using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallEnemy : MonoBehaviour
{
    public float speed;
    public GameObject target;
    private Collider other;

   
    void Update()
    {
        
                 
    }

    void OnTriggerStay(Collider player)
    {
        if(player.CompareTag("Player")){
            
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,speed * Time.deltaTime);
            if(transform.position == target.transform.position)
            {
                SceneManager.LoadScene(3);
            }
        }
        
    }
}
