using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameData;
using GameDefine;
using Network;
using System.Linq;
using Ctrl;
using DG.Tweening;
using System;
using Model;

namespace View
{
    public class LoginWindow : BaseWindow
    {
        public LoginWindow() 
        {
            mResName = GameConstDefine.LoadGameLoginUI;
            mResident = false;
        }

        ////////////////////////////继承接口/////////////////////////
        //类对象初始化
        public override void Init()
        {
            EventCenter.AddListener(EGameEvent.eGameEvent_LoginEnter, Show);
            EventCenter.AddListener(EGameEvent.eGameEvent_LoginExit, Hide);
        }

        //类对象释放
        public override void Release()
        {
            EventCenter.RemoveListener(EGameEvent.eGameEvent_LoginEnter, Show);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_LoginExit, Hide);
        }

        //窗口控件初始化
        protected override void InitWidget()
        {
            //mLoginSubmit = mRoot.Find("LoginPanel/Submit").GetComponent<Button>();
            //mLoginAccountInput = mRoot.Find("LoginPanel/Name/NameEdit").GetComponent<InputField>();
            //mLoginPassInput = mRoot.Find("LoginPanel/Password/PasswdEdit").GetComponent<InputField>();
            //mAccountErrorText = mRoot.Find("LoginPanel/Name/NameError").GetComponent<Text>();

            //mLoginWindowBtn = mRoot.Find("LoginBtn").GetComponent<Button>();
            //mCloseLoginWindowBtn = mRoot.Find("LoginPanel/Close").GetComponent<Button>();

            //m_EnterGameBtn = mRoot.Find("EnterGameBtn").GetComponent<Button>();

            //mWaitingParent = mRoot.Find("Loading");
            //mLoadingIcon = mRoot.Find("Loading/icon");
            //m_LoginWindowParant = mRoot.Find("LoginPanel");

            //m_CurrentAccount = mRoot.Find("CurAccount").GetComponent<Text>();
            //m_LoginSuccessTipParent = mRoot.Find("LoginTip").GetComponent<RectTransform>();
            //m_LoginTipText = mRoot.Find("LoginTip/Text").GetComponent<Text>();
            //m_LoginTipPos = m_LoginSuccessTipParent.position;
            //m_SettingBtn = mRoot.Find("SettingBtn").GetComponent<AniButton>();

            //mLoginSubmit.onClick.AddListener(OnLoginSubmit);
            //mLoginWindowBtn.onClick.AddListener(OnLoginWindowBtn);
            //mCloseLoginWindowBtn.onClick.AddListener(OnCloseLoginWindowBtn);
            //m_EnterGameBtn.onClick.AddListener(OnEnterGameBtn);
            ////m_SettingBtn.onClick.AddListener(OnSettingBtn);
            //m_SettingBtn.onClick.AddListener(OnSettingBtn);
            //m_SettingBtn.Init();

            m_assassinEye = mRoot.Find("Bg/cike_duyan").GetComponent<Image>();
            m_warriorEye = mRoot.Find("Bg/zhanshi_eye").GetComponent<Image>();
            m_clericEye = mRoot.Find("Bg/mushi_eye").GetComponent<Image>();
            m_mageEye = mRoot.Find("Bg/fashi_eye").GetComponent<Image>();
            m_txtTipMsg = mRoot.Find("TipMsg").GetComponent<Text>();
            m_EnterGameBtn = mRoot.Find("EnterGame").GetComponent<Button>();
            m_btnSuggestServer = mRoot.Find("SuggestServer").GetComponent<Button>();
            m_txtSuggestServer = m_btnSuggestServer.transform.Find("Text").GetComponent<Text>();
            m_btnNotice = mRoot.Find("Notice").GetComponent<Button>();

            m_btnSuggestServer.onClick.AddListener(OnSelectServer);
            m_btnNotice.onClick.AddListener(OnNoticeClick);
            m_EnterGameBtn.onClick.AddListener(OnEnterGameBtn);
        }

