using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIdicator;
    [SerializeField] private MouseManager mouseManager;
    [SerializeField] private Grid grid;

    private void Update() {
        Vector3 mousePos = mouseManager.GetSelectedGridPos();
        Vector3Int gridPos = grid.WorldToCell(mousePos);
        mouseIdicator.transform.position = gridPos;
    }
}
