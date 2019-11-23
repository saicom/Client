using UnityEngine;
using System.Collections;

namespace GameDefine
{
	public static class GameConstDefine {
        public static string ConfigPath = "Csv/";

        //login
		public static string LoadGameLoginUI = "UI/Login/UILogin";
		public static string LoadNoticeUI = "UI/Login/UINotice";
		public static string LoadWaitingUI = "UI/Common/UIWaiting";
        public static string LoadSelectSvrUI = "UI/Login/UISelectSvr";
        
		public static string LoadLobbyUI = "Gui/UILobby";
		public static string LoadCreateRoleUI = "Gui/UICreateRole";
		public static string LoadInventoryUI = "Gui/UIBag";
		public static string LoadItemInfoUI = "Gui/UIItemInfo";
		public static string LoadMsgBoxUI = "Gui/UIMsgBox";
		public static string LoadMarqueeUI = "Gui/UIMarquee";
		public static string LoadGmUI = "Gui/UIGmPanel";
        public static string LoadFlowMsgUI = "Gui/UIFlowMsg";
        public static string LoadChatUI = "Gui/UIChat";
        public static string LoadSelfChatMsgUI = "Gui/UISelfChatMsg";
        public static string LoadOtherChatMsgUI = "Gui/UIOtherChatMsg";
        public static string LoadGuildInviteChatUI = "Gui/UIInviteGuildPanel";
        public static string LoadFriendsUI = "Gui/UIFriendPanel";
        public static string LoadFriendContainer = "Gui/FriendsContainer";
        public static string LoadUserBriefInfoUI = "Gui/UIUserPopInfo";


        
        public static int ChatMsgMaxCount = 30;   //聊天框最大消息数


        //lobby

        public static string ResRootPath
        {
            get
            {
                //Debug.LogError(Application.platform);
                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsPlayer:
                    case RuntimePlatform.WindowsEditor:
                         //return Application.dataPath + "/StreamingAssets/Windows/";
                         return "file:///" + Application.dataPath + "/StreamingAssets/Windows/";
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                        return "file:///" + Application.dataPath + "/StreamingAssets/Ios/";
                    case RuntimePlatform.IPhonePlayer:
                        return "file:///" + Application.dataPath + "/Raw/Ios/";
                    case RuntimePlatform.Android:
                        return "jar:file://" + Application.dataPath + "!/assets/Android/";
                }
                return "";
            }
        }

	}

}


