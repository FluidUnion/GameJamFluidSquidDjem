using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    GameObject lastInstantiatedObject;
    public GameObject[] Tetrominoes;
    public bool CanSpawn = true;

    public List<GameObject> instantiatedObjects = new List<GameObject>();

    private void Start()
    {
        NewTetromino();
    }

    private void Update()
    {
        if (!CanSpawn)
        {
            Destroy(lastInstantiatedObject);
        }
    }

    public void NewTetromino()
    {
        if (CanSpawn)
        {
            lastInstantiatedObject = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);
            instantiatedObjects.Add(lastInstantiatedObject);
        }
    }
}