using UnityEngine;
using System.Collections;
using GameDefine;
using Ctrl;

namespace GameState
{
    class LoginState : IGameState
    {
        GameStateType stateTo;

		public LoginState()
		{
		}

        public GameStateType GetStateType()
        {
            return GameStateType.GS_Login;
        }

        public void SetStateTo(GameStateType gs)
        {
            stateTo = gs;
        }

        public void Enter()
        {
            SetStateTo(GameStateType.GS_Continue);
         
            LoginControl.Instance.Enter();
        
            AudioManager.Instance.PlayBackgroundMusic(AudioDefine.LoginBg);

            EventCenter.AddListener<CEvent>(EGameEvent.eGameEvent_IntoLobby, OnEvent);
            EventCenter.AddListener<CEvent>(EGameEvent.eGameEvent_CreateRole, OnEvent);
        }

        public void Exit()
        {
            LoginControl.Instance.Exit();
            EventCenter.RemoveListener<CEvent>(EGameEvent.eGameEvent_IntoLobby, OnEvent);
            EventCenter.RemoveListener<CEvent>(EGameEvent.eGameEvent_CreateRole, OnEvent);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            
        }

        public GameStateType Update(float fDeltaTime)
        {
            return stateTo;
        }

        public void OnEvent(CEvent evt)
        {
            switch(evt.GetEventId())
            {
                case EGameEvent.eGameEvent_IntoLobby:
                    GameStateManager.Instance.ChangeGameStateTo(GameStateType.GS_Lobby);
                    break;
                case EGameEvent.eGameEvent_CreateRole:
                    GameStateManager.Instance.ChangeGameStateTo(GameStateType.GS_CreateRole);
                    break;
            }
        }
    }
}


