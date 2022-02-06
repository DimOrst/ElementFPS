using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : EleAndReaction
{
    [SerializeField]
    ReactionManager RM;
    public enum ObjectType
    {
        WeakElement,     //如子弹等反应后被消耗
        StrongElement,   //如水洼、风场等不会被反应消耗的元素
        Character
    };
    public ObjectType OT;
    public ElementCollection ElementType = ElementCollection.None;

    //该物体是否准备好与其它元素反应
    public bool ReadyToReact = true;

    private void Start()
    {
        RM = FindObjectOfType<ReactionManager>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        //后面会改为tag或layer判断
        Reactor otherReactor = other.gameObject.GetComponent<Reactor>();
        if (otherReactor != null)
        {
            if (otherReactor.ReadyToReact && ReadyToReact)
            {
                if (!(OT == ObjectType.Character && otherReactor.OT == ObjectType.Character))
                {
                    ReactionMsg NewMsg;
                    NewMsg.ReactorOne = this;
                    NewMsg.ReactorTwo = otherReactor;
                    RM.SendNewReaction(NewMsg);
                    ReadyToReact = false;
                    otherReactor.ReadyToReact = false;
                }
            }
        }
    }

    public virtual void DestroyThisElement()
    {
        Destroy(gameObject);
    }
}
