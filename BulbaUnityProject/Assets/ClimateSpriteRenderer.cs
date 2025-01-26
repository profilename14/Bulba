using UnityEngine;

public class ClimateSpriteRenderer : MonoBehaviour
{
    [SerializeField] Vector2Int padding;

    [SerializeField] new ParticleSystem particleSystem;

    public ClimateMap climate;

    float lastSpawn = 0;
    public float particlesPerSecond = 10;

    private void Start()
    {
        lastSpawn = Time.time;
    }

    private void Update()
    {
        var camera = Camera.main;
        var min = (Vector2)camera.ViewportToWorldPoint(Vector2.zero) - padding;
        var max = (Vector2)camera.ViewportToWorldPoint(Vector2.one) + padding;
        var worldRect = new Rect(min, max - min);

        var particleParams = new ParticleSystem.EmitParams();
        foreach ((var point, var pointClimate) in ClimateMapper.GetClimatePointsInRect(worldRect))
        {
            if ((pointClimate & climate) != 0)
            {
                particleParams.position = (Vector3)(point + Random.insideUnitCircle / 2) + Vector3.forward * transform.position.z;
                float particleCount = particlesPerSecond * Time.deltaTime;
                particleSystem.Emit(particleParams, Mathf.FloorToInt(particleCount) + ((Random.value<particleCount%1)?1:0));
            }
        }
    }
}