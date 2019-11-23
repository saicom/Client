using UnityEngine;
using System.Collections;
using GameDefine;
using Ctrl;

namespace GameState
{
    class CreateRoleState : IGameState
    {
        GameStateType stateTo;

		public CreateRoleState()
		{
		}

        public GameStateType GetStateType()
        {
            return GameStateType.GS_CreateRole;
        }

        public void SetStateTo(GameStateType gs)
        {
            stateTo = gs;
        }

        public void Enter()
        {
            SetStateTo(GameStateType.GS_Continue);

            EventCenter.Broadcast(EGameEvent.eGameEvent_CreateRoleEnter);
            EventCenter.AddListener<CEvent>(EGameEvent.eGameEvent_IntoLobby, OnEvent);
        }

        public void Exit()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_CreateRoleExit);
            EventCenter.RemoveListener<CEvent>(EGameEvent.eGameEvent_IntoLobby, OnEvent);
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
            }
        }
    }
}


