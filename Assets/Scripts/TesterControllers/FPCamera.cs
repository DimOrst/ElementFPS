using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    Camera MainC;
    Rigidbody RB;

    float TempCamVerAngle = 10;

    public float CamHorSpeed;
    public float CamVerSpeed;

    private void Awake()
    {
        MainC = Camera.main;
        RB = transform.parent.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CameraRotate();
    }

    public void CameraRotate()
    {
        TempCamVerAngle -= CamVerSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse Y");
        TempCamVerAngle = Mathf.Clamp(TempCamVerAngle, -80, 80);
        transform.localEulerAngles = new Vector3(TempCamVerAngle, 0, 0);
        transform.parent.localEulerAngles += CamHorSpeed * Time.fixedDeltaTime * new Vector3(0, Input.GetAxis("Mouse X"), 0);
    }
}
