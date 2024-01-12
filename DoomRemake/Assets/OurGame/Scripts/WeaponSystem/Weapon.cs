using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    enum GunType
    {
        SHOTGUN,
        ASSAULT_RIFLE,
        PISTOL,
        MINIGUN,
        ROCKET_LAUNCHER,
        MELEE,
        GRENADE_LAUNCHER,
        SMG
    };

    [SerializeField] private GunType gunType = GunType.SHOTGUN;

    [Header("Gun Sound Effects")]
    [SerializeField]
    private AudioClip GunShot_AudioClip;
    [SerializeField]
    private AudioClip Gun_Reloading_AudioClip;

    [Header("Gun Base Ammo Settings")] int currentMagAmmoCount = 30;
    [SerializeField]
    private int magMaxAmmo = 30;
    [SerializeField]
    private int maxAmmoAllowed = 240;
    
    [Header("Gun General Settings")] 
    [SerializeField]private GameObject GunObject;
    
}