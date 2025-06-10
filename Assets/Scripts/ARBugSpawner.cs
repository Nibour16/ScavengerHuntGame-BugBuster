using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARBugSpawner : BaseSpawner
{
    [SerializeField] private float chanceToSuccessfullySpawn;
    [SerializeField] private int maxSpawn;

    private float _spawnChance;
    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _arHits = new List<ARRaycastHit>();

    private Vector2 _screenPoint;

    private void Start()
    {
        _raycastManager = FindFirstObjectByType<ARRaycastManager>();
        SpawnObjectAtRandomPlace();
    }

    private void Update()
    {
        if (maxSpawn > 0)
            SpawnObjectAtRandomPlace();
    }

    private void SpawnObjectAtRandomPlace()
    {
        _spawnChance = UnityEngine.Random.Range(0, 100);
        var spawnPosition = GetRandomPositionOnPlane();
        if (_spawnChance < chanceToSuccessfullySpawn && spawnPosition != Vector3.zero)
        {
            RandomPickToSpawn(spawnPosition, Quaternion.Euler(0, UnityEngine.Random.Range(-180, 180), 0));
            maxSpawn--;
        }
    }

    private Vector3 GetRandomPositionOnPlane()
    {
        _screenPoint = new Vector2(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height));

        if (_raycastManager.Raycast(_screenPoint, _arHits, TrackableType.PlaneWithinBounds))
        {
            return _arHits[0].pose.position;
        }

        return Vector3.zero; // Return zero if no plane is detected
    }
}
