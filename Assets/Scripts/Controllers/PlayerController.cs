using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterManager CM;

    public string KeyInteract;
    public string KeyLeft = "a";
    public string KeyRight = "d";

    public float HorVelocityMultiplier;
    public float HorVelocityLerpSpeed;
    public float FrontVelocityLerpSpeed;

    public Vector3 ThrustVelocity; // sudden additive speed

    Rigidbody RB;
    float HorVelocity;
    float FrontVelocity;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HorMove();
        FrontMove();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, CM.SM.PlayerAbstractPos, HorVelocityLerpSpeed), transform.position.y, transform.position.z);
        transform.position += new Vector3(0, 0, 1) * FrontVelocity * Time.fixedDeltaTime;

        //move with grid
        //RB.velocity = new Vector3(HorVelocity,RB.velocity.y,FrontVelocity) + ThrustVelocity;

        RB.velocity += ThrustVelocity;
        ThrustVelocity = Vector3.zero;
    }

    /// <summary>
    /// Horizontal movement controlling
    /// </summary>
    private void HorMove()
    {
        //move without grid
        HorVelocity = Mathf.Lerp(HorVelocity, Input.GetAxisRaw("Horizontal") * HorVelocityMultiplier, HorVelocityLerpSpeed);

        //move within grid
        if (Mathf.Abs(RB.velocity.y) < 0.1f)
        {
            if (Input.GetKeyDown(KeyLeft))
            {
                CM.SM.PlayerAbstractPos -= 1;
            }
            if (Input.GetKeyDown(KeyRight))
            {
                CM.SM.PlayerAbstractPos += 1;
            }
        }
    }

    /// <summary>
    /// just the speed forward
    /// </summary>
    private void FrontMove()
    {
        FrontVelocity = Mathf.Lerp(FrontVelocity, CM.SM.RunSpeed, FrontVelocityLerpSpeed);
    }

    /// <summary>
    /// all interactions here
    /// </summary>
    private void Interact()
    {
        if(Input.GetKeyDown(KeyInteract))
        {
            //do sth
        }
    }
}
