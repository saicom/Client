using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
public class HCTweenAlpha : DoTweener
{
    public AnimationCurve Curve;
    public float StartAlpha;
    public float EndAlpha;
    public float durtion = 1f;
    public bool isChildAlpha;
    private bool Forward = true;
    private Image _sprite;
    private Image[] imageList;
    private Text[] textList;

    Image sprite
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = gameObject.GetComponent<Image>();
            }
            return _sprite;
        }
        set
        {
            _sprite = value;
        }
    }

    public float GetAlpha
    {
        get
        {
            return sprite.color.a;
        }
    }

    public override void DoAwake()
    {
        base.DoAwake();

        if (isChildAlpha)
        {
            imageList = this.transform.GetComponentsInChildren<Image>();
            textList = this.transform.GetComponentsInChildren<Text>();
        }
    }


    public override void PlayForward()
    {
        Forward = true;
        StyleFunction(StartAlpha, EndAlpha, durtion, style);
    }
    public override void PlayReverse()
    {
        Forward = false;
        StyleFunction(EndAlpha, StartAlpha, durtion, style);
    }

    private void StyleFunction(float fromAlpha, float toAlpha, float animTime, DoTweener.Style style)
    {
        if (sprite == null)
        {
            Debug.Log("GameObject: " + this.gameObject.name + "no iamge, not alpha action");
            return;
        }

        switch (style)
        {
            case Style.Once:
                One(fromAlpha, toAlpha, animTime);
                break;
            case Style.Loop:
                Loop(fromAlpha, toAlpha, animTime);
                break;
            case Style.Repeatedly:
                Repeatedly(fromAlpha, toAlpha, animTime);
                break;
            case Style.PingPong:
                PingPong(fromAlpha, toAlpha, animTime);
                break;
        }
    }

    private void One(float fromAlpha, float toAlpha, float time)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, fromAlpha);
        if (!isChildAlpha)
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).OnComplete(() => OnComplete()).SetEase(Curve);
        }
        else
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).OnComplete(() => OnComplete()).SetEase(Curve)
                .OnUpdate(() =>
                {
                    SetChildImageAndTextColor();
                });
        }
    }

    private void Repeatedly(float fromAlpha, float toAlpha, float time)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, fromAlpha);

        if (!isChildAlpha)
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).SetEase(Curve).OnComplete(() => DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, fromAlpha, time));
        }
        else
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).SetEase(Curve).OnComplete(() => DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, fromAlpha, time))
                .OnUpdate(() =>
                {
                    SetChildImageAndTextColor();
                });

        }

    }
    private void Loop(float fromAlpha, float toAlpha, float time)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, fromAlpha);

        if (!isChildAlpha)
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, EndAlpha, time).SetEase(Curve).OnComplete(() => Loop(fromAlpha, toAlpha, time));
        }
        else
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, EndAlpha, time).SetEase(Curve).OnComplete(() => Loop(fromAlpha, toAlpha, time))
                .OnUpdate(() =>
                {
                    SetChildImageAndTextColor();
                });
        }

    }
    private void PingPong(float fromAlpha, float toAlpha, float time)
    {
        if (!isChildAlpha)
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).SetEase(Curve).OnComplete(() => PingPong(toAlpha, fromAlpha, time));
        }
        else
        {
            DOTween.ToAlpha(() => sprite.color, x => sprite.color = x, toAlpha, time).SetEase(Curve).OnComplete(() => PingPong(toAlpha, fromAlpha, time))
                .OnUpdate(() =>
                {
                    SetChildImageAndTextColor();
                });
        }
    }

    protected override void StartValue()
    {
        if (sprite)
        {
            StartAlpha = sprite.color.a;
            EndAlpha = sprite.color.a;
            return;
        }
    }

    private void SetChildImageAndTextColor()
    {
        for (int i = 1; i < imageList.Length; i++)
        {
            imageList[i].color = new Color(imageList[i].color.r, imageList[i].color.g, imageList[i].color.b, imageList[0].color.a);
        }
        for (int i = 0; i < textList.Length; i++)
        {
            textList[i].color = new Color(textList[i].color.r, textList[i].color.g, textList[i].color.b, imageList[0].color.a);
        }
    }



}