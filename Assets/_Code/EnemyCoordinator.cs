using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoordinator : MonoBehaviour
{
    [SerializeField] int reward = 25;
    [SerializeField] int penalty = 200;

    PointHandler pointHandler;


    void Start()
    {
        pointHandler = FindObjectOfType<PointHandler>();
    }

    public void RewardPoint()
    {
        if(pointHandler == null) { return; }
        pointHandler.PointDeposit(reward);
    }

    public void StealPoint()
    {
        if (pointHandler == null) { return; }
        pointHandler.WithdrawPoints(penalty);
    }


}
