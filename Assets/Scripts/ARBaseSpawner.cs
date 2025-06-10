using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    //List to keep track of objects that will be spawned
    [SerializeField] protected GameObject[] spawnObjectList;

    //List to keep track of all spawned Objects
    private List<GameObject> _spawnedObjectList = new List<GameObject>();

    protected void RandomPickToSpawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        //Random pick an object and spawn it
        var spawnObject = spawnObjectList[Random.Range(0, spawnObjectList.Length)];
        _spawnedObjectList.Add(Instantiate(spawnObject, spawnPosition, spawnRotation));
    }
}
