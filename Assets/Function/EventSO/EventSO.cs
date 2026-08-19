using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Event", menuName ="ScriptableObjects/EventSO")]
public class EventSO : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Raise()
    {
        foreach (EventListener listener in listeners)
        {
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void DeregisterListener(EventListener listener)
    {
        listeners.Remove(listener);
    }


}
