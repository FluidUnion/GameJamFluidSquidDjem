using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float ZoomInSize = 2f;
    public float ZoomOutSize = 20f;
    public float zoomSpeed = 2f;
    private Camera cam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) // Zoom in
        {
            ZoomTo(ZoomInSize);
        }
        if (Input.GetKeyDown(KeyCode.X)) // Zoom out
        {
            ZoomTo(ZoomOutSize);
        }
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomTo(float newSize)
    {
        StopAllCoroutines();  
        StartCoroutine(ZoomRoutine(newSize));
    }

    private IEnumerator ZoomRoutine(float newSize)
    {
        float startSize = cam.orthographicSize;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * zoomSpeed;
            cam.orthographicSize = Mathf.Lerp(startSize, newSize, elapsed);
            yield return null;
        }

        cam.orthographicSize = newSize; 
    }
}
