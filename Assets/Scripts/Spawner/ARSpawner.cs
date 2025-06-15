using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSpawner : BaseSpawner
{
    [SerializeField] private float chanceToSpawn = 50;

    private float _spawnChance;

    [Obsolete("planesChanged (Why is it obsolete?)")]
    #pragma warning disable CS0809 // Obsolete member overrides non-obsolete member (or what else can I do for assigning specific one as obsolete)
    protected override void Start()
    #pragma warning restore CS0809 // Obsolete member overrides non-obsolete member (or what else can I do for assigning specific one as obsolete)
    {
        base.Start();
        if (_arPlaneManager != null)
            _arPlaneManager.planesChanged += OnPlanesChanged;
    }

    [Obsolete("ARPlanesChangedEventArgs (Why is it obsolete?)")]
    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (ARPlane plane in args.added)
            SpawnObject(plane);
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

    [Obsolete("planesChanged (Why is it obsolete?)")]
    private void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        if (_arPlaneManager != null)
            _arPlaneManager.planesChanged -= OnPlanesChanged;
    }
}
