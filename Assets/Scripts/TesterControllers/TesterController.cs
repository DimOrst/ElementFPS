using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterController : MonoBehaviour
{
    Rigidbody RB;
    public float JumpSpeed;
    public float MoveSpeed;

    public GameObject FootSensor;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CharacterMove();
    }

    public void CharacterMove()
    {
        Vector3 TempVerSpeed = new Vector3(0, RB.velocity.y, 0);
        RB.velocity = MoveSpeed * transform.forward * Input.GetAxis("Vertical") + MoveSpeed * transform.right * Input.GetAxis("Horizontal") + TempVerSpeed;
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            RB.velocity += JumpSpeed * transform.up;
        }
    }

    public bool GroundCheck()
    {
        if(Physics.OverlapSphere(FootSensor.transform.position, 0.1f).Length != 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
