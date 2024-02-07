using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 180.0f;
    public PlayerController player;

    void Update()
    {
        transform.Rotate(Vector3.up,rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){

            other.GetComponent<PlayerController>().addScore(1);
            Destroy(gameObject);
        }
    }
}
