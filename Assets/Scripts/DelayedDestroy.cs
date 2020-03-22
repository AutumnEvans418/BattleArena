using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float Delay;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
