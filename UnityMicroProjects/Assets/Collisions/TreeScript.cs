using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    public Color hitColor;
    public MeshRenderer mr;

    private void OnCollisionEnter (Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        mr.material.color = hitColor;
    }
}
