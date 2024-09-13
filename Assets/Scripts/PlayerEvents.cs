using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public event Action OnChooseMimic;
    public void ChooseMimic()
    {
        if (OnChooseMimic != null)
        {
            OnChooseMimic();
        }
    }
}
