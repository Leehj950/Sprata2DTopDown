using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;
    protected bool IsAttacking { get; set; }
    
    private float timeSinecLastAttack = float.MaxValue;

    protected CharacterStatsHandler stats { get; private set; }

    // protected 프로퍼티를 한 이유는 나만 바꾸고 싶지만 가져가는 건 내 상속받은 클래스들도 볼수있게!

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
       if (timeSinecLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinecLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && timeSinecLastAttack >= stats.CurrentStat.attackSO.delay)
        {
            timeSinecLastAttack = 0;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }

    public void CallMoveEvent(Vector2 Direction)
    {
        OnMoveEvent?.Invoke(Direction);
    }

    public void CallLookEvent(Vector2 Direction) 
    {
        OnLookEvent?.Invoke(Direction);
    }
    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
