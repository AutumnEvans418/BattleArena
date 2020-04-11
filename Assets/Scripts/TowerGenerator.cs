using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    public GameObject TumblerPrefab;

    public int Floors = 4;

    public float Height;
    // Start is called before the first frame update
    void Start()
    {
        BuildTower();
    }

    public void BuildTower()
    {
        for (int i = 0; i < Floors; i++)
        {
            var top = Instantiate(TumblerPrefab, transform.position + Vector3.up * Height * i, transform.rotation, transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
