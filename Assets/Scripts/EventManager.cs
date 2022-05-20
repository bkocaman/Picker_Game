using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void EventHandler();

    public EventHandler EventContinue;
    public EventHandler EventFail;
    public EventHandler EventFinish;

    public EventHandler EventPlay;
    public EventHandler EventStop;
    public EventHandler EventWin;
}