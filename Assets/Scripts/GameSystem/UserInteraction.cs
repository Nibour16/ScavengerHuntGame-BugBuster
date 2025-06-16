using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UserInteraction : MonoBehaviour
{
    [SerializeField] protected float interactDistance = 2f;

    protected virtual void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
                Interact(hit, Input.GetTouch(0).position);
        }
    }

    protected void Interact(RaycastHit hit, Vector3 interactPosition)
    {
        if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var iInteractable))  //If the interacted object has connected to the interface IInteractable
        {
            //Run the interact method, depending on the object's job.
            iInteractable.OnInteract(interactPosition);
        }
    }
}
