using System;
using UnityEngine;

public class TopDownAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("IsWalking");
    private static readonly int isHit = Animator.StringToHash("IsHit");
    private static readonly int Attack = Animator.StringToHash("attack");

    private readonly float magnituteThreshold = 0.5f;
    private HealthSystem healthSystem;
    protected override void Awake()
    {
        base.Awake();   
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        topDownController.OnAttackEvent += Attacking;
        topDownController.OnMoveEvent += Move;
        
        if(healthSystem != null)
        {
            healthSystem.OnDamage += Hit;
            healthSystem.OnInvincibillityEnd += InvincibilityEnd;
        }
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(isHit,false);
    }
}
