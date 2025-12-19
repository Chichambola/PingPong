using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public event Action CollisionDetected;
    
    private void OnCollisionEnter(Collision collision)
    {
        var rigidbody = collision.collider.attachedRigidbody;
        
        if (collision.collider.attachedRigidbody != null)
        {
            if (rigidbody.GetComponent<Ball>() != null)
            {
                CollisionDetected?.Invoke();
            }
        }
    }
}
