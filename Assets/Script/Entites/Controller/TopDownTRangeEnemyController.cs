using System;
using UnityEngine;

public class TopDownTRangeEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;
    [SerializeField][Range(0f, 100f)] private float shootRanage = 10f;

    private int layerMastTarget;

    protected override void Start()
    {
        base.Start();
        layerMastTarget = stats.CurrentStat.attackSO.target;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceToTarget = DistanceToTarget();
        Vector2 dircetionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, dircetionToTarget);
    }

    private void UpdateEnemyState(float distanceToTarget, Vector2 dircetionToTarget)
    {
        IsAttacking = false;
        if (distanceToTarget <= shootRanage)
        {
            CheckifNear(distanceToTarget, dircetionToTarget);
        }
    }

    private void CheckifNear(float distance, Vector2 dircetionToTarget)
    {
        if (distance <= shootRanage)
        {
            TryShootAtTarget(dircetionToTarget);
        }
        else
        {
            CallMoveEvent(dircetionToTarget);
        }

    }

    private void TryShootAtTarget(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRanage, layerMastTarget);

        if (hit.collider != null)
        {
            PreformAttackAction(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    private void PreformAttackAction(Vector2 direction)
    {
        CallLookEvent(direction);
        CallMoveEvent(Vector2.zero);
        IsAttacking = true;
    }
};