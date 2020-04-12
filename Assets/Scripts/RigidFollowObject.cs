using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class RigidFollowObject : MonoBehaviour
{
    public float Radius = 2;
    public float Speed = 1;
    public Transform FollowObject;

    public bool IsFollowing = true;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (IsFollowing && FollowObject != null)
        {
            var direction = FollowObject.position - transform.position;
            if (direction.magnitude >= Radius)
            {
                rigidbody.AddForce(direction * Speed);
            }
        }
    }

}
