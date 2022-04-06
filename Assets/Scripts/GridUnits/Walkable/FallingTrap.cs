using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : Walkable
{
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }
}
