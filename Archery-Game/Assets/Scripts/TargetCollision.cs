using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    private bool canCollide = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow") && canCollide)
        {
            canCollide = false;
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().isKinematic = false;
            TargetSpawner.totalTargets--;
            Debug.Log(TargetSpawner.totalTargets);
            Destroy(gameObject, 1f);
        }
    }
}
