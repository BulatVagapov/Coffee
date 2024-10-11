using System;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineInput : AbstractInput
{
    private Vector2 targetPoint;
    private CharacterWithWaterDropThrower character;
    [SerializeField] private float targetPointDistance;
    [SerializeField] private float maxTimeToWait;
    [SerializeField] private int maxOfRegularAttackBeforeSpeshialAttack;
    private int needfullRegulatAttackForSpecialAttack;

    private float currentWaitTime;
    private int regularAttackCount;
    private int specialAttackNumber;
    private bool targetIsReached;
    private bool targetGot = false;


    public event Action StartRegularAttackEvent;
    public event Action StartCircularAttackEvent;
    public event Action StartCrazyAttackEvent;

   
    void Awake()
    {
        character = GetComponent<CharacterWithWaterDropThrower>();
        needfullRegulatAttackForSpecialAttack = UnityEngine.Random.Range(maxOfRegularAttackBeforeSpeshialAttack - 2, maxOfRegularAttackBeforeSpeshialAttack + 1);
    }

    private void SetTargetposition()
    {
        targetPoint = UnityEngine.Random.insideUnitCircle;

        targetPoint *= targetPointDistance;
        targetPoint += (Vector2)PlayerStaticTransform.PlayerTransform.position;

        targetPoint = PointOnFieldProvider.GetNearestPointOnField(targetPoint);
        direction = (targetPoint - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        if (character.WaterDropThrower.AttackInProcess) return;

        if ((targetPoint - (Vector2)transform.position).sqrMagnitude < 0.1 && !targetIsReached)
        {
            targetIsReached = true;
            targetGot = false;
            currentWaitTime = 0;

            if (regularAttackCount >= needfullRegulatAttackForSpecialAttack)
            {
                specialAttackNumber = UnityEngine.Random.Range(0, 2);

                switch (specialAttackNumber)
                {
                    case 0:
                        StartCircularAttackEvent?.Invoke();
                        break;
                    case 1:
                        StartCrazyAttackEvent?.Invoke();
                        break;
                }

                regularAttackCount = 0;
                needfullRegulatAttackForSpecialAttack = UnityEngine.Random.Range(maxOfRegularAttackBeforeSpeshialAttack - 2, maxOfRegularAttackBeforeSpeshialAttack + 1);
            }
            else
            {
                StartRegularAttackEvent?.Invoke();
                regularAttackCount++;
            }
  
            direction = Vector2.zero;
            return;
        }

        if (currentWaitTime < maxTimeToWait)
        {
            direction = Vector2.zero;
            currentWaitTime += Time.deltaTime;
            return;
        }

        if (!targetGot)
        {
            SetTargetposition();
            targetIsReached = false;
            targetGot = true;
            direction = (targetPoint - (Vector2)transform.position).normalized;
        }
    }
}
