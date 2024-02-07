using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  public float moveForce;
  public Rigidbody rig;

  void FixedUpdate()
  {
    float xInput = Input.GetAxis("Horizontal");

    rig.AddForce(Vector3.right * xInput * moveForce);
    rig.AddForce(Vector3.forward * 10f);

  }
}
