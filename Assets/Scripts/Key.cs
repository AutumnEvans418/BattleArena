using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    KeyDoor,
    PlayerDoor,
    ExitDoor
}

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(RigidFollowObject))]
[RequireComponent(typeof(Rigidbody))]
public class Key : MonoBehaviour
{
    public KeyType KeyType;
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

        if (other.gameObject.CompareTag("Key") && followObject.FollowObject == null)
        {
            sphereCollider.isTrigger = false;
            followObject.FollowObject = other.GetComponent<Key>().followObject.FollowObject;
            followObject.IsFollowing = true;
            rigidbody.isKinematic = false;
        }
    }
    
}
