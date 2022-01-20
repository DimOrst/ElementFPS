using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstSpring : MonoBehaviour
{
    public float BurstSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody RB = other.gameObject.GetComponent<Rigidbody>();
            RB.velocity = new Vector3(RB.velocity.x,BurstSpeed, RB.velocity.z);
        }
    }
}
