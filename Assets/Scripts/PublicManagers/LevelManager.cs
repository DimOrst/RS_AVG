using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public CharacterManager CM;
    public float TargetRunSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SetRunSpeed(TargetRunSpeed);
    }

    private void FixedUpdate()
    {
        SetRunSpeed(TargetRunSpeed);
    }

    private void SetRunSpeed(float NewRunSpeed)
    {
        CM.SM.RunSpeed = NewRunSpeed;
    }
}
