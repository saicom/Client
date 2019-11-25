using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;


public enum PressStyle
{
    Press_Invalid,
    Press_Shrink,
    Press_Bounce,
}

public class PressButton : MonoBehaviour
{
    public AudioClip ClickSound;
    public PressStyle pressStyle;
    public float pressCoef = 1.1f;

    private Vector3 _defaultPos;
    private Vector3 _defaultScale;
    private Vector3 _defaultEuler;


    public void Start()
    {
        EventTriggerListener.Get(gameObject).onEnter += OnEnterBtn;
        EventTriggerListener.Get(gameObject).onExit += OnExitBtn;
        EventTriggerListener.Get(gameObject).onClick += OnClickBtn;
        EventTriggerListener.Get(gameObject).onUp += OnUpBtn;
        EventTriggerListener.Get(gameObject).onDown += OnDownBtn;

        _defaultPos = transform.position;
        _defaultScale = transform.localScale;
        _defaultEuler = transform.eulerAngles;
    }

    private void OnDownBtn(GameObject go)
    {
        if (pressStyle == PressStyle.Press_Shrink)
        {
            transform.localScale /= pressCoef;
        }
    }

    private void OnUpBtn(GameObject go)
    {
        if (pressStyle == PressStyle.Press_Shrink)
        {
            transform.localScale *= pressCoef;
        }
    }

    private void OnClickBtn(GameObject go)
    {
        if (ClickSound != null)
        {
            AudioManager.Instance.PlaySound(ClickSound);
        }

        transform.DOKill();
        ResetData();

        if (pressStyle == PressStyle.Press_Bounce)
        {
            PressBounce();
        }
    }

    private void PressBounce()
    {
        transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 0.4f, 12, 0.5f);
    }

    void OnEnterBtn(GameObject go)
    {
        //Debug.Log("enter");
    }
    void OnExitBtn(GameObject go)
    {
        //Debug.Log("exit");
    }

    private void ResetData()
    {
        //transform.position = _defaultPos;
        transform.localScale = _defaultScale;
        transform.eulerAngles = _defaultEuler;
    }
}