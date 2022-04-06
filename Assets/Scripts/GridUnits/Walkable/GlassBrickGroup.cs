using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBrickGroup : MonoBehaviour
{
    public float FallingDelay;

    public List<Rigidbody> BrickGroupRB;
    public List<Collider> BrickGroupColl;

    public bool PlayerHit = false;

    void Update()
    {
        if(PlayerHit)
        {
            Invoke("SetBrickRB", FallingDelay);
        }
    }

    private void SetBrickRB()
    {
        foreach (var item in BrickGroupColl)
        {
            item.isTrigger = true;
        }
        foreach (var item in BrickGroupRB)
        {
            item.useGravity = true;
        }
        CancelInvoke("SetBrickRB");
    }
}
