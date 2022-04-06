using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of all interactable objects in a level
/// </summary>
public class Interactives : MonoBehaviour
{
    public float Phase = 0;

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit" + gameObject.name);
        }
    }
}
