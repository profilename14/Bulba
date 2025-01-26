using UnityEngine;

public static class TimeScaling
{
    public static void UpdateTimeScale()
        => Time.timeScale = CalculateTimeScale();

    private static float CalculateTimeScale()
    {
        if (TimePauser.Pausing)
            return 0;

        return 1;
    }
}
