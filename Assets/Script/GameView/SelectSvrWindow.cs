using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using GameDefine;
using Ctrl;
using Model;

namespace View
{
    public enum EServerTabType {
        BelongServer = 0,   //所属服务器
        SuggetServer,       //推荐服务器
        AllServer,          //所有服务器
    }

    public class SelectSvrWindow : BaseWindow
    {
        public SelectSvrWindow() 
        {
            mScenesType = 0;
            mResName = GameConstDefine.LoadSelectSvrUI;
            mResident = false;
        }

        ////////////////////////////Inherit interface/////////////////////////

        public override void Init()
        {
            EventCenter.AddListener(EGameEvent.eGameEvent_SelectSvrEnter, Show);
            EventCenter.AddListener(EGameEvent.eGameEvent_SelectSvrExit, Hide);
        }

        public override void Release()
        {
            EventCenter.RemoveListener(EGameEvent.eGameEvent_SelectSvrEnter, Show);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_SelectSvrExit, Hide);
        }

        protected override void InitWidget()
        {
            m_btnClose = mRoot.Find("Bg/Close").GetComponent<Button>();
            m_tweenScale = mRoot.Find("Bg").GetComponent<HCTweenScale>();
            m_infinityScrollView = mRoot.Find("Bg/FrameBody/ServerList/Viewport/Content").GetComponent<InfinityGridLayoutGroup>();
            m_rectContent = m_infinityScrollView.transform.GetComponent<RectTransform>();
            m_scrollView = mRoot.Find("Bg/FrameBody/ServerList").GetComponent<ScrollRect>();
            m_togBelong = mRoot.Find("Bg/FrameBody/Menu/BelongSvr").GetComponent<Toggle>();
            m_togSuggest = mRoot.Find("Bg/FrameBody/Menu/SuggestSvr").GetComponent<Toggle>();
            m_togAll = mRoot.Find("Bg/FrameBody/Menu/AllSvr").GetComponent<Toggle>();

            m_btnClose.onClick.AddListener(OnClickClose);
            m_togBelong.onValueChanged.AddListener(onClickMenu);
            m_togSuggest.onValueChanged.AddListener(onClickMenu);
            m_togAll.onValueChanged.AddListener(onClickMenu);
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
            //播放动画完毕打开scroll view;
            m_tweenScale.OnComplete = () => { m_scrollView.enabled = true; };
            m_tweenScale.PlayForward();

            if(LoginModel.Instance.RecentUserId == 0)
            {
                m_togBelong.gameObject.SetActive(false);
                m_togBelong.isOn = false;
                m_togSuggest.isOn = true;
                m_serverTabType = EServerTabType.SuggetServer;
            }

            int count = _getServerCount();
            m_infinityScrollView.SetAmount(count);
            m_infinityScrollView.updateChildrenCallback = UpdateChildrenCallback;
            //for (int i = 0; i < m_rectContent.childCount; i++)
            //{
            //    var child = m_rectContent.GetChild(i);
            //    UpdateChildrenCallback(i, child);
            //}
        }

        private void UpdateChildrenCallback(int index, Transform trans)
        {
            int count = _getServerCount();
            if (index >= count)
            {
                trans.gameObject.SetActive(false);
                return;
            }
            cdnServerInfo serverInfo = _getServerInfo(index);
            if(serverInfo == null)
            {
                return;
            }

            Button button = trans.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => { OnServerBtnClick(serverInfo.serverId, trans); });

            Text txtServerName = trans.Find("ServerName").GetComponent<Text>();
            txtServerName.text = "S"+serverInfo.serverId+"."+serverInfo.serverName;
            //Image itemIcon = trans.Find("ItemIcon").GetComponent<Image>();
            //itemIcon.overrideSprite = Resources.Load(itemData.m_ItemCfg.m_Icon, typeof(Sprite)) as Sprite;
        }

        private cdnServerInfo _getServerInfo(int index)
        {
            if(m_serverTabType == EServerTabType.BelongServer)
            {
                return LoginModel.Instance.GetServerInfo(index);
            }
            else if(m_serverTabType == EServerTabType.SuggetServer)
            {
                if (index == 0) {
                    return NoticeModel.Instance.GetNewServer();
                }
            }
            else if (m_serverTabType == EServerTabType.AllServer)
            {
                return NoticeModel.Instance.GetServerInfoByIndex(index);
            }
            return null;
        }

        private void OnServerBtnClick(uint serverId, Transform trans)
        {
            EventCenter.Broadcast<uint>(EGameEvent.eGameEvent_SelectServer, serverId);
            OnClickClose();
        }

        public override void OnDisable()
        {
        }

        ////////////////////////////////UI event////////////////////////////////////
        private void OnClickClose()
        {
            m_tweenScale.OnComplete =  (() => { Hide(); }) ;
            m_tweenScale.PlayReverse();
        }

        private void onClickMenu(bool arg0)
        {
            EServerTabType oldType = m_serverTabType;
            if(arg0)
            {
                if(m_togBelong.isOn)
                {
                    m_serverTabType = EServerTabType.BelongServer;
                }
                if(m_togSuggest.isOn)
                {
                    m_serverTabType = EServerTabType.SuggetServer;
                }
                if(m_togAll.isOn)
                {
                    m_serverTabType = EServerTabType.AllServer;
                }
                if(oldType != m_serverTabType)
                {
                    UpdateServreList();
                }
            }
        }

        private int _getServerCount()
        {
            if (m_serverTabType == EServerTabType.AllServer)
            {
                return NoticeModel.Instance.GetServerCount();
            }
            else if(m_serverTabType == EServerTabType.SuggetServer)
            {
                cdnServerInfo info = NoticeModel.Instance.GetNewServer();
                if(info == null)
                {
                    return 0;
                }
                return 1;
            }
            else if(m_serverTabType == EServerTabType.BelongServer)
            {
                //
                return LoginModel.Instance.GetUserCount();
            }

            return 0;
        }

        void UpdateServreList()
        {
            int count = _getServerCount();
            m_infinityScrollView.SetAmount(count);
            //m_infinityScrollView.updateChildrenCallback = UpdateChildrenCallback;
        }

        ////////////////////////////////Game event////////////////////////////////////

        ////////////////////////////////Member define////////////////////////////////////
        Button m_btnClose;
        HCTweenScale m_tweenScale;
        InfinityGridLayoutGroup m_infinityScrollView;
        RectTransform m_rectContent;
        ScrollRect m_scrollView;
        Toggle m_togBelong;
        Toggle m_togSuggest;
        Toggle m_togAll;

        EServerTabType m_serverTabType = EServerTabType.BelongServer;
    }
}
