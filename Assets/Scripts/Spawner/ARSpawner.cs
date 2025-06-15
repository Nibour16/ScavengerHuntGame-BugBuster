using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSpawner : BaseSpawner
{
    [SerializeField] private float chanceToSpawn = 50;

    private float _spawnChance;

    private void Update()
    {
        foreach (ARPlane plane in _arPlaneManager.trackables)
        {
            if (plane.trackingState == TrackingState.Tracking)
                SpawnObject(plane);
        }  
    }

    private void SpawnObject(ARPlane plane)
    {
        _spawnChance = UnityEngine.Random.Range(0, 100);

        if (_spawnChance < chanceToSpawn)
        {
            RandomPickToSpawn
            (
                GetRandomPointInPlane(plane),
                Quaternion.Euler(plane.transform.rotation.x, UnityEngine.Random.Range(-180, 180), plane.transform.rotation.z)
            );
        }
    }
}
