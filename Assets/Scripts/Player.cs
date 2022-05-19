using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerShip;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _minX, _maxX, _minZ, _maxZ;
    [SerializeField] private float _tilt; // коэффициент поворота

    [SerializeField] private Transform _mainGun;
    [SerializeField] private GameObject _shotPrefab;

    [SerializeField] private float _shotDelay; // задержка между выстрелами
    private float _nextShotTime = 0; // время до следующего выстрела

    void Start()
    {
        _playerShip = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float moveHorizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        float moveVertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

        _playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * _playerSpeed;

        float clampedX = Mathf.Clamp(_playerShip.position.x, _minX, _maxX);
        float clampedZ = Mathf.Clamp(_playerShip.position.z, _minZ, _maxZ);

        _playerShip.position = new Vector3(clampedX, 0, clampedZ);

        _playerShip.rotation = Quaternion.Euler(_playerShip.velocity.z * _tilt, 0, -_playerShip.velocity.x * _tilt);

        if(Time.time > _nextShotTime && Input.GetButton(GlobalStringVars.FIRE1))
        {
            Instantiate(_shotPrefab, _mainGun.position, Quaternion.identity);
            _nextShotTime = Time.time + _shotDelay;
        }
    }
}
