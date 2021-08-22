using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] int value = 75;

    public bool CreateTower(TowerHandler tower, Vector3 position)
    {
        PointHandler pointHandler = FindObjectOfType<PointHandler>();

        if(pointHandler == null)
        {
            return false;
        }

        if(pointHandler.CurrentBalance >= value)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            pointHandler.WithdrawPoints(value);
            return true;
        }

        return false;
        
    }
}
