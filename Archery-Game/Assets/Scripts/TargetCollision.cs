using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] 
    private TargetMovement targetMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        targetMovement = GetComponent<TargetMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            targetMovement.enabled = false;
            collision.transform.parent = transform;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            TargetSpawner.totalTargets--;
            Destroy(gameObject, 1f);
        }
    }
}
