using System;
using UnityEngine;

[Serializable]
public struct Powerup
{
    public enum PowerupType
    {
        None,
        Range,
        Speed,
        Damage,
        Capacity
    }

    public PowerupType type;
    public float amount;
}
