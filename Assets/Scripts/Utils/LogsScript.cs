using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogsScript : MonoBehaviour
{
    public void DebugLog(string log)
    {
        Button btn;
        Debug.Log(log);
    }

}
