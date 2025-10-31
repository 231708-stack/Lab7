using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int collisionCount = 0;
    public GameObject LevelFaild;
    public GameObject LevelComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cone"))
        {
            collisionCount++;
            Debug.Log(collisionCount);
            if (collisionCount== 3)
            {
                LevelFaild.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            LevelComplete.SetActive(true);
        }
    }
}
