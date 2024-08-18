using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInShape : MonoBehaviour
{
    public int FilledCubes;

    public int RemainingSpots;
    public int MaxSpots;

    public GameObject LastCollided;

    public float CurrentlyNeededPercent;
    public float percentage;

    private TileControls TC;

    private List<Collider2D> Checked = new List<Collider2D>();

    public List<GameObject> InShape = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        percentage = 0;
    }

    private void Update()
    {
        Debug.Log(InShape.Count);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Cubicle"))
            {
                {
                    FilledCubes += 1;

                    InShape.Add(collision.gameObject);
                }
                //Debug.Log(FilledCubes);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("Cubicle"))
            {
                {
                    FilledCubes -= 1;

                InShape.Remove(collision.gameObject);
            }
                //Debug.Log(FilledCubes);
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainTetromino") && !Checked.Contains(collision))
        {
            LastCollided = collision.gameObject;
            TC = LastCollided.GetComponent<TileControls>();
            if (TC.grounded == true)
            {

                RemainingSpots = MaxSpots - FilledCubes;


                percentage = 0 + (100f / MaxSpots) * FilledCubes;
                Debug.Log(FilledCubes);
                //Debug.Log(percentage + "%");

                Checked.Add(collision);
                LastCollided = null;
                TC = null;
            }
        }
    }
}

//this comment is for the homies
