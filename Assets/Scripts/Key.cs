using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(RigidFollowObject))]
[RequireComponent(typeof(Rigidbody))]
public class Key : MonoBehaviour
{
    private RigidFollowObject followObject;
    private SphereCollider sphereCollider;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        followObject = GetComponent<RigidFollowObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sphereCollider.isTrigger = false;
            followObject.FollowObject = other.transform;
            followObject.IsFollowing = true;
            rigidbody.isKinematic = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
