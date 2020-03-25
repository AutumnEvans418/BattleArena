using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float Jump;
    public float Speed;
    public Rigidbody rb;
    public float Offset;
    public float BombForce;
    public GameObject Bomb;

    private List<GameObject> IsGounded = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") != true)
        {
            IsGounded.Remove(collision.gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") != true)
        {
            IsGounded.Add(collision.gameObject);
        }
    }
    Vector2 vector = Vector2.zero;

    public void OnMove(InputAction.CallbackContext value)
    {
        Debug.Log("moving!");
        vector.x = value.ReadValue<Vector2>().x * Speed;
    }

    public void OnAim(InputValue value)
    {
        aimPosition = value.Get<Vector2>();
    }
    Vector3 aimPosition = Vector3.zero;
    public void OnFire(InputValue value)
    {
        //aimPosition = value.Get<Vector2>();
        aimPosition.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(aimPosition);

        var position = mouseWorld - transform.position;

        var bomb = Instantiate(Bomb, transform.position + (position.normalized * Offset), transform.rotation);

        bomb.GetComponent<Rigidbody>().AddForce(position * BombForce, ForceMode.Impulse);
    }

    public void OnJump(InputValue value)
    {
        if (IsGounded.Any() != true)
        {
            return;
        }
        vector.y += Jump;
    }

    public float VelocityReduction = 2;

    public float VelocityIncrease = 10;
    // Update is called once per frame
    void Update()
    {
        var currentVelocity = rb.velocity;

        if (vector.x * currentVelocity.x > 0)
        {
            //same direction...
            vector /= VelocityReduction;
        }
        else if (vector.x * currentVelocity.x < 0)
        {
            vector *= VelocityIncrease;
        }

        if (vector != Vector2.zero)
        {
            rb.AddForce(vector * Time.deltaTime);
            vector = Vector2.zero;
        }
    }
}
