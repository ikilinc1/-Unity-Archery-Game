using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    [SerializeField] 
    private TargetMovement targetMovement;

    [SerializeField] 
    private GameObject impactParticles;
    
    private AudioSource impactSound;
    
    // Start is called before the first frame update
    void Start()
    {
        targetMovement = GetComponent<TargetMovement>();
        impactSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            impactSound.volume = collision.relativeVelocity.normalized.magnitude;
            impactSound.Play();
            Instantiate(impactParticles, transform.position, impactParticles.transform.rotation);
            GameManager.score++;
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
