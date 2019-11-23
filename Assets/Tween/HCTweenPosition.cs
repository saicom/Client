//*********************************************************************
//
//					   ScriptName 	: MoveFormTo
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class HCTweenPosition : DoTweener
{
    public AnimationCurve Curve;
    public Vector3 Form;
    public Vector3 To;
    public float Time = 1f;

    RectTransform my;
    RectTransform myTransform
    {
        get
        {
            if (my == null)
                my = GetComponent<RectTransform>();
            return my;
        }
    }
    bool isParentCanvas = false;
    public override void PlayForward()
    {
        StyleFunction(this.Form, this.To);
    }
    public override void PlayReverse()
    {
        StyleFunction(this.To, this.Form);
    }
    void StyleFunction(Vector3 From, Vector3 To)
    {
        switch (style)
        {
            case Style.Once:
                One(From, To);
                break;
            case Style.Loop:
                Loop(From, To);
                break;
            case Style.Repeatedly:
                Repeatedly(From, To);
                break;
            case Style.PingPong:
                PingPong(From, To);
                break;
        }
    }
    void One(Vector3 From, Vector3 To)
    {
        myTransform.anchoredPosition3D = From;
        DOTween.To(() => myTransform.anchoredPosition3D, x => myTransform.anchoredPosition3D = x, To, Time).SetEase(Curve);

    }
    void Repeatedly(Vector3 From, Vector3 To)
    {
        myTransform.anchoredPosition3D = From;
        DOTween.To(() => myTransform.anchoredPosition3D, x => myTransform.anchoredPosition3D = x, To, Time).SetEase(Curve)
            .OnComplete(() => myTransform.DOMove(Form, Time));
    }

    void Loop(Vector3 From, Vector3 To)
    {
        myTransform.anchoredPosition3D = From;
        DOTween.To(() => myTransform.anchoredPosition3D, x => myTransform.anchoredPosition3D = x, To, Time).SetEase(Curve)
            .OnComplete(() => Loop(Form, To));
    }

    void PingPong(Vector3 From, Vector3 To)
    {
        DOTween.To(() => myTransform.anchoredPosition3D, x => myTransform.anchoredPosition3D = x, To, Time).SetEase(Curve)
            .OnComplete(() => PingPong(To, From));
    }
    protected override void StartValue()
    {
        Form = this.myTransform.anchoredPosition;
    }
    protected override void EndValue()
    {
        To = this.myTransform.anchoredPosition;
    }
}