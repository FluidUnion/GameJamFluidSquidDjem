using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] int points;

    [SerializeField] string Words;
    public TMP_Text pointsText;

    public TMP_Text ProgressText;
    public float ProgressFloat;

    public GameObject CurrentShape;

    private CheckInShape PS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PS = CurrentShape.GetComponent<CheckInShape>();

        points = PS.RemainingSpots;

        pointsText.text = ("Points: " + points.ToString());

        ProgressFloat = PS.percentage;

        ProgressText.text = ((int)ProgressFloat + "%");
    }
}
