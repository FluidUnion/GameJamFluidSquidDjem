using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClumpTogether : MonoBehaviour
{
    [SerializeField] private CheckInShape CheckShape;

    public GameObject CurrentShape;
    public GameObject NewParent;

    public GameObject[] DisableOnZoomOut;
    public GameObject[] EnableOnZoomOut;

    private bool isFilledCheck = true;

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
            if(isFilledCheck)
            {
                OnFilledTetromino();
                isFilledCheck = false;
            }
            foreach (GameObject i in CheckShape.InShape)
            {
                i.transform.SetParent(NewParent.transform);
            }
        }
    }

    public void OnFilledTetromino()
    {
        FindObjectOfType<SpawnBlock>().CanSpawn = false;
        StartCoroutine(AfterZoomOut());
        FindObjectOfType<CameraZoom>().ZoomOut();
    }

    IEnumerator AfterZoomOut()
    {
        yield return new WaitForSeconds(FindObjectOfType<CameraZoom>().zoomSpeed - 1.5f);
        foreach (GameObject obj in EnableOnZoomOut)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in DisableOnZoomOut)
        {
            obj.SetActive(false);
        }
    }
}
