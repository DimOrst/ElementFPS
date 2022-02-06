using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : EleAndReaction
{
    [SerializeField]
    ReactionManager RM;
    public enum ObjectType
    {
        WeakElement,     //���ӵ��ȷ�Ӧ������
        StrongElement,   //��ˮ�ݡ��糡�Ȳ��ᱻ��Ӧ���ĵ�Ԫ��
        Character
    };
    public ObjectType OT;
    public ElementCollection ElementType = ElementCollection.None;

    //�������Ƿ�׼����������Ԫ�ط�Ӧ
    public bool ReadyToReact = true;

    private void Start()
    {
        RM = FindObjectOfType<ReactionManager>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        //������Ϊtag��layer�ж�
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
