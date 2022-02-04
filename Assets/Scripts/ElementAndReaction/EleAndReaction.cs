using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���࣬Ԫ������������Ԫ�ط�Ӧ�����������
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
    /// ������Ӧʱ��Reactor��Manager���͵ķ�Ӧ������Ϣ
    /// </summary>
    public struct ReactionMsg
    {
        public Reactor ReactorOne;
        public Reactor ReactorTwo;
    }

    /// <summary>
    /// ����
    /// </summary>
    public virtual void Frozen(ReactionMsg RMsg)
    {
        Debug.Log("����");
    }

    /// <summary>
    /// ����
    /// </summary>
    public virtual void Superconducting(ReactionMsg RMsg)
    {
        Debug.Log("����");
    }

    /// <summary>
    /// �е�
    /// </summary>
    public virtual void Electrocuted(ReactionMsg RMsg)
    {
        Debug.Log("�е�");
    }

    /// <summary>
    /// ����
    /// </summary>
    public virtual void Vaperaize(ReactionMsg RMsg)
    {
        Debug.Log("����");
    }

    /// <summary>
    /// �ڻ�
    /// </summary>
    public virtual void Melt(ReactionMsg RMsg)
    {
        Debug.Log("�ڻ�");
    }

    /// <summary>
    /// ����
    /// </summary>
    public virtual void Overload(ReactionMsg RMsg)
    {
        Debug.Log("����");
    }

    /// <summary>
    /// Ԫ��մȾ
    /// </summary>
    /// <param name="TargetObj">��մȾ������</param>
    /// <param name="Element">��մȾ��Ԫ������</param>
    public virtual void Stained(Reactor TargetObj, ElementCollection Element)
    {
        Debug.Log(TargetObj.name + "մȾ��" + Element);
        TargetObj.ElementType = Element;
    }
}
