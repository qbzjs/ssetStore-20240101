using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    #region FIELDS

    public static AmmoManager Instance;

    [Header("General Settings")]
    //This is the pool for ammo of all weapon types.
    [SerializeField]
    private Dictionary<WeaponType, int> ammoPool = new Dictionary<WeaponType, int>();

    [Header("Ammo Pool Options")] [SerializeField]
    private bool InfiniteAmmo = false;

    [Header("MAX AMMO VALUES PER WEAPON")] [SerializeField]
    private Dictionary<WeaponType, int> weaponsMaxAmmoAmount = new Dictionary<WeaponType, int>();

    #endregion

    #region PROPERTIES

    #endregion

    #region METHODS

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeAmmoPool();
    }

    //I might do this or i might just make it get done by the editor by the player.
    void InitializeAmmoPool()
    {
        foreach (WeaponType WeaponType in Enum.GetValues(typeof(WeaponType)))
        {
            if (!ammoPool.ContainsKey(WeaponType))
            {
                ammoPool.Add(WeaponType, weaponsMaxAmmoAmount[WeaponType]);
            }
            else
            {
                Debug.Log("The ammo type is already being saved in the dictionary!");
            }
        }
    }

    //I might do this or i might just make it get done by the editor by the player.
    void InitializeWeaponsMaxAmmo()
    {
        foreach (WeaponType WeaponType in Enum.GetValues(typeof(WeaponType)))
        {
            if (!weaponsMaxAmmoAmount.ContainsKey(WeaponType))
            {
                weaponsMaxAmmoAmount.Add(WeaponType, MaxAmmoForWeaponsDefaultValue(WeaponType));
            }
            else
            {
                Debug.Log("The weapons max ammo is already being saved in the dictionary!");
            }
        }
    }

    private int MaxAmmoForWeaponsDefaultValue(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.MELEE:
                return -1;
            case WeaponType.GRENADE_LAUNCHER:
                return 50;
            case WeaponType.ROCKET_LAUNCHER:
                return 50;
            case WeaponType.ASSAULT_RIFLE:
                return 360;
            case WeaponType.SHOTGUN:
                return 80;
            case WeaponType.MINIGUN:
                return 2500;
            case WeaponType.PISTOL:
                return 100;
            case WeaponType.SMG:
                return 300;
            case WeaponType.SPECIAL:
                return 60;
            default:
                return 0;
        }
    }
    
    public bool CheckIfAmmoEmpty(WeaponType weaponType)
    {
        return ammoPool[weaponType] <= 0;
    }

    public int GetAmmoAmountForReload(WeaponType weaponType, int ClipSize)
    {
        if (ammoPool[weaponType] - ClipSize >= 0)
        {
            ammoPool[weaponType] -= ClipSize;
            return ClipSize;
        }
        else
        {
            ammoPool[weaponType] -= ammoPool[weaponType];
            return ammoPool[weaponType];
        }
    }

    public void AddAmmoCertainGun(WeaponType weaponType, int AmmoAmount)
    {
        ammoPool[weaponType] += AmmoAmount;
    }

    
    
    public void AddAmmoAllWeapons(int ammoAmount)
    {
        foreach (var weapon in ammoPool.Keys)
        {
            ammoPool[weapon] += ammoAmount;
        }
    }

    public void RemoveAmmoFromWeapon(WeaponType weaponType, int ammoAmount)
    {
        ammoPool[weaponType] -= ammoAmount;
    }

    public void RemoveAllWeaponAmmo()
    {
        foreach (var weapon in ammoPool.Keys)
        {
            ammoPool[weapon] += 0;
        }
    }

    //This function changes the max ammo of the weapon type that can be possibly stored.
    public void ChangeWeaponsTotalMaxAmmo(WeaponType weaponType, int newMaxAmmo)
    {
        weaponsMaxAmmoAmount[weaponType] = newMaxAmmo;
    }

    public void SetInfinteAmmoAllWeapons()
    {
        foreach (var weapon in ammoPool.Keys)
        {
            ammoPool[weapon] = 9999999;
        }

        InfiniteAmmo = true;
    }
    
    //This will be done in the future as right now its pointless and i have to change some stuff to make it feasible, so maybe.
    public void SetInfinteAmmoForWeapon()
    {
    }
    
    #endregion
}