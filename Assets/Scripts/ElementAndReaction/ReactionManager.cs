using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionManager : EleAndReaction
{
    List<ReactionMsg> ReactionQuests = new List<ReactionMsg>();
    
    public void SendNewReaction(ReactionMsg RMsg)
    {
        ReactionQuests.Add(RMsg);
    }

    private void Update()
    {
        if(ReactionQuests.Count != 0)
        {
            ExecuteRMsg(ReactionQuests[0]);
        }
    }

    //�����������Ԫ�ط�Ӧ����Ľ����ִ��
    public void ExecuteRMsg(ReactionMsg QuestMsg)
    {
        //��������ķ�Ӧ���ṩ����Ϣ�����߽�����Ӧ�ķ�Ӧ����
        switch (QuestMsg.ReactorOne.ElementType)
        {
            case ElementCollection.Electricity:
                {
                    switch (QuestMsg.ReactorTwo.ElementType)
                    {
                        case ElementCollection.Electricity:
                            {
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                Overload(QuestMsg);
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                Superconducting(QuestMsg);
                                break;
                            }
                        case ElementCollection.None:
                            {
                                Stained(QuestMsg.ReactorTwo,ElementCollection.Electricity);
                                Debug.Log(QuestMsg.ReactorOne.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                Electrocuted(QuestMsg);
                                break;
                            }
                    }
                    break;
                }
            case ElementCollection.Fire:
                {
                    switch (QuestMsg.ReactorTwo.ElementType)
                    {
                        case ElementCollection.Electricity:
                            {
                                Overload(QuestMsg);
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                Melt(QuestMsg);
                                break;
                            }
                        case ElementCollection.None:
                            {
                                Stained(QuestMsg.ReactorTwo, ElementCollection.Fire);
                                Debug.Log(QuestMsg.ReactorOne.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                Vaperaize(QuestMsg);
                                break;
                            }
                    }
                    break;
                }
            case ElementCollection.Ice:
                {
                    switch (QuestMsg.ReactorTwo.ElementType)
                    {
                        case ElementCollection.Electricity:
                            {
                                Superconducting(QuestMsg);
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                Melt(QuestMsg);
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                break;
                            }
                        case ElementCollection.None:
                            {
                                Stained(QuestMsg.ReactorTwo, ElementCollection.Ice);
                                Debug.Log(QuestMsg.ReactorOne.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                Frozen(QuestMsg);
                                break;
                            }
                    }
                    break;
                }
            case ElementCollection.None:
                {
                    switch (QuestMsg.ReactorTwo.ElementType)
                    {
                        case ElementCollection.Electricity:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Electricity);
                                Debug.Log(QuestMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Fire);
                                Debug.Log(QuestMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Ice);
                                Debug.Log(QuestMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.None:
                            {
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Water);
                                Debug.Log(QuestMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                    }
                    break;
                }
            case ElementCollection.Water:
                {
                    switch (QuestMsg.ReactorTwo.ElementType)
                    {
                        case ElementCollection.Electricity:
                            {
                                Electrocuted(QuestMsg);
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                Vaperaize(QuestMsg);
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                Frozen(QuestMsg);
                                break;
                            }
                        case ElementCollection.None:
                            {
                                Stained(QuestMsg.ReactorTwo, ElementCollection.Water);
                                Debug.Log(QuestMsg.ReactorOne.name + "Ϊ��Ԫ�أ�մȾ�󱻴ݻ�");
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                break;
                            }
                    }
                    break;
                }
        }

        //�ٴμ�����̽�������Ҫ�����������
        QuestMsg.ReactorOne.ReadyToReact = true;
        QuestMsg.ReactorTwo.ReadyToReact = true;

        RemoveMirrorRMsg(QuestMsg);
        ReactionQuests.RemoveAt(0);
    }

    /// <summary>
    /// �Ӵ����б���ɾȥ��һ����Ӧ�����͵ĶԳƵķ�Ӧ��Ϣ
    /// </summary>
    /// <param name="QuestMsg"></param>
    void RemoveMirrorRMsg(ReactionMsg QuestMsg)
    {
        ReactionMsg MirrorMsg;
        MirrorMsg.ReactorOne = QuestMsg.ReactorTwo;
        MirrorMsg.ReactorTwo = QuestMsg.ReactorOne;
        ReactionQuests.Remove(MirrorMsg);
    }

    //��д��Ԫ�ط�Ӧ������д���ǳ�����
    #region

    public override void Electrocuted(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ���ܸе�����");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorOne.ElementType == ElementCollection.Water)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "ˮ�嵼�磬�����ǰ���Ӵ��Ľ�ɫ��");
                    }
                    //��ˮ�������ɵ���Ч�������ɵĵ����Ϊ��Ԫ��
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ��е練Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ���ܸе�����");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.ElementType == ElementCollection.Water)
                    {
                        Debug.Log(RMsg.ReactorTwo.name + "ˮ�嵼�磬�����ǰ���Ӵ��Ľ�ɫ��");
                    }
                    //��ˮ�������ɵ���Ч�������ɵĵ����Ϊ��Ԫ��
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ��е練Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Frozen(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ�����ᡣ");
                    RMsg.ReactorOne.ElementType = ElementCollection.Ice;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.OT == Reactor.ObjectType.Character)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "ˮ�岻�����仯��");
                    }
                    else
                    {
                        Debug.Log(RMsg.ReactorOne.name + "ˮ�屻���ᡣ");
                        //��ˮ�������ɱ���Ч�������ɵı�����Ϊ��Ԫ��
                    }
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ���Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ�����ᡣ");
                    RMsg.ReactorTwo.ElementType = ElementCollection.Ice;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.OT == Reactor.ObjectType.Character)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "ˮ�岻�����仯��");
                    }
                    else
                    {
                        Debug.Log(RMsg.ReactorOne.name + "ˮ�屻���ᡣ");
                        //��ˮ�������ɱ���Ч�������ɵı�����Ϊ��Ԫ��
                    }
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ���Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Melt(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ���ڻ���");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ��ڻ���Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ���ڻ���");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ��ڻ���Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Overload(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ���ܹ��ش����");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ����ط�Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ���ܹ��ش����");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ����ط�Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Superconducting(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ���ܳ��������");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ�������Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ���ܳ��������");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("��ʱû���������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�������Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Vaperaize(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "��ɫ�������������");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("ˮ�屻����������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "Ϊ��Ԫ�أ�������Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "��ɫ�������������");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("ˮ�屻����������������");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "Ϊ��Ԫ�أ�������Ӧ��Ӧ���ݻ�");
                    break;
                }
        }
    }

    public override void Stained(Reactor TargetObj, ElementCollection Element)
    {
        base.Stained(TargetObj, Element);
    }

    #endregion

}
