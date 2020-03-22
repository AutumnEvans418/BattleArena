using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Jump;
    public float Speed;
    public Rigidbody rb;
    public float Offset;
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = transform.position.z - Camera.main.transform.position.z;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouse);

            var position = mouseWorld - transform.position;

            var bomb = Instantiate(Bomb, transform.position + (position.normalized * Offset) , transform.rotation);

            bomb.GetComponent<Rigidbody>().AddForce(position * BombForce, ForceMode.Impulse);
        }

        rb.AddForce(vector * Time.deltaTime);
    }
}
