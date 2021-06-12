using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class GameObjectExtension
{
    public static void AddClickListener(this GameObject gameObject, UnityEvent<GameObject> callback)
    {
        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger == null) trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { callback.Invoke(gameObject); });
        trigger.triggers.Add(entry);
    }

    public static void RemoveAllClickListener(this GameObject gameObject)
    {

        EventTrigger trigger = gameObject.GetComponent<EventTrigger>();
        if (trigger != null)
        {
            trigger.triggers.Clear();
        }
    }
}
