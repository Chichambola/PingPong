using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private InputReader _inputReader;

    private void FixedUpdate()
    {
        if(_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }
    }
}
