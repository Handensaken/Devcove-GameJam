using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEventManger : MonoBehaviour
{
     public static GameEventManger instance { get; private set; }
    [NonSerialized] public PlayerEvents playerEvents;
    private void Awake()
    {
        instance = this;
        playerEvents = new PlayerEvents();
    }
}
