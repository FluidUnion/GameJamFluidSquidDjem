using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigBlock : MonoBehaviour
{
    GameObject lastInstantiatedBigObject;
    public GameObject[] BigTetrominoes;

    public List<GameObject> instantiatedBigObjects = new List<GameObject>();

    private void Start()
    {
        NewTetromino();
    }

    public void NewTetromino()
    {
        lastInstantiatedBigObject = Instantiate(BigTetrominoes[Random.Range(0, BigTetrominoes.Length)], transform.position, Quaternion.identity);
        instantiatedBigObjects.Add(lastInstantiatedBigObject);
    }
}