        //删除Login外其他控件，例如
        public static void DestroyOtherUI()
        {
            Transform canvas = GameUtils.GetCanvas();
            for (int i = 0; i < canvas.childCount; i++)
            {
                if (canvas.GetChild(i) != null && canvas.GetChild(i).gameObject != null)
                {
                    GameObject obj = canvas.GetChild(i).gameObject;
                    if (obj.name != "UILogin(Clone)")
                    {
                        GameObject.DestroyImmediate(obj);
                    }
                }
            }
        }

        //窗口控件释放
        protected override void ReleaseWidget()
        {
        }

        //游戏事件注册
        protected override void OnAddListener()
        {
            //EventCenter.AddListener(EGameEvent.eGameEvent_LoginSuccess, LoginSuccess);
            //EventCenter.AddListener(EGameEvent.eGameEvent_LoginFail, ShowLoginFail);
            //EventCenter.AddListener<int>(EGameEvent.eGameEvent_CreateAccountFail, OnCreateAccountFail);
            EventCenter.AddListener<int>(EGameEvent.eGameEvent_ConnectServerSuccess, OnConnectServerSuccess);
            EventCenter.AddListener<int>(EGameEvent.eGameEvent_ConnectServerFail, OnConnectServerFail);
            EventCenter.AddListener<string>(EGameEvent.eGameEvent_TipMsgChange, OnChangeTipMsg);
            EventCenter.AddListener(EGameEvent.eGameEvent_InitGameFinish, OnInitGameFinish);
            EventCenter.AddListener(EGameEvent.eGameEvent_InitGameFail, OnInitGameFail);
            EventCenter.AddListener<uint>(EGameEvent.eGameEvent_SelectServer, OnSelectServer);
        }

