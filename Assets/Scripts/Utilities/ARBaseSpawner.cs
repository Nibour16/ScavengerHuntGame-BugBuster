using UnityEngine;
using UnityEngine.XR.ARFoundation;

public abstract class BaseSpawner : MonoBehaviour
{
    //List to keep track of objects that will be spawned
    [SerializeField] protected GameObject[] spawnObjectList;

    protected ARPlaneManager _arPlaneManager;

    protected virtual void Start()
    {
        _arPlaneManager = GetComponent<ARPlaneManager>();
    }

    protected void RandomPickToSpawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(spawnObjectList[Random.Range(0, spawnObjectList.Length)], spawnPosition, spawnRotation);
    }

    protected Vector3 GetRandomPointInPlane(ARPlane plane)
    {
        Vector2 size = plane.size;

        // Generate random offsets within the plane's bounds
        float randomX = Random.Range(-size.x / 2, size.x / 2);
        float randomZ = Random.Range(-size.y / 2, size.y / 2);

        // Return the random position in world space
        return plane.transform.TransformPoint(new Vector3(randomX, 0, randomZ));
    }
}
