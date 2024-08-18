using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class TileControls : MonoBehaviour
{

    private bool BlockRight;
    private bool BlockLeft;

    private bool MovingRight;
    private bool MovingLeft;

    private bool MovingDown;

    public bool grounded;

    public float PreviousTime;
    public float PreviousInputTime;

    public float FallTime = 0.8f;
    public float TimeBetween = 0.7f;

    public float ActualTimeBetween;

    public static int height = 20;
    public static int width = 10;

    public Vector3 rotationPoint;

    private static Transform[,] grid = new Transform[width, height];


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

    // Update is called once per frame
    void Update()
    {
        if (!ValidMove())
        {
            if (BlockRight)
            {
                transform.position -= new Vector3(1, 0, 0);
            }
            if (BlockLeft)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            if (!BlockLeft && !BlockRight)
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && grounded == false)
        {
            transform.position += new Vector3(1, 0, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.A) && grounded == false)
        {
            transform.position += new Vector3(-1, 0, 0);


            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q) && grounded == false)
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
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
                AddToGrid();
                FindObjectOfType<SpawnBlock>().NewTetromino();

                grounded = true;
                this.enabled = false;
            }

            PreviousTime = Time.time;
        }
    }
    public IEnumerator TimeTillMove(float MTime)
    {
        yield return new WaitForSeconds(MTime);

        if (MovingRight && grounded == false)
        {
            transform.position += new Vector3(1, 0, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }

           StartCoroutine(TimeTillMove(PreviousInputTime));
        }
        else if (MovingLeft && grounded == false)
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }

           StartCoroutine(TimeTillMove(PreviousInputTime));
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.position.x);
            int roundedY = Mathf.RoundToInt(children.position.y);


            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            if (RoundedX <0 || RoundedX >= width || RoundedY <0 || RoundedY >= height)
            {
                return false;
            }

            if (grid[RoundedX, RoundedY] != null)
                return false;
        }
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RightBlockade"))
        {
            BlockRight = true;
        }

        if(collision.gameObject.CompareTag("LeftBlockade"))
        {
            BlockLeft = true;
        }
    }
    ///fix rotation
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightBlockade"))
        {
            BlockRight = false;
        }

        if (collision.gameObject.CompareTag("LeftBlockade"))
        {
            BlockLeft = false;
        }
    }
}
