using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Zone : MonoBehaviour
{
    [SerializeField] private Transform _point;
    
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if(_point == null)
            return;
        
        Gizmos.DrawWireCube(transform.position, Vector3.ProjectOnPlane(_point.localPosition * 2f, Vector3.up));
    }

    public Vector3 GetRandomPoint()
    {
        Vector3 point = _transform.position;

        point += Vector3.right * Random.Range(-_point.localPosition.x,_point.localPosition.x);
        point += Vector3.forward * Random.Range(-_point.localPosition.z,_point.localPosition.z);

        return point;
    }
}
