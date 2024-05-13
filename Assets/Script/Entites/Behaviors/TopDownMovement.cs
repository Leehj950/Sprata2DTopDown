using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    // 실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private CharacterStatsHandler characterStatsHandler;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 knonckback = Vector2.zero;
    private float knockbackDuration = 0.0f;


    private void Awake()
    {
        // 주로 내 컴포넌트안에서 끝나는거

        // controller랑 topdownMovement랑 같은 게임오브젝트 안에 있다는 가정

        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        movementDirection = vector;
    }

    private void FixedUpdate()
    {
        // FixedUpdate는 물리 업데이트 관련
        // rigibody 의 값을 바꾸니가 FixedUpdate
        ApplyMoveMenet(movementDirection);
        
        if(knockbackDuration > 0.0f) 
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration; 
        knonckback =  -(other.position - transform.position).normalized * power;
    }

    private void ApplyMoveMenet(Vector2 direction)
    {
        direction = direction * characterStatsHandler.CurrentStat.speed;
        
        if(knockbackDuration > 0.0f) 
        {
            direction += knonckback;

        }
        
        movementRigidbody.velocity = direction; 
    }
};