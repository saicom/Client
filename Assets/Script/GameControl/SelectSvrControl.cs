using UnityEngine;
using System;


namespace Ctrl
{
    public class SelectSvrControl : Singleton<SelectSvrControl>
    {
        public void Enter()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_SelectSvrEnter);
        }

        public void Exit()
        {
            EventCenter.Broadcast(EGameEvent.eGameEvent_SelectSvrExit);
        }


    }
}
