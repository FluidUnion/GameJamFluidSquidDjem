using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInShape : MonoBehaviour
{
    public int FilledCubes;

    public int RemainingSpots;
    public int MaxSpots;

    public GameObject LastCollided;

    private TileControls TC;
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
        {
            if (collision.gameObject.CompareTag("Cubicle"))
            {
                {
                    FilledCubes += 1;
                }
                    Debug.Log(FilledCubes);

                    if (collision.gameObject.CompareTag("MainTetromino"))
                    {
                        LastCollided = collision.gameObject;
                        TC = LastCollided.GetComponent<TileControls>();

                        if (TC.grounded == true)
                        {
                            RemainingSpots = MaxSpots - FilledCubes;

                            Debug.Log(RemainingSpots);
                        }
                    }
                
            }
            }
        }
    }
