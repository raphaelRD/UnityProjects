using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
   public PickupType type;
   public int value;

   [Header("Bobbing")]
   public float rotateSpeed;
   public float bobSpeed;
   public float bobHeight;

   private Vector3 startPos;
   private bool bobbingUp;
   public AudioClip audioSfx;


   void Start(){
        startPos = transform.position;
        
   }

   void Update()
   {
     //rotacao
     transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

     //bob
     Vector3 offset = (bobbingUp==true ? new Vector3(0,bobHeight/2,0) : new Vector3(0,-bobHeight/2,0));
     transform.position = Vector3.MoveTowards(transform.position,startPos+ offset, bobSpeed * Time.deltaTime);

     if(transform.position == startPos + offset)
     {
        bobbingUp = !bobbingUp;
     }
   }

   void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    {
        Player player = other.GetComponent<Player>();
       
        switch (type)
        {
            case PickupType.Health:
            player.GiveHealth(value);
            other.GetComponent<AudioSource>().PlayOneShot(audioSfx);
            Destroy(gameObject);
            break;

            case PickupType.Ammo:
            player.GiveAmmo(value);
            other.GetComponent<AudioSource>().PlayOneShot(audioSfx);
            Destroy(gameObject);
            break;
        }

    }
   }
}
