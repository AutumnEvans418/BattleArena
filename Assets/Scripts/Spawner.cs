using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float Interval;
    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Interval);
            Instantiate(Object, transform.position + new Vector3(Random.Range(MinX,MaxX),0,0), Quaternion.identity, transform);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
