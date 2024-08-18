using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Reset : MonoBehaviour
{
    private CheckInShape CIP;

    [SerializeField] private GameObject CurrentShape;

    private bool ResetActive;
    public void OnReset(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ResetActive = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CIP = CurrentShape.GetComponent<CheckInShape>();

        if (ResetActive)
        {
            foreach (GameObject i in CIP.InShape)
            {
                Destroy(i);
            }
            ResetActive = false;
        }
    }
}
