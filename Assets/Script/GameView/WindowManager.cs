using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace View
{
    public enum EScenesType
    {
        EST_None,
        EST_Login,
        EST_Play,
    }

    public enum EWindowType
    {
        EWT_LoginWindow,
        EWT_NoticeWindow,
        EWT_WaitingWindow,
        EWT_SelectSvrWindow,
        EWT_LobbyWindow,
        EWT_CreateRoleWindow,
        EWT_InventoryWindow,
        EWT_ItemInfoWindow,
        EWT_MsgBoxWindow,
        EWT_MarqueeWindow,
        EWT_GmWindow,
        EWT_FlowMsgWindow,
        EWT_ChatWindow,
        EWT_FriendWindow,
        EWT_UserBriefPopWindow,
    }

    public class WindowManager : Singleton<WindowManager>
    {
        public WindowManager()
        {
            mWidowDic = new Dictionary<EWindowType, BaseWindow>();

            mWidowDic[EWindowType.EWT_LoginWindow] = new LoginWindow();
            mWidowDic[EWindowType.EWT_NoticeWindow] = new NoticeWindow();
            mWidowDic[EWindowType.EWT_WaitingWindow] = new WaitingWindow();
            mWidowDic[EWindowType.EWT_SelectSvrWindow] = new SelectSvrWindow();
            //mWidowDic[EWindowType.EWT_LobbyWindow] = new LobbyWindow();
            //mWidowDic[EWindowType.EWT_CreateRoleWindow] = new CreateRoleWindow();
            //mWidowDic[EWindowType.EWT_InventoryWindow] = new InventoryWindow();
            //mWidowDic[EWindowType.EWT_ItemInfoWindow] = new IteminfoWindow();
            //mWidowDic[EWindowType.EWT_MsgBoxWindow] = new MsgBoxWindow();
            //mWidowDic[EWindowType.EWT_MarqueeWindow] = new MarqueeWindow();
            //mWidowDic[EWindowType.EWT_GmWindow] = new GmWindow();
            //mWidowDic[EWindowType.EWT_FlowMsgWindow] = new FlowMsgWindow();
            //mWidowDic[EWindowType.EWT_ChatWindow] = new ChatWindow();
            //mWidowDic[EWindowType.EWT_FriendWindow] = new FriendsWindow();
            //mWidowDic[EWindowType.EWT_UserBriefPopWindow] = new UserBriefInfoWindow();
            //foreach(KeyValuePair<EWindowType, BaseWindow> kv in mWidowDic)
            //{
            //    Debug.LogError(kv.ToString() + ":" + System.Runtime.InteropServices.Marshal.SizeOf(kv.Value));
            //}
        }

        public BaseWindow GetWindow(EWindowType type)
        {
            if (mWidowDic.ContainsKey(type))
                return mWidowDic[type];

            return null;
        }

        public void Update(float deltaTime)
        {
            foreach (BaseWindow pWindow in mWidowDic.Values)
            {
                if (pWindow.IsVisible())
                {
                    pWindow.Update(deltaTime);
                }
            }
        }

        public void ChangeScenseToPlay(EScenesType front)
        {
            foreach (BaseWindow pWindow in mWidowDic.Values)
            {
                if (pWindow.GetScenseType() == EScenesType.EST_Play)
                {
                    pWindow.Init();

                    if(pWindow.IsResident())
                    {
                        pWindow.PreLoad();
                    }
                }
                else if ((pWindow.GetScenseType() == EScenesType.EST_Login) && (front == EScenesType.EST_Login))
                {
                    pWindow.Hide();
                    pWindow.Release();

                    if (pWindow.IsResident())
                    {
                        pWindow.DelayDestory();
                    }
                }
            }
        }

        public void ChangeScenseToLogin(EScenesType front)
        {
            foreach (BaseWindow pWindow in mWidowDic.Values)
            {
                if (front == EScenesType.EST_None && pWindow.GetScenseType() == EScenesType.EST_None)
                {
                    pWindow.Init();

                    if (pWindow.IsResident())
                    {
                        pWindow.PreLoad();
                    }
                }

                if (pWindow.GetScenseType() == EScenesType.EST_Login)
                {
                    pWindow.Init();

                    if (pWindow.IsResident())
                    {
                        pWindow.PreLoad();
                    }
                }
                else if ((pWindow.GetScenseType() == EScenesType.EST_Play) && (front == EScenesType.EST_Play))
                {
                    pWindow.Hide();
                    pWindow.Release();

                    if (pWindow.IsResident())
                    {
                        pWindow.DelayDestory();
                    }
                }
            }
        }

        /// <summary>
        /// 隐藏该类型的所有Window
        /// </summary>
        /// <param name="front"></param>
        public void HideAllWindow(EScenesType front)
        {
            foreach (var pWindow in mWidowDic.Values)
            {
                if (front == pWindow.GetScenseType())
                {
                    pWindow.Hide();
                    //item.Value.Realse();
                }
            }
        }

        public void ShowWindowOfType(EWindowType type)
        { 
            BaseWindow window;
            if(!mWidowDic.TryGetValue(type , out window))
            {
                return;
            }
            window.Show();
        }

        private Dictionary<EWindowType, BaseWindow> mWidowDic;
    }


}
