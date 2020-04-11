using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject Camera;
    public float Speed;
    public Transform Follow;
    [HideInInspector]
    public Vector3 Offset;

    public bool UseOffset = true;

    // Start is called before the first frame update
    void Start()
    {
        if (UseOffset)
            SetupOffset();
    }

    public void SetupOffset()
    {
        if (Follow != null)
        {
            Offset = Camera.transform.position - Follow.position;
        }
    }
    private Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        if (Follow != null)
            Camera.transform.position = Vector3.SmoothDamp(Camera.transform.position, Follow.position + Offset, ref velocity, Speed);
    }
}
