using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using GameDefine;

namespace View
{
    public class WaitingWindow : BaseWindow
    {
        public WaitingWindow() 
        {
            mScenesType = 0;
            mResName = GameConstDefine.LoadWaitingUI;
            mResident = true;
        }

        ////////////////////////////Inherit interface/////////////////////////

        public override void Init()
        {
            EventCenter.AddListener(EGameEvent.eGameEvent_WaitingEnter, Show);
            EventCenter.AddListener(EGameEvent.eGameEvent_WaitingExit, Hide);
        }

        public override void Release()
        {
            EventCenter.RemoveListener(EGameEvent.eGameEvent_WaitingEnter, Show);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_WaitingExit, Hide);
        }

        protected override void InitWidget()
        {
        }

        public static void DestroyOtherUI(String resName)
        {
            Transform canvas = GameUtils.GetCanvas();
            for (int i = 0; i < canvas.childCount; i++)
            {
                if (canvas.GetChild(i) != null && canvas.GetChild(i).gameObject != null)
                {

                    GameObject obj = canvas.GetChild(i).gameObject;
                    if (obj.name != resName + "(Clone)")
                    {
                        GameObject.DestroyImmediate(obj);
                    }                    
                }
            }
        }

        protected override void ReleaseWidget()
        {
        }

        protected override void OnAddListener()
        {
        }

        protected override void OnRemoveListener()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnDisable()
        {
        }

        ////////////////////////////////UI event////////////////////////////////////
        
        ////////////////////////////////Game event////////////////////////////////////
		
        ////////////////////////////////Member define////////////////////////////////////

    }
}
