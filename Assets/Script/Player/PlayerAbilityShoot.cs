using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{

    public GunBase gun001;
    public GunBase gun002;
    public Transform gunPosition;

    [SerializeField] private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        CreateGun();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
    }

    private void CreateGun()
    {
        _currentGun = gun001;
        _currentGun.gameObject.SetActive(true);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot() 
    {
        _currentGun.StartShoot();
        Debug.Log("Shoot");
    }
    private void CancelShoot() 
    {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }

    private void Update()
    {
        //ChangeGuns();
        inputs.Gameplay.Gun01.performed += cts => ChangeGun01();
        inputs.Gameplay.Gun02.performed += cts => ChangeGun02();
    }

    private void ChangeGun01()
    {
        if (_currentGun != null) _currentGun.gameObject.SetActive(false);
        _currentGun = gun001;
        _currentGun.gameObject.SetActive(true);
    }

    private void ChangeGun02()
    {
        if (_currentGun != null) _currentGun.gameObject.SetActive(false);
        _currentGun = gun002;
        _currentGun.gameObject.SetActive(true);
    }
}