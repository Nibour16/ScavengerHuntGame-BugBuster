using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSpawner : BaseSpawner
{
    [SerializeField] private float chanceToSpawn = 50;
    [SerializeField] private float spawnInterval = 3;

    private float _spawnChance;
    private bool _hasRunStart = false;
    private bool _isWaiting = false;

    private void Update()
    {
        if (!_hasRunStart)
        {
            base.Start();
            _hasRunStart = true;
        }

        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager not found in the scene.");
            return;
        }

        if (!_isWaiting)
            StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        if (arPlaneManager.trackables.count > 0)
        {
            _isWaiting = true;

            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                _spawnChance = UnityEngine.Random.Range(0, 100);

                if (_spawnChance < chanceToSpawn)
                {
                    RandomPickToSpawn
                    (
                        GetRandomPointInPlane(plane),
                        Quaternion.Euler(plane.transform.rotation.x, UnityEngine.Random.Range(-180, 180), plane.transform.rotation.z)
                    );
                    break;
                }
            }

            yield return new WaitForSeconds(spawnInterval);
            _isWaiting = false;
        }
        else
            yield return new WaitForSeconds(0);
    }
}
