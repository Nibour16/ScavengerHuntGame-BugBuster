using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public abstract class ARBaseSpawner : MonoBehaviour
{
    //List to keep track of objects that will be spawned
    [SerializeField] protected List<GameObject> spawnObjectList;

    protected ARPlaneManager arPlaneManager;

    protected virtual void Start()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    protected GameObject RandomPickToSpawn(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        /*Dictionary<float, List<GameObject>> rarityGroups = new Dictionary<float, List<GameObject>>();

        foreach (var obj in spawnObjectList)
        {
            if (!rarityGroups.ContainsKey(obj.GetComponent<BaseInteractable>().stat.rarity))
            {
                rarityGroups[obj.GetComponent<BaseInteractable>().stat.rarity] = new List<GameObject>();
            }
            rarityGroups[obj.GetComponent<BaseInteractable>().stat.rarity].Add(obj);
        }

        float lowestRarity = float.MaxValue;
        foreach (var rarity in rarityGroups.Keys)
        {
            if (rarity < lowestRarity)  lowestRarity = rarity;
        }

        if (rarityGroups.ContainsKey(lowestRarity))
        {
            List<GameObject> candidates = rarityGroups[lowestRarity];
            GameObject selectedObject = candidates[Random.Range(0, candidates.Count)];
            Instantiate(selectedObject, spawnPosition, spawnRotation);
        }*/

        float totalWeight = 0;

        foreach (var obj in spawnObjectList)
            totalWeight += obj.GetComponent<BaseInteractable>().stat.rarity;

        float randomValue = Random.Range(0, totalWeight);

        foreach (var obj in spawnObjectList)
        {
            if (randomValue < obj.GetComponent<BaseInteractable>().stat.rarity)
            {
                return Instantiate(obj, spawnPosition, spawnRotation);
            }
            randomValue -= obj.GetComponent<BaseInteractable>().stat.rarity;
        }

        return Instantiate(spawnObjectList[0], spawnPosition, spawnRotation);
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
