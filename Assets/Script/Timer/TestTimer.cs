using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TestTimer : ITimer
{
    string content = "this is a test timer!";
    public void OnTimer()
    {
        Debug.LogError(content);
    }
}
