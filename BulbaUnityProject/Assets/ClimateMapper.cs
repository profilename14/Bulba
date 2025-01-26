using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ClimateMapper
{
    private const int unitsPerMeter = 4;
    private static Dictionary<Vector2Int, ClimateMap> points = new Dictionary<Vector2Int, ClimateMap>();

    static ClimateMapper()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private static void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Reset();
    }

    public static IEnumerable<(Vector2 point, ClimateMap climate)> GetClimatePointsInRect(Rect rect)
    {
        var position = Vector2Int.FloorToInt(rect.position * unitsPerMeter);
        var size = Vector2Int.CeilToInt(rect.size * unitsPerMeter); 
        var rectInt = new RectInt(position, size);
        foreach (var coord in rectInt.allPositionsWithin)
        {
            var point = (Vector2)coord / unitsPerMeter;
            yield return (point, GetClimateAtCoord(coord));
        }
    }

    public static ClimateMap GetClimate(Vector2 point)
        => GetClimateAtCoord(Vector2Int.RoundToInt(point * unitsPerMeter));
    private static ClimateMap GetClimateAtCoord(Vector2Int point)
    {
        if(points.TryGetValue(point, out var climateMap))
            return climateMap;

        var camera = Camera.main;

        var colliders = Physics2D.OverlapPointAll((Vector2)point / unitsPerMeter);
        climateMap = 0;
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out ClimateZone climateZone))
            {
                climateMap |= climateZone.myClimateMap;
            }
        }

        points[point] = climateMap;

        return climateMap;
    }

    public static void Reset()
    {
        points.Clear();
    }
}
