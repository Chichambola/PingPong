using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Tooltip("0- EnemySide, 1 - PlayerSide")]
    [SerializeField] private Zone[] _zones;
    
    [SerializeField] private Ball _ball;
    [SerializeField] private float _height;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _playerRacket;
    [SerializeField] private Vector2 _racketAreaSize;
    [SerializeField] private Transform _racketArea;
    [SerializeField] private float _sensitivity = 2f;
    
    private Thrower _thrower = new Thrower();
    private Vector3 _playerRacketPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 endPoint = _zones[0].GetRandomPoint();
            _ball.SetPosition(_startPoint.position);
            _ball.SetVelocity(_thrower.CalculateVelocityByHeight(_startPoint.position, endPoint, _height));
        }

        _playerRacket.localPosition = _playerRacketPosition;
        _playerRacketPosition += (-Vector3.right * Input.GetAxis("Mouse X") + Vector3.up * Input.GetAxis("Mouse Y")) * _sensitivity;

        _playerRacketPosition.x = Mathf.Clamp(_playerRacketPosition.x, -_racketAreaSize.x, _racketAreaSize.x);
        _playerRacketPosition.y = Mathf.Clamp(_playerRacketPosition.y, -_racketAreaSize.y, _racketAreaSize.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube(_racketArea.position, _racketAreaSize * 2f);
    }
}
