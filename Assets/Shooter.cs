using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour{
    public GameObject ballPrefab;
    public float speed;

    public float lifeSpan;
 
    public void Shot ()
    {
        GameObject ball =  (GameObject)Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.AddForce(transform.forward * speed);

        Destroy(ball, lifeSpan);
    }
}