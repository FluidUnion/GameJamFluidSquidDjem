using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ClumpTogether : MonoBehaviour
{
    [SerializeField] private CheckInShape CheckShape;

    public GameObject CurrentShape;
    public GameObject NewParent;

    public GameObject[] DisableOnZoomOut;
    public GameObject[] EnableOnZoomOut;

    public SpawnBlock SpawnblockScript;
    public CheckInShape CheckInShapeScript;

    private bool isFilledCheck = true;

    // Update is called once per frame
    void Update()
    {
        CheckShape = CurrentShape.GetComponent<CheckInShape>();

        if (CheckShape.percentage >= CheckShape.CurrentlyNeededPercent)
        {
            if (isFilledCheck)
            {
                OnFilledTetromino();

                foreach (GameObject obj in CheckInShapeScript.InShape)
                {
                    SpawnblockScript.instantiatedObjects.Remove(obj);
                }

                StartCoroutine(DeleteChildrenWithDelay());

                isFilledCheck = false;
            }
            foreach (GameObject i in CheckShape.InShape)
            {
                i.transform.SetParent(NewParent.transform);
            }
        }
    }
    private IEnumerator DeleteChildrenWithDelay()
    {
        foreach (GameObject parentObj in SpawnblockScript.instantiatedObjects)
        {
            if (parentObj == null) continue;

            List<GameObject> childrenToDelete = new List<GameObject>();

            // Collect all children of the parent GameObject
            foreach (Transform child in parentObj.transform)
            {
                if (child != null) // Check if child is still valid
                {
                    childrenToDelete.Add(child.gameObject);
                }
            }

            // Destroy each child with delay
            foreach (GameObject child in childrenToDelete)
            {
                if (child != null) // Check if child is still valid
                {
                    Destroy(child);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }

    public void OnFilledTetromino()
    {
        //delete the cubes outside of the thing
        FindObjectOfType<SpawnBlock>().CanSpawn = false;
        StartCoroutine(AfterZoomOut());
        FindObjectOfType<CameraZoom>().ZoomOut();

        foreach (GameObject i in CheckShape.InShape)
        {
            i.transform.SetParent(NewParent.transform);
        }
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
