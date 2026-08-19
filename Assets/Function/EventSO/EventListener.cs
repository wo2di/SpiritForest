using UnityEngine;
using UnityEngine.Events;
public class EventListener : MonoBehaviour
{
    public EventSO eventSO;

    public UnityEvent Response;

    private void OnEnable()
    {
        eventSO.RegisterListener(this);
    }

    private void OnDisable()
    {
        eventSO.DeregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

}
