using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float LadderMoveSpeed;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody RB = other.gameObject.GetComponent<Rigidbody>();
            if(Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f)
            {
                RB.velocity = other.gameObject.transform.up * LadderMoveSpeed;
            }
        }
    }
}
