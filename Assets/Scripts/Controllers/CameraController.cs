using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CharacterManager CM;

    GameObject CamHandler;
    GameObject MainCam;

    private void Start()
    {
        MainCam = Camera.main.gameObject;
        CamHandler = transform.parent.gameObject;
        CM = transform.parent.parent.GetComponent<CharacterManager>();
        CM.CC = this;
    }

    private void FixedUpdate()
    {
        MainCam.transform.position = transform.position;
    }
}
