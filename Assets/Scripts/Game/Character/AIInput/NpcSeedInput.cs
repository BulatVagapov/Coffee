using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSeedInput : AbstractInput
{
    private Vector2 targetPoint;
    private float timeToWait;

    [SerializeField] private float maxTimeToWait;
    [SerializeField] private float distanceToCoffeMachine;

    // Start is called before the first frame update
    void Start()
    {
        SetTargetposition();

        timeToWait = maxTimeToWait + 1;
    }

    private void SetTargetposition()
    {
        targetPoint = PointOnFieldProvider.GetRandomPointOnField();
        direction = (targetPoint - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        if((CoffeeMachineStaticTransform.CoffeeMachineTransform.position - transform.position).sqrMagnitude < distanceToCoffeMachine)
        {
            if((targetPoint - (Vector2)transform.position).sqrMagnitude > (targetPoint - (Vector2)CoffeeMachineStaticTransform.CoffeeMachineTransform.position).sqrMagnitude)
            {
                SetTargetposition();
            }

            timeToWait = maxTimeToWait + 1;
        }
        
        if ((targetPoint - (Vector2)transform.position).sqrMagnitude < 0.1)
        {
            SetTargetposition();

            timeToWait = 0;
        }

        if (timeToWait < maxTimeToWait)
        {
            direction = Vector2.zero;
            timeToWait += Time.deltaTime;
            return;
        }

        direction = (targetPoint - (Vector2)transform.position).normalized;
    }
}
