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
    public event Action<bool> OnMenuChoice;
    public void MenuChoice(bool ShouldKill)
    {
        if (OnMenuChoice != null)
        {
            OnMenuChoice(ShouldKill);
        }
    }
    public event Action OnGameOver;

    public void GameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
    public event Action OnDestroyedNonMimic;
    public void DestroyedNonMimic()
    {
        if (OnDestroyedNonMimic != null)
        {
            OnDestroyedNonMimic();
        }
    }
}
