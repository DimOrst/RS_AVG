using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoard : Walkable
{
    public float JumpSpeed;

    public override void OnCollisionEnter(Collision collision)
    {
        collision.collider.gameObject.GetComponent<CharacterManager>().SendMessage("BurstUp", JumpSpeed);
    }
}
