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

    //今日任务：完成元素反应请求的解读与执行
    public void ExecuteRMsg(ReactionMsg QuestMsg)
    {
        //根据请求的反应器提供的信息将两者交给相应的反应函数
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
                                Debug.Log(QuestMsg.ReactorOne.name + "为弱元素，沾染后被摧毁");
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
                                Debug.Log(QuestMsg.ReactorOne.name + "为弱元素，沾染后被摧毁");
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
                                Debug.Log(QuestMsg.ReactorOne.name + "为弱元素，沾染后被摧毁");
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
                                Debug.Log(QuestMsg.ReactorTwo.name + "为弱元素，沾染后被摧毁");
                                break;
                            }
                        case ElementCollection.Fire:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Fire);
                                Debug.Log(QuestMsg.ReactorTwo.name + "为弱元素，沾染后被摧毁");
                                break;
                            }
                        case ElementCollection.Ice:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Ice);
                                Debug.Log(QuestMsg.ReactorTwo.name + "为弱元素，沾染后被摧毁");
                                break;
                            }
                        case ElementCollection.None:
                            {
                                break;
                            }
                        case ElementCollection.Water:
                            {
                                Stained(QuestMsg.ReactorOne, ElementCollection.Water);
                                Debug.Log(QuestMsg.ReactorTwo.name + "为弱元素，沾染后被摧毁");
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
                                Debug.Log(QuestMsg.ReactorOne.name + "为弱元素，沾染后被摧毁");
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

        //再次激活过程将根据需要设计其它函数
        QuestMsg.ReactorOne.ReadyToReact = true;
        QuestMsg.ReactorTwo.ReadyToReact = true;

        RemoveMirrorRMsg(QuestMsg);
        ReactionQuests.RemoveAt(0);
    }

    /// <summary>
    /// 从处理列表中删去另一个反应器发送的对称的反应信息
    /// </summary>
    /// <param name="QuestMsg"></param>
    void RemoveMirrorRMsg(ReactionMsg QuestMsg)
    {
        ReactionMsg MirrorMsg;
        MirrorMsg.ReactorOne = QuestMsg.ReactorTwo;
        MirrorMsg.ReactorTwo = QuestMsg.ReactorOne;
        ReactionQuests.Remove(MirrorMsg);
    }

    //重写的元素反应函数，写法非常笨蛋
    #region

    public override void Electrocuted(ReactionMsg RMsg)
    {
        switch (RMsg.ReactorOne.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorOne.name + "角色遭受感电打击。");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorOne.ElementType == ElementCollection.Water)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "水体导电，电击当前所接触的角色。");
                    }
                    //在水面上生成导电效果，生成的电层视为弱元素
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，感电反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色遭受感电打击。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.ElementType == ElementCollection.Water)
                    {
                        Debug.Log(RMsg.ReactorTwo.name + "水体导电，电击当前所接触的角色。");
                    }
                    //在水面上生成导电效果，生成的电层视为弱元素
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，感电反应后应被摧毁");
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
                    Debug.Log(RMsg.ReactorOne.name + "角色被冻结。");
                    RMsg.ReactorOne.ElementType = ElementCollection.Ice;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.OT == Reactor.ObjectType.Character)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "水体不发生变化。");
                    }
                    else
                    {
                        Debug.Log(RMsg.ReactorOne.name + "水体被冻结。");
                        //在水面上生成冰层效果，生成的冰层视为弱元素
                    }
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色被冻结。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.Ice;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    if (RMsg.ReactorTwo.OT == Reactor.ObjectType.Character)
                    {
                        Debug.Log(RMsg.ReactorOne.name + "水体不发生变化。");
                    }
                    else
                    {
                        Debug.Log(RMsg.ReactorOne.name + "水体被冻结。");
                        //在水面上生成冰层效果，生成的冰层视为弱元素
                    }
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，反应后应被摧毁");
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
                    Debug.Log(RMsg.ReactorOne.name + "角色被融化。");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，融化反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色被融化。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，融化反应后应被摧毁");
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
                    Debug.Log(RMsg.ReactorOne.name + "角色遭受过载打击。");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，过载反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色遭受过载打击。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，过载反应后应被摧毁");
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
                    Debug.Log(RMsg.ReactorOne.name + "角色遭受超导打击。");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，超导反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色遭受超导打击。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("暂时没有这样的情况出现");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，超导反应后应被摧毁");
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
                    Debug.Log(RMsg.ReactorOne.name + "角色遭受蒸发打击。");
                    RMsg.ReactorOne.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("水体被蒸发，将出现蒸汽");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorOne.name + "为弱元素，蒸发反应后应被摧毁");
                    break;
                }
        }
        switch (RMsg.ReactorTwo.OT)
        {
            case Reactor.ObjectType.Character:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "角色遭受蒸发打击。");
                    RMsg.ReactorTwo.ElementType = ElementCollection.None;
                    break;
                }
            case Reactor.ObjectType.StrongElement:
                {
                    Debug.Log("水体被蒸发，将出现蒸汽");
                    break;
                }
            case Reactor.ObjectType.WeakElement:
                {
                    Debug.Log(RMsg.ReactorTwo.name + "为弱元素，蒸发反应后应被摧毁");
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
