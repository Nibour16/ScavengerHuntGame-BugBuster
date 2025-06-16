using UnityEngine;
using UnityEngine.XR.ARFoundation;

public abstract class ARBaseSpawner : MonoBehaviour
{
    //List to keep track of objects that will be spawned
    [SerializeField] protected GameObject[] spawnObjectList;

    protected ARPlaneManager arPlaneManager;

    protected virtual void Start()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    protected void RandomPickToSpawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        float totalWeight = 0;

        foreach (var obj in spawnObjectList)
            totalWeight += obj.GetComponent<BaseInteractable>().stat.rarity;

        float randomValue = Random.Range(0, totalWeight);

        foreach (var obj in spawnObjectList)
        {
            if (randomValue < obj.GetComponent<BaseInteractable>().stat.rarity)
            {
                Instantiate(obj, spawnPosition, spawnRotation);
                return;
            }
            randomValue -= obj.GetComponent<BaseInteractable>().stat.rarity;
        }
    }

    protected Vector3 GetRandomPointInPlane(ARPlane plane)
    {
        // Generate random offsets within the plane's bounds
        float randomX = Random.Range(-plane.size.x / 2, plane.size.x / 2);
        float randomZ = Random.Range(-plane.size.y / 2, plane.size.y / 2);

        // Return the random position in world space
        return plane.transform.TransformPoint(new Vector3(randomX, 0, randomZ));
    }
}
