//*********************************************************************
//
//					   ScriptName 	: TweenRotate
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;

public class HCTweenRotate : DoTweener
{
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

    Vector3 Rotation
    {
        get
        {
            return myTransform.eulerAngles;
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
        myTransform.localEulerAngles = from;
        myTransform.DOLocalRotate(to, Time, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() => OnComplete());
    }
    void Repeatedly(Vector3 from, Vector3 to)
    {
        myTransform.localEulerAngles = from;
        myTransform.DOLocalRotate(to, Time, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() => myTransform.DORotate(from, Time));
    }
    void Loop(Vector3 from, Vector3 to)
    {
        myTransform.localEulerAngles = from;
        myTransform.DOLocalRotate(to, Time, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() => Loop(from, to));
    }
    void PingPong(Vector3 from, Vector3 to)
    {
        myTransform.DOLocalRotate(to, Time, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() => PingPong(to, from));
    }

    protected override void StartValue()
    {
        Form = Rotation;
    }
    protected override void EndValue()
    {
        To = Rotation;
    }
}