using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBrick : Walkable
{
    public float MovingSpeed;
    public float MovingEdgeLeft;
    public float MovingEdgeRight;

    bool MoveDir = true; //true = right, false = left

    LayerManager LM;

    private void Start()
    {
        //LM = transform.parent.GetComponent<LayerManager>();
        SetStartStatus();
    }

    private void FixedUpdate()
    {
        BrickMoving();
    }

    void SetStartStatus()
    {
        int n = Mathf.FloorToInt((Phase - MovingEdgeRight) / (MovingEdgeRight - MovingEdgeLeft));
        float m = Phase - MovingEdgeRight - n * (MovingEdgeRight - MovingEdgeLeft);
        if (n == -1)
        {
            transform.position = new Vector3(Phase, transform.position.y, transform.position.z);
            MoveDir = true;
        }
        else if(n == 0)
        {
            transform.position = new Vector3(2 * MovingEdgeRight - Phase, transform.position.y, transform.position.z);
            MoveDir = false;
        }
        else if(n % 2 == 0)
        {
            transform.position = new Vector3(MovingEdgeRight - m, transform.position.y, transform.position.z);
            MoveDir = false;
        }
        else
        {
            transform.position = new Vector3(MovingEdgeLeft + m, transform.position.y, transform.position.z);
            MoveDir = true;
        }
    }

    void BrickMoving()
    {
        if(MoveDir)
        {
            transform.position += new Vector3(1, 0, 0) * MovingSpeed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position -= new Vector3(1, 0, 0) * MovingSpeed * Time.fixedDeltaTime;
        }
        if( transform.position.x <= MovingEdgeLeft)
        {
            MoveDir = true;
        }
        if(transform.position.x >= MovingEdgeRight)
        {
            MoveDir = false;
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {

    }
}
