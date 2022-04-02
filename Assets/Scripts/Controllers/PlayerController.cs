using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterManager CM;

    public string KeyInteract;
    public float HorVelocityMultiplier;
    public float HorVelocityLerpSpeed;
    public float FrontVelocityLerpSpeed;

    Rigidbody RB;
    Vector3 ThrustVelocity; // sudden additive speed
    float HorVelocity;
    float FrontVelocity;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HorMove();
        FrontMove();

        RB.velocity = new Vector3(HorVelocity, RB.velocity.y, FrontVelocity) + ThrustVelocity;
        ThrustVelocity = Vector3.zero;
    }

    /// <summary>
    /// Horizontal movement controlling
    /// </summary>
    private void HorMove()
    {
        HorVelocity = Mathf.Lerp(HorVelocity, Input.GetAxisRaw("Horizontal") * HorVelocityMultiplier, HorVelocityLerpSpeed);    
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
