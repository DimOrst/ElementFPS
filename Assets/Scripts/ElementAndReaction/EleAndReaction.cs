using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基类，元素类型与所有元素反应都在这个类里
/// </summary>
public class EleAndReaction : MonoBehaviour
{
    public enum ElementCollection
    {
        Fire,
        Water,
        Ice,
        Electricity,
        None
    };

    /// <summary>
    /// 发生反应时，Reactor向Manager发送的反应请求信息
    /// </summary>
    public struct ReactionMsg
    {
        public Reactor ReactorOne;
        public Reactor ReactorTwo;
    }

    /// <summary>
    /// 冻结
    /// </summary>
    public virtual void Frozen(ReactionMsg RMsg)
    {
        Debug.Log("冻结");
    }

    /// <summary>
    /// 超导
    /// </summary>
    public virtual void Superconducting(ReactionMsg RMsg)
    {
        Debug.Log("超导");
    }

    /// <summary>
    /// 感电
    /// </summary>
    public virtual void Electrocuted(ReactionMsg RMsg)
    {
        Debug.Log("感电");
    }

    /// <summary>
    /// 蒸发
    /// </summary>
    public virtual void Vaperaize(ReactionMsg RMsg)
    {
        Debug.Log("蒸发");
    }

    /// <summary>
    /// 融化
    /// </summary>
    public virtual void Melt(ReactionMsg RMsg)
    {
        Debug.Log("融化");
    }

    /// <summary>
    /// 超载
    /// </summary>
    public virtual void Overload(ReactionMsg RMsg)
    {
        Debug.Log("超载");
    }

    /// <summary>
    /// 元素沾染
    /// </summary>
    /// <param name="TargetObj">被沾染的物体</param>
    /// <param name="Element">被沾染的元素类型</param>
    public virtual void Stained(Reactor TargetObj, ElementCollection Element)
    {
        Debug.Log(TargetObj.name + "沾染了" + Element);
        TargetObj.ElementType = Element;
    }
}