        //游戏事件注消
        protected override void OnRemoveListener()
        {
            //EventCenter.RemoveListener(EGameEvent.eGameEvent_LoginSuccess, LoginSuccess);
            //EventCenter.RemoveListener(EGameEvent.eGameEvent_LoginFail, ShowLoginFail);
            //EventCenter.RemoveListener<int>(EGameEvent.eGameEvent_CreateAccountFail, OnCreateAccountFail);
            EventCenter.RemoveListener<int>(EGameEvent.eGameEvent_ConnectServerSuccess, OnConnectServerSuccess);
            EventCenter.RemoveListener<int>(EGameEvent.eGameEvent_ConnectServerFail, OnConnectServerFail);

            EventCenter.RemoveListener<string>(EGameEvent.eGameEvent_TipMsgChange, OnChangeTipMsg);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_InitGameFinish, OnInitGameFinish);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_InitGameFail, OnInitGameFail);
            EventCenter.RemoveListener<uint>(EGameEvent.eGameEvent_SelectServer, OnSelectServer);
        }

        //显示
        public override void OnEnable()
        {
            //mVersionLable.text = SdkConector.GetBundleVersion();
            //if(m_UserName != "" && m_Password != "")
            //{
            //    m_CurrentAccount.text = m_UserName;
            //}
            StartInitGame();
        }

        private void StartInitGame()
        {
            m_txtTipMsg.gameObject.SetActive(true);
            LoginControl.Instance.StartInitGame();
        }

        //隐藏
        public override void OnDisable()
        {
        }

        public override void Update(float deltaTime) {
            BlinkAnimation();
        }

        //眨眼睛动画
        void BlinkAnimation() {
            uint dwTickCount = (uint)(Time.time * 10.0f);
            if(dwTickCount != m_dwLastTickCount)
            {
                m_dwLastTickCount = dwTickCount;
                if(dwTickCount % 25 == 3)
                {
                    m_assassinEye.gameObject.SetActive(true);
                }
                else
                {
                    m_assassinEye.gameObject.SetActive(false);
                }
                if(dwTickCount % 25 == 0)
                {
                    m_clericEye.gameObject.SetActive(true);
                }
                else
                {
                    m_clericEye.gameObject.SetActive(false);
                }
                if(dwTickCount % 30 >= 7 && dwTickCount % 30 <= 8)
                {
                    m_warriorEye.gameObject.SetActive(true);
                }
                else
                {
                    m_warriorEye.gameObject.SetActive(false);
                }
                if(dwTickCount % 30 == 0)
                {
                    m_mageEye.gameObject.SetActive(true);
                }
                else
                {
                    m_mageEye.gameObject.SetActive(false);
                }
            }
        }

        ////////////////////////////////UI事件响应////////////////////////////////////
        private void OnSelectServer()
        {
            SelectSvrControl.Instance.Enter();
        }

        private void OnNoticeClick()
        {
            NoticeControl.Instance.Enter();
            SettingHelper.RemoveAllSettings();
        }

        void OnLoginSubmit()
        {
            if (mLoginAccountInput.text.Length < 6)
            {
                mAccountErrorText.text = "账号名不得少于6个字符。";
                mAccountErrorText.gameObject.SetActive(true);
                return;
            }
            if(mLoginPassInput.text == "")
            {
                mAccountErrorText.text = "请输入密码。";
                mAccountErrorText.gameObject.SetActive(true);
                return;
            }
            mWaitingParent.gameObject.SetActive(true);
            mWaitingParent.DOPunchScale(new Vector3(1.1f,1f,1f), 1);

            //mLoginSubmit.gameObject.SetActive(false);
            mLoginSubmit.interactable = false;
            LoginControl.Instance.ChangeAccount = true;
            LoginControl.Instance.Login(mLoginAccountInput.text, mLoginPassInput.text);
        }

        void OnLoginWindowBtn()
        {
            m_LoginWindowParant.gameObject.SetActive(true);           
        }

        void OnCloseLoginWindowBtn()
        {
            m_LoginWindowParant.gameObject.SetActive(false);
        }

        void OnEnterGameBtn()
        {
            LoginControl.Instance.EnterGame();
        }

        void OnSettingBtn()
        {
            Debug.Log("click");
            PlayerPrefs.DeleteAll();
            //m_SettingBtn.transform.DOScale(new Vector3(0.8f,0.8f,0.8f), 1f);
        }

        ////////////////////////////////游戏事件响应////////////////////////////////////
        private void OnSelectServer(uint serverId)
        {
            LoginModel.Instance.OnSelectServer(serverId);
            _showSuggestServer();
        }

        private void OnInitGameFail()
        {
            m_txtTipMsg.gameObject.SetActive(true);
            m_txtTipMsg.text = "游戏初始化失败,请联系管理员！";
            m_EnterGameBtn.gameObject.SetActive(false);
        }

        private void OnInitGameFinish()
        {
            m_txtTipMsg.gameObject.SetActive(false);
            m_EnterGameBtn.gameObject.SetActive(true);
            m_btnNotice.gameObject.SetActive(true);

            _showSuggestServer();
        }

        private void _showSuggestServer()
        {
            cdnServerInfo info = LoginModel.Instance.GetShowServer();
            if(info == null)
            {
                return;
            }
            m_txtSuggestServer.text = "S"+info.serverId+"."+info.serverName;
            m_btnSuggestServer.gameObject.SetActive(true);
        }

        private void OnChangeTipMsg(string msg)
        {
            m_txtTipMsg.text = msg;
        }

        private void OnConnectServerFail(int serverType)
        {
            ServerType type = (ServerType)serverType;
            LoginControl.Instance.OnConnectFail(type);
        }

        private void OnConnectServerSuccess(int serverType)
        {
            ServerType type = (ServerType)serverType;
            LoginControl.Instance.OnConnectSuccess(type);
        }

        //登录失败
        //void LoginFail(EErrorCode errorCode)
        //{
        //    mPlayAnimate.enabled = true;

        //    mPlaySubmitBtn.gameObject.SetActive(true);
        //    GameObject.DestroyImmediate(mPlayEffect.gameObject);
        //}

        ////登陆失败反馈
        //void ShowLoginFail()
        //{
        //    mReLoginParent.gameObject.SetActive(true);
        //    mWaitingParent.gameObject.SetActive(false);
        //    UIEventListener.Get(mPlaySubmitBtn.gameObject).onClick += OnPlaySubmit;
        //}

        ////登陆成功
        void LoginSuccess()
        {
            Debug.Log("Login Success");
            mLoginSubmit.interactable = true;
            mLoginSubmit.onClick.RemoveListener(OnLoginSubmit);
            mWaitingParent.gameObject.SetActive(false);
            m_LoginWindowParant.gameObject.SetActive(false);
            m_CurrentAccount.text = PlayerPrefs.GetString("UserName");

            //提示动画
            m_LoginSuccessTipTweener = m_LoginSuccessTipParent.DOMoveY(m_LoginTipPos.y - m_LoginSuccessTipParent.rect.height, 1f)
                .OnComplete(OnLoginTipComplete);
            m_LoginSuccessTipTweener.SetAutoKill(false);
            m_LoginTipText.text = "欢迎 <color=#00FF00>" + m_CurrentAccount.text + "</color>回来！";
        }

        //登录失败
        void ShowLoginFail()
        {
            Debug.Log("Login Fail");
            mLoginSubmit.interactable = true;
            mWaitingParent.gameObject.SetActive(false);
        }

        void OnCreateAccountFail(int error)
        {
            Debug.Log("create account Fail, error code:" + error);
        }

        void OnLoginTipComplete()
        {
            m_LoginSuccessTipParent.DOPlayBackwards();
        }

        void Pingpong(GameObject obj, float fromValue, float toValue, float duration, TweenType type)
        {
            if(type == TweenType.TweenType_Alpha)
            {
                Color temColor = obj.GetComponent<Image>().color;
                temColor.a = fromValue;
                Tweener tweener = DOTween.ToAlpha(() => temColor, x => temColor = x, toValue, duration);
                tweener.OnUpdate(()=>obj.GetComponent<Image>().color = temColor);
                tweener.OnComplete(() => Pingpong(obj, toValue, fromValue, duration, type));
            }
            else if(type == TweenType.TweenType_Size)
            {
                obj.transform.DOScale(new Vector3(toValue, toValue, toValue), duration)
                                .SetEase(Ease.Linear)
                                .OnComplete(() => Pingpong(obj, toValue, fromValue, duration, type));
            }
        }

        void ToBig()
        {
            m_EnterGameBtn.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 1f)
                .SetEase(Ease.Linear)
                .OnComplete(ToSmall);
        }

        void ToSmall()
        {
            m_EnterGameBtn.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f)
                .SetEase(Ease.Linear)
                .OnComplete(ToBig);
        }

        enum TweenType
        {
            TweenType_Alpha = 1,
            TweenType_Size = 2,
        }

        //登录
        Button mLoginSubmit;
        Button mLoginWindowBtn;
        Button mCloseLoginWindowBtn;
        Button m_EnterGameBtn;

        InputField mLoginPassInput;
        InputField mLoginAccountInput;
        Text mAccountErrorText;

        //等待中
        Transform mWaitingParent;
        Transform mLoadingIcon;
        Transform m_LoginWindowParant;
        RectTransform m_LoginSuccessTipParent;
        Text m_LoginTipText;
        Vector3 m_LoginTipPos;

        Text mVersionLable;
        Tweener mloadingTweener;
        Tweener m_LoginSuccessTipTweener;

        Text m_CurrentAccount;

        Animator m_SettingButtonAni;

        Image m_assassinEye;
        Image m_clericEye;
        Image m_warriorEye;
        Image m_mageEye;

        Text m_txtTipMsg;
        Button m_btnSuggestServer;
        Text m_txtSuggestServer;
        Button m_btnNotice;


        uint m_dwLastTickCount;
    }
}
