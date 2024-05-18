using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _placementLayerMask;

    private Vector3 _lastPosition;

    public event Action OnClick, OnExit;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            OnClick?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUi() => EventSystem.current.IsPointerOverGameObject();

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
