using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application
{
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
