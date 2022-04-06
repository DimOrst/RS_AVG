using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBrick : Walkable
{
    GlassBrickGroup GBG;

    // Start is called before the first frame update
    void Start()
    {
        GBG = transform.parent.GetComponent<GlassBrickGroup>();
        GBG.BrickGroupRB.Add(GetComponent<Rigidbody>());
        GBG.BrickGroupColl.Add(GetComponent<Collider>());
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GBG.PlayerHit = true;
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }
}
