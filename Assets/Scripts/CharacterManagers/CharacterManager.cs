using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public StateManager SM;
    public PlayerController PC;
    public CameraController CC;

    public LevelManager LM;

    private void Awake()
    {
        SM = GetComponent<StateManager>();
        if(SM == null)
        {
            SM = gameObject.AddComponent<StateManager>();
        }
        PC = GetComponent<PlayerController>();
        if (PC == null)
        {
            PC = gameObject.AddComponent<PlayerController>();
        }

        SM.CM = this;
        PC.CM = this;

        LM = FindObjectOfType<LevelManager>();
        LM.CM = this;
    }
}
