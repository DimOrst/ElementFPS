using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterThunderReactor : Reactor
{
    public float TimeToDie = 1.5f;

    public override void DestroyThisElement()
    {
        //啥也不发生，反应后依旧存在
    }

    private void Update()
    {
        Invoke("ThunderDisappear", TimeToDie);
    }

    public void ThunderDisappear()
    {
        Destroy(gameObject);
    }

    public override void OnTriggerEnter(Collider other)
    {
        Reactor otherReactor = other.gameObject.GetComponent<Reactor>();
        if (otherReactor != null)
        {
            if (otherReactor.OT == ObjectType.Character)
            {
                Debug.Log(otherReactor.name + "遭到电击");
            }
        }
    }
}
