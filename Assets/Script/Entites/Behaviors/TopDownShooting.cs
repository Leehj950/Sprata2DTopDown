using System;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;
    private Vector2 aimDirection = Vector2.right;
    [SerializeField] private Transform projectileSpawnPosition;

    [SerializeField] private AudioClip ShootingClip;

   

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        
    }

    private void Start()
    {
        controller.OnAttackEvent += Onshot;

        controller.OnLookEvent += OnAim;

    }


    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void Onshot(AttackSO attackSO)
    {
        Debug.Log(attackSO);
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        float projecttilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangedAttackSO.numberOfProjectilesPerShot;

        if(rangedAttackSO == null) 
        {
            return;
        }

        float minAnagle = -(numberOfProjectilesPerShot / 2f) * projecttilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;

        for (int i = 0;  i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAnagle + i * projecttilesAngleSpace;
            float randomSpread = UnityEngine.Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);

            angle += randomSpread;
            CreateProjectlie(rangedAttackSO, angle);
        }
    }

    private void CreateProjectlie(RangedAttackSO rangedAttackSO, float angle)
    {
        Debug.Log(rangedAttackSO);
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool(rangedAttackSO.bulletNameTag);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectlieContoroller attackController = obj.GetComponent<ProjectlieContoroller>();
        attackController.InitializeAttack(RotateVector2(aimDirection, angle), rangedAttackSO);

        if (ShootingClip) SoundManager.PlayClip(ShootingClip);

    }

    private static Vector2 RotateVector2(Vector2 vector, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * vector;
    }
}