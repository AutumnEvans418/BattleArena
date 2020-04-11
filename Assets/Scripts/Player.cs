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
    public Transform targetPrefab;
    private Transform target;
    private PlayerInput2 input;

    public float ControllerAimSensitivity = 30;
    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerInput2();
        input.Player.Aim.performed += OnAim;
        input.Player.Fire.performed += OnFire;
        input.Player.Jump.performed += OnJump;
    }

    void Start()
    {
        var cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowObject>();
        cam.Follow = transform;
        cam.SetupOffset();
        target = Instantiate(targetPrefab, transform.position, transform.rotation);
    }
    private void OnDisable()
    {
        input.Disable();
    }

    void OnEnable()
    {
        input.Enable();
    }
    Vector2 vector = Vector2.zero;



    public void OnAim(InputAction.CallbackContext value)
    {
        var a = value.ReadValue<Vector2>();
        var b = new Vector3(a.x, a.y, 0);

        if (b.magnitude <= 1)
        {
            aimPosition = b * ControllerAimSensitivity;
            target.position = transform.position + aimPosition;
        }
        else
        {
            b.z = transform.position.z - Camera.main.transform.position.z;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(b);

            var position = mouseWorld - transform.position;

            aimPosition = position;
            target.position = position;
        }
        Debug.Log($"Before: {b}; Aim Position " + aimPosition);
    }
    Vector3 aimPosition = Vector3.zero;
    public void OnFire(InputAction.CallbackContext value)
    {
        var result = value.ReadValue<float>();

        if (result >= 1)
        {
            var bomb = Instantiate(Bomb, transform.position + (aimPosition.normalized * Offset), transform.rotation);
            bomb.GetComponent<Rigidbody>().AddForce(aimPosition * BombForce, ForceMode.Impulse);
        }
        
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (!IsGounded())
        {
            Debug.Log("Not grounded!");
            return;
        }

        var jump = value.ReadValue<float>();
        if (jump >= 1)
        {
            Debug.Log("Jumped!");
            vector.y += Jump;
        }
        
    }




    public float GroundDistance = 1;
    private bool IsGounded()
    {
        return Physics.Linecast(transform.position, transform.position + Vector3.down * GroundDistance);
    }

    public float VelocityReduction = 2;

    public float VelocityIncrease = 10;



    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * GroundDistance, Color.red);

        vector.x = input.Player.Move.ReadValue<Vector2>().x * Speed;

        var currentVelocity = rb.velocity;

        if (vector.x * currentVelocity.x > 0)
        {
            //same direction...
            vector.x /= VelocityReduction;
        }
        else if (vector.x * currentVelocity.x < 0)
        {
            vector.x *= VelocityIncrease;
        }

        if (vector != Vector2.zero)
        {
            rb.AddForce(vector * Time.deltaTime);
            vector = Vector2.zero;
        }
    }
}
