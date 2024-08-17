using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInShape : MonoBehaviour
{
    public int FilledCubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cubicle"))
        {
            FilledCubes -= 1;

            Debug.Log(FilledCubes);
        }

    }
}
