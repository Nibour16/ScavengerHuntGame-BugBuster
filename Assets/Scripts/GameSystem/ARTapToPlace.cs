using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;

    private ARRaycastManager _raycastManager;
    private List<ARRaycastHit> _arHits = new List<ARRaycastHit>();

    private GameObject _objectToPlace;

    void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        Vector2 touchPosition = GetHitPosition();

        if (_raycastManager.Raycast(touchPosition, _arHits, TrackableType.PlaneWithinPolygon) && GetHitPosition() != Vector2.zero)
        {
            if (_objectToPlace == null)
                _objectToPlace = Instantiate(objectToPlace, _arHits[0].pose.position, _arHits[0].pose.rotation);
            else
            {
                _objectToPlace.transform.position = _arHits[0].pose.position;
                _objectToPlace.transform.rotation = _arHits[0].pose.rotation;
            }
        }
    }

    private Vector2 GetHitPosition()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return Input.GetTouch(0).position;
        else if (Input.GetMouseButtonDown(0))
            return Input.mousePosition;
        else
            return Vector2.zero;
    }
}
