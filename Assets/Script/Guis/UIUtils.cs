using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class UIUtils
{
    public static void OpenWaitingWnd()
    {
        EventCenter.Broadcast(EGameEvent.eGameEvent_WaitingEnter);
    }

    public static void CloseWaitingWnd()
    {
        EventCenter.Broadcast(EGameEvent.eGameEvent_WaitingExit);
    }
}
