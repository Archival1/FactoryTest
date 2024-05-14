using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _placementLayerMask;

    private Vector3 _lastPosition;

    public Vector3 GetSelectedGridPos() { 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane;
        Ray ray = _camera.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray, out RaycastHit hit, 100, _placementLayerMask)) {
            _lastPosition = hit.point;
        }
        return _lastPosition;
    }
}
