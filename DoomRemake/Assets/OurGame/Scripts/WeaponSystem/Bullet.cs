using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "POOF MEDIA/WeaponSystem/Create Bullet/BulletData")]
public class Bullet : ScriptableObject
{
    [Header("Bullet General Settings")] [SerializeField]
    private GameObject BulletObject;
    [SerializeField] private GameObject BulletProjectileTrail;
    [SerializeField] private BulletType _bulletType = BulletType.MELEE;
    
    [Header("Bullet Damage Setting")] [SerializeField]
    private float BulletBaseDamage;
    private float BulletCritDamage;
}
