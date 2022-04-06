using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base class of all walkable bricks
/// </summary>
public class Walkable : MonoBehaviour
{
    //Start phase of this brick
    public float Phase = 0;

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player walked on" + gameObject.name);
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            Debug.Log("Player walked on" + gameObject.name);
        }
    }
}
