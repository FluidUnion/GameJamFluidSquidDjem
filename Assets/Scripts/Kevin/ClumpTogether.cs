using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClumpTogether : MonoBehaviour
{
    [SerializeField] private CheckInShape CheckShape;

    public GameObject CurrentShape;

    public GameObject NewParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckShape = CurrentShape.GetComponent<CheckInShape>();

        if (CheckShape.percentage >= CheckShape.CurrentlyNeededPercent)
        {
            foreach (GameObject i in CheckShape.InShape)
            {
                i.transform.SetParent(NewParent.transform);
            }
        }
    }
}
