using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBlock : MonoBehaviour
{
    GameObject lastInstantiatedObject;
    public GameObject[] Tetrominoes;
    public bool CanSpawn = true;

    public List<GameObject> instantiatedObjects = new List<GameObject>();

    private ClumpTogether LastClump = new ClumpTogether();

    private Scene CurrentScene;

    private GameObject Clump;

    private void Start()
    {
        //CurrentScene = SceneManager.GetActiveScene();

        //Clump = LastClump.NewParent;

        //if (CurrentScene.name == "SecondMainScene")
        //{
            //Instantiate<GameObject>(Clump);
        //}
        //else
        //{
            NewTetromino();
        //}
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