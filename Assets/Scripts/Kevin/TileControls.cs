using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class TileControls : MonoBehaviour
{

    private bool MovingRight;
    private bool MovingLeft;

    private bool MovingDown;

    public float PreviousTime;
    public float PreviousInputTime;

    public float FallTime = 0.8f;
    public float TimeBetween = 0.7f;

    public float ActualTimeBetween;
    //public int speed;
    // Start is called before the first frame update

    public static int height = 20;
    public static int width = 10;

    public Vector3 rotationPoint;


    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MovingRight = true;

            StartCoroutine(TimeTillMove(PreviousInputTime));
        }
        if (context.canceled)
        {
            MovingRight = false;

            StopCoroutine(TimeTillMove(0f));
        }
    }
    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MovingLeft = true;

            StartCoroutine(TimeTillMove(PreviousInputTime));
        }
        if (context.canceled)
        {
            MovingLeft = false;

            StopCoroutine(TimeTillMove(0f));
        }
    }
    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MovingDown = true;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            if(!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);


            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if(ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        if (!ValidMove())
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, -1), 90);
        }
    }
    private void FixedUpdate()
    {
        if (Time.time - PreviousTime > (Input.GetKey(KeyCode.S) ? FallTime / 10 : FallTime))
        {
            transform.position += new Vector3(0, -1, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
            }

            PreviousTime = Time.time;
        }
    }
    public IEnumerator TimeTillMove(float MTime)
    {
        yield return new WaitForSeconds(MTime);

        if (MovingRight)
        {
            transform.position += new Vector3(1, 0, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }

            StartCoroutine(TimeTillMove(PreviousInputTime));
        }
        if (MovingLeft)
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }

            StartCoroutine(TimeTillMove(PreviousInputTime));
        }
    }
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            if (RoundedX <0 || RoundedX > width || RoundedY <0 || RoundedY >= height)
            {
                return false;
            }
        }
        return true;
    }
}
