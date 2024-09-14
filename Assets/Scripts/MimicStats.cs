using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "ScriptableObjects/StatsForPlayer")]
[Serializable]

public class MimicStats : ScriptableObject
{
    public int mimicAmount;
    public int mimicsFound;
    public int nonMimicsDestroyed;
}
