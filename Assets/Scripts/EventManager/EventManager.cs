using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void EventHandler();

    public EventHandler OnPlay;
    public EventHandler OnStop;
    public EventHandler OnWin;
    public EventHandler OnContinue;
    public EventHandler OnFail;
    public EventHandler OnFinish;
  
}