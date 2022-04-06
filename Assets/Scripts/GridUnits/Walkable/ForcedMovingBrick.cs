using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedMovingBrick : Walkable
{
    public bool Left = true;
    public bool MoveFollow = false;
    bool StartFollow;
    float FollowDesination;
    float Speed = 0.3f;

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Left)
            {
                collision.gameObject.SendMessage("ForcedMovement", -1);
                FollowDesination = transform.position.x + -1;
            }
            else
            {
                collision.gameObject.SendMessage("ForcedMovement", 1);
                FollowDesination = transform.position.x + 1;
            }
            if (MoveFollow)
            {
                StartFollow = true;
                Speed = collision.gameObject.GetComponent<PlayerController>().HorVelocityLerpSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        if(StartFollow)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, FollowDesination, Speed), transform.position.y, transform.position.z);
        }
    }
}
