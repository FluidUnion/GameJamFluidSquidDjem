using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TileControls : MonoBehaviour
{

    private bool MovingRight;
    private bool MovingLeft;

    private bool MovingDown;


    public float PreviousTime;
    public float FallTime = 0.8f;
    //public int speed;
    // Start is called before the first frame update


    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MovingRight = true;

            MovingRight = false;
        }
    }
    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            MovingLeft = true;
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
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        if (Time.time - PreviousTime > (Input.GetKey(KeyCode.S) ? FallTime / 10 : FallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            PreviousTime = Time.time;
        }
    }
}
