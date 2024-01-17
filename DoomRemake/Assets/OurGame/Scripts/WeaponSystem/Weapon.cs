using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "WeaponData", menuName = "POOF MEDIA/WeaponSystem/Create Weapon/WeaponData")]
public class Weapon : ScriptableObject
{
    [SerializeField] private WeaponType gunType = WeaponType.MELEE;

    [Header("Gun Sound Effects")]
    [SerializeField]
    private AudioClip GunShot_AudioClip;
    [SerializeField]
    private AudioClip Gun_Reloading_AudioClip;
    [SerializeField] private AudioClip GunEmpty_AudioClip;

    [Header("Gun Ammo Settings")] int currentMagAmmoCount = 30;
    [SerializeField]
    private int currentAmmoInClip = 30;
    [SerializeField]
    private int maxAmmoInClip = 30;
    [SerializeField]
    private int totalAmmoForWeapon = 240;
    
    //Add in the eventual ammo settings so we can pick the bullet type using the scriptable objects systems for storing data for damage, pen, and what not

    [Header("Gun General Settings")] [SerializeField]
    private int GunLevel = 1;
    [SerializeField]private GameObject GunObject;
    [SerializeField]private Vector3 GunPositionOffset;
    
    [Header("Gun Reload Settings")] 
    [SerializeField] private float reloadTime;

    [Header("Gun Particle Effects")] [SerializeField]
    private GameObject gunHitEffect;

    [Header("Gun Shooting Settings")] [SerializeField]
    private float shotFireRate;
    [SerializeField] private float recoilAmount;
    [SerializeField] private float spreadAmount;
    
}