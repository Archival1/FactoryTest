using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIdicator;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private Grid grid;

    [SerializeField] private ObjectManager objectManager;
    private int selectedObjectIndex = 0;

    [SerializeField] private GameObject gridVis;

    private void Start() {
        StopPlacement();
    }

    public void StopPlacement() {
        Debug.Log("StopPlacement");
        selectedObjectIndex = 0;
        gridVis.SetActive(false);
        mouseManager.OnClick -= PlaceStructure;
        mouseManager.OnExit -= StopPlacement;
    }

    public void StartPlacement(int id) {
        Debug.Log("StartPlacement");
        selectedObjectIndex = objectManager.objectsData.FindIndex(d => d.Id == id);
        if (selectedObjectIndex < 0) {
            Debug.LogError($"No object for {id} found");
            return;
        } else {
            gridVis.SetActive(true);
            mouseManager.OnClick += PlaceStructure;
            mouseManager.OnExit += StopPlacement;
        }
    }

    public void PlaceStructure() {
        if (mouseManager.IsPointerOverUi()) {
            return;
        }

        Vector3 mousePosition = mouseManager.GetSelectedGridPos();
        Vector3Int gridPos = grid.WorldToCell(mousePosition);
        GameObject gameObject = Instantiate(objectManager.objectsData[selectedObjectIndex].Prefab);
        gameObject.transform.position = grid.CellToWorld(gridPos);
    }

    private void Update() {
        Vector3 mousePos = mouseManager.GetSelectedGridPos();
        Vector3Int gridPos = grid.WorldToCell(mousePos);
        mouseIdicator.transform.position = gridPos;
    }
}
