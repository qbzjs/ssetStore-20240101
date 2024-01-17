using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private WeaponController _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    [Header("Weapon Controller General Settings")]
    private Weapon equiptWeapon;

    [SerializeField] private Transform weaponLocation;
    [SerializeField] private Transform weaponMuzzlePoint;

    [SerializeField] private List<Weapon> unlockedWeapons = new List<Weapon>();
    [SerializeField] private List<Weapon> availableWeaponsOnMap = new List<Weapon>();

    [SerializeField] private WeaponType CurrentWeaponsType = WeaponType.MELEE;

    
    
    [Header("References")]
    [SerializeField] private AmmoManager _ammoManager;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void ShootEquiptWeapon()
    {
    }

    private void ReloadEquiptWeapon()
    {
    }

    private void SwapNextWeapon()
    {
    }

    private void SwapPreviousWeapon()
    {
    }

    private void UnlockWeapon()
    {
    }

    private void LockWeapon()
    {
    }

    private void UnlockAllWeapons()
    {
    }

    private void LockAllWeapons()
    {
    }

    private void UpgradeWeapon()
    {
    }

    private void UpgradeAllWeapons()
    {
    }
}