using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Jump;
    public float Speed;
    public Rigidbody rb;
    public Vector3 Offset;
    public float BombForce;
    public GameObject Bomb;
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
       
       // Vector3 forward = mouseWorld - transform.position;
        //transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
       // transform.LookAt(Input.mousePosition);
       // Debug.Log(Input.mousePosition + ", " + mouseWorld);
        //Debug.DrawLine(transform.position,mouseWorld);
        if (Input.GetMouseButtonDown(0))
        {



           Vector3 mouse = Input.mousePosition;
           mouse.z = transform.position.z - Camera.main.transform.position.z;
           Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouse);

           var bomb = Instantiate(Bomb, transform.position + Offset, transform.rotation);

            // var direction = transform.position - mouseWorld;
            //Vector3 mouse = Input.mousePosition;
            //Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(
            //    mouse.x,
            //    mouse.y,
            //    transform.position.y));
            //Vector3 forward = mouseWorld - transform.position;

            bomb.GetComponent<Rigidbody>().AddForce(mouseWorld * BombForce, ForceMode.Impulse);
        }
        
        rb.AddForce(vector * Time.deltaTime);
    }
}
