//*********************************************************************
//
//					   ScriptName 	: TweenAlpha
//                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class HCTweenTextAlpha : DoTweener
{


    public float StartAlpha;
    public float EndAlpha;
    public float durtion = 1f;

    private Text _text;
    Text text
    {
        get
        {
            if (_text == null)
            {
                _text = GetComponent<Text>();
                if (text == null)
                    Debug.LogError("当前游戏对象不存在 tk2dBaseSprite 请检查");
            }
            return _text;
        }
        set
        {
            _text = value;
        }
    }


    public float GetAlpha
    {
        get
        {
            return text.color.a;
        }
    }
    public override void PlayForward()
    {
        StyleFunction(StartAlpha, EndAlpha, durtion, style);
    }
    public override void PlayReverse()
    {
        StyleFunction(EndAlpha, StartAlpha, durtion, style);
    }

    private void StyleFunction(float fromAlpha, float toAlpha, float animTime, DoTweener.Style style)
    {
        switch (style)
        {
            case Style.Once:
                One(fromAlpha, toAlpha);
                break;
            case Style.Loop:
                Loop(fromAlpha, toAlpha);
                break;
            case Style.Repeatedly:
                Repeatedly(fromAlpha, toAlpha);
                break;
            case Style.PingPong:
                PingPong(fromAlpha, toAlpha);
                break;
        }
    }

    private void One(float fromAlpha, float toAlpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, fromAlpha);
        DOTween.ToAlpha(() => text.color, x => text.color = x, toAlpha, durtion).OnComplete(() => OnComplete());
    }
    private void Repeatedly(float fromAlpha, float toAlpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, fromAlpha);
        DOTween.ToAlpha(() => text.color, x => text.color = x, toAlpha, durtion).OnComplete(() => DOTween.ToAlpha(() => text.color, x => text.color = x, fromAlpha, durtion));
    }
    private void Loop(float fromAlpha, float toAlpha)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, fromAlpha);
        DOTween.ToAlpha(() => text.color, x => text.color = x, EndAlpha, durtion).OnComplete(() => Loop(fromAlpha, toAlpha));
    }
    private void PingPong(float fromAlpha, float toAlpha)
    {
        DOTween.ToAlpha(() => text.color, x => text.color = x, toAlpha, durtion).OnComplete(() => PingPong(toAlpha, fromAlpha));
    }

    protected override void StartValue()
    {
        if (text)
        {
            StartAlpha = text.color.a;
            EndAlpha = text.color.a;
            return;
        }
        Debug.Log("如果 刚才添加不是 TextMesh Alahp 请 检查 组件的透明设置");
    }
}