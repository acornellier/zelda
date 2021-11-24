using UnityEngine;
using System;

[Serializable]
public struct HitData
{
    public float damage;
    public float thrust;
    public float staggerTime;
}

public struct Hit
{
    public Transform source;
    public HitData data;
}
