using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager
{
  private Dictionary<EVENT, UnityEvent> eventDictionary = new Dictionary<EVENT, UnityEvent>();
  private static EventManager eventManager = new EventManager();
  private EventManager()
  {
  }
  public static EventManager GetInstance
  {
    get
    {
      return eventManager;
    }
  }
  public void StartListening(EVENT eventNo, UnityAction listener)
  {
    UnityEvent thisEvent = null;
    if (eventManager.eventDictionary.TryGetValue(eventNo, out thisEvent))
    {
      thisEvent.AddListener(listener);
    }
    else
    {
      thisEvent = new UnityEvent();
      thisEvent.AddListener(listener);
      eventManager.eventDictionary.Add(eventNo, thisEvent);
    }
  }
  public void StopListening(EVENT eventNo, UnityAction listener)
  {
    if (eventManager == null) return;
    UnityEvent thisEvent = null;
    if (eventManager.eventDictionary.TryGetValue(eventNo, out thisEvent))
    {
      thisEvent.RemoveListener(listener);
    }
  }
  public void TriggerEvent(EVENT eventNo)
  {
    Debug.Log("TriggerEvent "+eventNo);
    UnityEvent thisEvent = null;
    if (eventManager.eventDictionary.TryGetValue(eventNo, out thisEvent))
    {
      thisEvent.Invoke();
    }
  }
}

public enum EVENT
{
    GO_NEXT_STAGE = 1,
    GO_WRONG_PENALTY = 2,
    END_WRONG_PENALTY = 3,
    END_GO_NEXT_STAGE = 4,
    GO_FINAL = 5,
    FINAL_ROCK_DOWN = 6,
    FINAL_TEMPLE_UP = 7,
    FINAL_ANIMATION = 8,
}
