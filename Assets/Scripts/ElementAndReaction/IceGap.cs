using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGap : Reactor
{
    public float IceGapLife = 8;

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyThisElement", IceGapLife);
    }

    public override void DestroyThisElement()
    {
        base.DestroyThisElement();
    }
}
