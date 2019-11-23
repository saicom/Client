//*********************************************************************
//
//					   ScriptName 	: TweenScale
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HCTweenScale : DoTweener
{
    public AnimationCurve Curve;
    public Vector3 Form;
    public Vector3 To;
    public float Time = 1f;
    Transform tr;
    Transform myTransform
    {
        get
        {
            if (tr == null)
                tr = transform;
            return tr;
        }
        set
        {
            tr = value;
        }
    }

    Vector3 Scale
    {
        get
        {
            return myTransform.localScale;
        }
    }

    public override void PlayForward()
    {
        StyleFunction(Form, To);
    }
    public override void PlayReverse()
    {
        StyleFunction(To, Form);
    }

    void StyleFunction(Vector3 from, Vector3 to)
    {
        switch (style)
        {
            case Style.Once:
                One(from, to);
                break;
            case Style.Loop:
                Loop(from, to);
                break;
            case Style.Repeatedly:
                Repeatedly(from, to);
                break;
            case Style.PingPong:
                PingPong(from, to);
                break;
        }
    }
    void One(Vector3 from, Vector3 to)
    {
        myTransform.localScale = from;
        myTransform.DOScale(to, Time).SetEase(Curve).OnComplete(() => OnComplete());
    }
    void Repeatedly(Vector3 from, Vector3 to)
    {
        myTransform.localScale = from;
        myTransform.DOScale(to, Time).SetEase(Curve).OnComplete(() => myTransform.DOScale(from, Time)).SetEase(Curve);
    }
    void Loop(Vector3 from, Vector3 to)
    {
        myTransform.localScale = from;
        myTransform.DOScale(to, Time).SetEase(Curve).OnComplete(() => Loop(from, to));
    }
    void PingPong(Vector3 from, Vector3 to)
    {
        myTransform.DOScale(to, Time).SetEase(Curve).OnComplete(() => PingPong(to, from));
    }

    protected override void StartValue()
    {
        Form = Scale;
    }
    protected override void EndValue()
    {
        To = Scale;
    }
}