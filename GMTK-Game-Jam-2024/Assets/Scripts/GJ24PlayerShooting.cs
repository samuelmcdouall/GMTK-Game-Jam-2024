using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GJ24PlayerShooting : MonoBehaviour
{
    GunSetting _currentGunSetting;

    [SerializeField]
    Material _shrinkMat;
    [SerializeField]
    Material _growMat;
    [SerializeField]
    Material _shrinkGrowMat;
    [SerializeField]
    MeshRenderer _playerGunMR;

    [SerializeField]
    GameObject _shrinkProjectile;
    [SerializeField]
    GameObject _growProjectile;
    [SerializeField]
    GameObject _shrinkGrowProjectile;

    [SerializeField]
    float _fireCooldown;
    float _fireCooldownTimer;
    [SerializeField]
    Transform _firePos;
    void Start()
    {
        _fireCooldownTimer = _fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_currentGunSetting)
            {
                case GunSetting.Shrink:
                    _currentGunSetting = GunSetting.Grow;
                    _playerGunMR.material = _growMat;
                    break;
                case GunSetting.Grow:
                    _currentGunSetting = GunSetting.Shrink;
                    _playerGunMR.material = _shrinkMat;
                    break;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) && _fireCooldownTimer < 0.0f)
        {
            _fireCooldownTimer = _fireCooldown;
            switch (_currentGunSetting)
            {
                case GunSetting.Shrink:
                    Instantiate(_shrinkProjectile, _firePos.position, Quaternion.identity);
                    break;
                case GunSetting.Grow:
                    Instantiate(_growProjectile, _firePos.position, Quaternion.identity);
                    break;
                default:
                    Instantiate(_shrinkGrowProjectile, _firePos.position, Quaternion.identity);
                    break;
            }
        }

        _fireCooldownTimer -= Time.deltaTime;
    }

    enum GunSetting
    {
        Shrink,
        Grow,
        ShrinkGrow
    }
}
