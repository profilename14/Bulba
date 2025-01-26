using UnityEngine;

public class ClimateRenderer : MonoBehaviour
{
    [System.Serializable]
    private struct FlagColors
    {
        public ClimateMap map;
        public Color color;
    }

    [SerializeField] Vector2Int padding;

    [SerializeField] FlagColors[] flagColors;

    [SerializeField] new ParticleSystem particleSystem;

    float lastSpawn = 0;
    public int particlesPerSecond = 10;

    private void Start()
    {
        lastSpawn = Time.time;
    }

    private void Update()
    {
        float spawnRate = 1f / particlesPerSecond;
        int spawnCount = 0;
        while (lastSpawn + spawnRate < Time.time && spawnRate > 0 && spawnCount < particlesPerSecond / 4f)
        {
            lastSpawn += spawnRate;
            spawnCount++;
        }

        if (spawnCount > 0)
        {
            var camera = Camera.main;
            var min = (Vector2)camera.ViewportToWorldPoint(Vector2.zero) - padding;
            var max = (Vector2)camera.ViewportToWorldPoint(Vector2.one) + padding;
            var worldRect = new Rect(min, max-min);

            var particleParams = new ParticleSystem.EmitParams();
            foreach ((var point, var climate) in ClimateMapper.GetClimatePointsInRect(worldRect))
            {
                if (climate != ClimateMap.None)
                {
                    foreach (var flagColor in flagColors)
                    {
                        if (climate.HasFlag(flagColor.map))
                        {
                            particleParams.position = point + Random.insideUnitCircle/2;
                            particleParams.startColor = flagColor.color;
                            particleSystem.Emit(particleParams, spawnCount);
                        }
                    }
                }
            }
        }
    }
}