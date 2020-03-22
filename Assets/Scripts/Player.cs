using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Jump;
    public float Speed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var vector = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            vector.x += Speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vector.x -= Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vector.y += Jump;
        }

        
        rb.AddForce(vector * Time.deltaTime);
    }
}
