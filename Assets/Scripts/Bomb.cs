using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Duration;
    public float Radius = 5;
    public GameObject ExplosionEffect;

    public float Force = 700;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Duration);
        Debug.Log("BOOM"); 
        var result = Instantiate(ExplosionEffect, transform.position, transform.rotation);

        var colliders = Physics.OverlapSphere(transform.position, Radius);

        foreach (var collider1 in colliders)
        {
            var rb = collider1.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Force, transform.position, Radius);
            }
        }

        Destroy(result, 2);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
