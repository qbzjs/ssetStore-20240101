using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance;

    //This is the pool for ammo of all weapon types.
    [SerializeField] private Dictionary<WeaponType, int> ammoPool = new Dictionary<WeaponType, int>();

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
                ammoPool.Add(WeaponType, GetDefaultAmmoForGunType(WeaponType));
            }
            else
            {
                Debug.Log("The ammo type is already being saved in the dictionary!");
            }
        }
    }

    //normally this would be set in the inspector but this is incase the user forgets the default values of this list.
    private int GetDefaultAmmoForGunType(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.SMG:
                return 360;
            case WeaponType.SHOTGUN:
                return 120;
            case WeaponType.SPECIAL:
                return 80;
            case WeaponType.MELEE:
                return -1;
            case WeaponType.PISTOL:
                return 60;
            case WeaponType.MINIGUN:
                return 2000;
            case WeaponType.ASSAULT_RIFLE:
                return 300;
            case WeaponType.ROCKET_LAUNCHER:
                return 30;
            case WeaponType.GRENADE_LAUNCHER:
                return 30;
            default:
                return 0;
        }

        return 0;
    }


    //Use this to get the correct ammo type for the weapon type of the weapon we are using!
    public int GetAmmo(WeaponType weaponType)
    {
        return ammoPool.ContainsKey(weaponType) ? ammoPool[weaponType] : 0;
    }

    //This is maybe going to be used
    public void UseAmmoManagerAmmo(WeaponType weaponType, int ammoAmountToUse)
    {
        if (ammoPool.ContainsKey(weaponType))
        {
            ammoPool[weaponType] = Mathf.Max(0, ammoPool[weaponType] - ammoAmountToUse);
        }
    }
}