using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeapon : AItem
{
    [Header("Weapon Settings")]
    [SerializeField] protected float _damage;
    [SerializeField] protected float _defence;
}
