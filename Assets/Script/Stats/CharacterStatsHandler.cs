using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    // 기본 스텟과 추가스텟들을 계산해서 최종 스텟을 계산하는 로직이 있음
    // 근데 지금은 기본 스탯만

    [SerializeField] private CharacterStat baseStats;

    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        AttackSO attackSO = null;

        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }


        CurrentStat = new CharacterStat { attackSO = attackSO };
        // ToDo: 지금 기본 능력치만 적용되지만 앞으로는 능력치 강화기능이 적용된다.

        CurrentStat.statsChangeType = baseStats.statsChangeType;
        CurrentStat.maxHeatlth = baseStats.maxHeatlth;
        CurrentStat.speed = baseStats.speed;

    }
}
