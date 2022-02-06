using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    ParticleSystem PS;
    float timetodie;
    private void Awake()
    {
        PS = GetComponentInChildren<ParticleSystem>();
        timetodie = PS.main.duration + PS.main.startLifetime.constantMax;
    }

    private void Update()
    {
        Invoke("SmokeDisappear",timetodie);
    }

    public void SmokeDisappear()
    {
        Destroy(gameObject);
    }
}
