using UnityEngine;
using System;
using System.Collections.Generic;


namespace Model
{
    public class LoginModel : Singleton<LoginModel>
    {
        public int TryConnectTimes = 0;
        public string GateAddress;
        private int MaxConnectTimes = 5;
        

        public void Reset()
        {
            TryConnectTimes = 0;
        }

        public bool TryConnect()
        {
            return TryConnectTimes++ < MaxConnectTimes;
        }
	}
}
