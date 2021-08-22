using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHandler : MonoBehaviour
{
    [SerializeField] TowerHandler towerPrefab;


    [SerializeField] bool isPlaceble;
    public bool IsPlaceable { get { return isPlaceble; } }
       
    void OnMouseDown()
    {
        if (isPlaceble)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);            
            isPlaceble = !isPlaced;            
        }        
    }
}
