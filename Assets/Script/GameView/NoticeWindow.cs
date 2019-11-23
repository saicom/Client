using UnityEngine;
using UnityEngine.UI;
using System;
using GameDefine;
using Model;


namespace View
{
    public class NoticeWindow : BaseWindow
    {
        public NoticeWindow() 
        {
            mScenesType = EScenesType.EST_Login;
            mResName = GameConstDefine.LoadNoticeUI;
            mResident = false;
        }

        ////////////////////////////Inherit interface/////////////////////////

        public override void Init()
        {
            EventCenter.AddListener(EGameEvent.eGameEvent_NoticeEnter, Show);
            EventCenter.AddListener(EGameEvent.eGameEvent_NoticeExit, Hide);
        }

        public override void Release()
        {
            EventCenter.RemoveListener(EGameEvent.eGameEvent_NoticeEnter, Show);
            EventCenter.RemoveListener(EGameEvent.eGameEvent_NoticeExit, Hide);
        }

        protected override void InitWidget()
        {
            m_txtNotice = mRoot.Find("NoticeBox/Panel/Viewport/Text").GetComponent<Text>();
            m_btnClose = mRoot.Find("NoticeBox/CloseBtn").GetComponent<Button>();
            m_tweenScale = mRoot.Find("NoticeBox").GetComponent<HCTweenScale>();

            m_noticeBox = mRoot.Find("NoticeBox").GetComponent<RectTransform>();
            m_imgArraw = mRoot.Find("NoticeBox/Arraw").GetComponent<Image>();
            m_czf = m_txtNotice.GetComponent<ContentSizeFitter>();
            m_scrollRect = mRoot.Find("NoticeBox/Panel").GetComponent<ScrollRect>();

            m_btnClose.onClick.AddListener(OnCloseBtn);
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

        public override void Update(float deltaTime)
        {
            Debug.LogError(m_txtNotice.rectTransform.sizeDelta.ToString() + "," + m_txtNotice.rectTransform.localPosition.ToString());
            Debug.LogError(m_fscrollViewHeight);
            if(m_scrollRect.gameObject.activeSelf)
            {
                if (m_txtNotice.rectTransform.localPosition.y + m_fscrollViewHeight > m_txtNotice.rectTransform.sizeDelta.y - 10)
                {
                    m_imgArraw.gameObject.SetActive(false);
                }
                else
                {
                    m_imgArraw.gameObject.SetActive(true);
                }
            }
        }

        public override void OnEnable()
        {
            //播完动画打开scroll rect
            m_tweenScale.OnComplete = (() => { m_scrollRect.enabled = true; });
            m_tweenScale.PlayForward();

            m_txtNotice.text = NoticeModel.Instance.ServerCdnInfo.notice;
            if (m_txtNotice.preferredHeight > m_noticeBox.sizeDelta.y)
            {
                m_imgArraw.gameObject.SetActive(true);
            }
            else
            {
                m_scrollRect.enabled = false;
            }
            m_fscrollViewHeight = m_scrollRect.GetComponent<RectTransform>().rect.height;
        }

        public override void OnDisable()
        {
        }

        ////////////////////////////////UI event////////////////////////////////////
        private void OnCloseBtn()
        {
            m_tweenScale.OnComplete = (() => { Hide(); });
            m_tweenScale.PlayReverse();
        }

        ////////////////////////////////Game event////////////////////////////////////

        ////////////////////////////////Member define////////////////////////////////////
        Text m_txtNotice;
        Button m_btnClose;
        HCTweenScale m_tweenScale;
        RectTransform m_noticeBox;
        Image m_imgArraw;
        ContentSizeFitter m_czf;
        ScrollRect m_scrollRect;

        //滚动窗口高度
        float m_fscrollViewHeight;
    }
}
