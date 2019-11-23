using UnityEngine;
using System.Collections;
using GameDefine;
using Ctrl;

namespace GameState
{
    class LobbyState : IGameState
    {
        GameStateType stateTo;

		public LobbyState()
		{
		}

        public GameStateType GetStateType()
        {
            return GameStateType.GS_Lobby;
        }

        public void SetStateTo(GameStateType gs)
        {
            stateTo = gs;
        }

        public void Enter()
        {
            SetStateTo(GameStateType.GS_Continue);
         
            //LobbyControl.Instance.Enter();
        
            AudioManager.Instance.PlayBackgroundMusic(AudioDefine.LobbyBg);
        }

        public void Exit()
        {
            //LobbyControl.Instance.Exit();
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            
        }

        public GameStateType Update(float fDeltaTime)
        {
            return stateTo;
        }
    }
}


