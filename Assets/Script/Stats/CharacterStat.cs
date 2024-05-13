using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
// 데이터 폴더 처럼 사용할 수 있게 만들어주는 Attribute

public enum StatsChangeType
{
    Add,
    Multipie,
    Override
}

[System.Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHeatlth;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;
}

