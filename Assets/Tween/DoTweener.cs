//*********************************************************************
//
//					   ScriptName 	: DoTweener
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;


public class DoTweener : MonoBehaviour
{
    public enum PlayType
    {
        PlayForward,
        PlayReverse
    }
    public enum Style
    {
        Once,
        Loop,
        Repeatedly,
        PingPong
    }
    // 是否是在启动事运行;
    public bool IsStartRun = true;
    public Style style = Style.Once;

    // 回调函数
    public delegate void DoTweenerComplete();

    // 回调方法
    public DoTweenerComplete OnComplete;

    void Reset()
    {

        StartValue();
        EndValue();
    }

    protected void TweenAnim()
    {

    }
    void Awake()
    {
        if (OnComplete == null)
            OnComplete = TweenAnim;
        DoAwake();
    }
    void Start()
    {
        if (IsStartRun)
            PlayForward();
    }

    public virtual void DoAwake()
    {
    }
    public virtual void DoStart()
    {
    }
    public virtual void PlayForward()
    {
    }
    public virtual void PlayReverse()
    {

    }
    protected virtual void StartValue()
    {
    }
    protected virtual void EndValue()
    {
    }

    public virtual void SetAlpha(float startalpha, float alpha, float animTime, DoTweener.Style style)
    {

    }

}