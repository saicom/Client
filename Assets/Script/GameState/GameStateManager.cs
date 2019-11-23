using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public enum GameStateType
    {
        GS_Continue,
        GS_Login,
        GS_CreateRole,
        GS_Lobby,
        GS_Loading,
    }

    public class GameStateManager : Singleton<GameStateManager>
    {
        Dictionary<GameStateType, IGameState> m_gameStates;
        IGameState currentState;

        public GameStateManager()
        {
            m_gameStates = new Dictionary<GameStateType, IGameState>();

            RegisterState();
        }

        public void RegisterState()
        {
            IGameState gameState;

            gameState = new LoginState();
            m_gameStates.Add(gameState.GetStateType(), new LoginState());

            gameState = new LobbyState();
            m_gameStates.Add(gameState.GetStateType(), gameState);

            gameState = new CreateRoleState();
            m_gameStates.Add(gameState.GetStateType(), gameState);
        }

        public IGameState GetCurState()
        {
            return currentState;
        }

        public void ChangeGameStateTo(GameStateType stateType)
        {
            if (currentState != null && currentState.GetStateType() != GameStateType.GS_Loading && 
                currentState.GetStateType() == stateType)
                return;

            if (m_gameStates.ContainsKey(stateType))
            {
                if (currentState != null)
                {
                    currentState.Exit();
                }

                currentState = m_gameStates[stateType];
                currentState.Enter();
            }
        }

        public void EnterDefaultState()
        {
            ChangeGameStateTo(GameStateType.GS_Login);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            if (currentState != null)
            {
                currentState.FixedUpdate(fixedDeltaTime);
            }
        }

        public void Update(float fDeltaTime)
        {
            GameStateType nextStateType = GameStateType.GS_Continue;
            if (currentState != null)
            {
                nextStateType = currentState.Update(fDeltaTime);
            }

            if (nextStateType > GameStateType.GS_Continue)
            {
                ChangeGameStateTo(nextStateType);
            }
        }

        public IGameState getState(GameStateType type)
        {
            if (!m_gameStates.ContainsKey(type))
            {
                return null;
            }
            return m_gameStates[type];
        }
    }
}
