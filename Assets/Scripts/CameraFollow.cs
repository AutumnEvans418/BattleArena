using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera;
    public float Speed;
    public Transform Follow;

    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        Offset = Camera.transform.position - Follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, Follow.position + Offset, Speed);
    }
}
