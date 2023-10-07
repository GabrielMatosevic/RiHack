using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AArmor : AItem
{
    [Header("Armor Settings")]
    [SerializeField] protected float _healthBuff;
    [SerializeField] protected float _defenceBuff;
    [SerializeField] protected float _strengthBuff;
    [SerializeField] protected float _dexterityBuff;
    [SerializeField] protected float _agilityBuff;
    [SerializeField] protected float _luckBuff;
}
