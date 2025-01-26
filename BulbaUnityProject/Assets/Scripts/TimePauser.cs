using System.Collections.Generic;
using UnityEngine;

public class TimePauser : MonoBehaviour
{
    public static bool Pausing => pausers.Count > 0;
    private static readonly HashSet<TimePauser> pausers = new HashSet<TimePauser>();

    void OnEnable()
    {
        pausers.Add(this);
        TimeScaling.UpdateTimeScale();
    }


    void OnDisable()
    {
        pausers.Remove(this);
        TimeScaling.UpdateTimeScale();
    }
}