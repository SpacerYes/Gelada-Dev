// Added a physics system to change velocity based on controller move speed. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dn : MonoBehaviour
{
    private Rigidbody ballRigidbody;

    private void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HandTag"))
        {
            float collisionForce = collision.impulse.magnitude;

            Vector3 forceDirection = collision.relativeVelocity.normalized;
            float ballForce = collisionForce * 0.1f; 

            ballRigidbody.AddForce(forceDirection * ballForce, ForceMode.Impulse);
        }
    }
}


/*
 * OLDER SCRIPT USE IF IN DOUBT.
 * 
 * 
 * 
 * 
 * using UnityEngine;

public class dn : MonoBehaviour
{
    public float ballForce = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Controllers"))
        // Add tag to controllers Called Controllers
        {
            Vector3 collisionDirection = collision.contacts[0].point - transform.position;
            collisionDirection.Normalize();

            // Make ball go burrrrrr.
            GetComponent<Rigidbody>().AddForce(collisionDirection * ballForce, ForceMode.Impulse);
        }
    }
}
// for excell and geleda >:)
*/
