using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string NextScene;

    public float FadeDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || (collision.gameObject.CompareTag("Key") && collision.gameObject.GetComponent<Key>().KeyType == KeyType.ExitDoor))
        {
            SceneManager.LoadScene(NextScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
