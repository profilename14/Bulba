using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] 
    private Image image;

    [SerializeField]
    public float growthRate;

    private float growth;
    public bool FullyGrown => growth >= 1;

    public float Health => health;
    private float health = 1;


    public float fertilizerCostPerSecond = 0;
    public float DNAProductionPerSecond = 0;
    public float energyProduction = 0;
    public float energyConsumption = 0;
    public float heating = 0; // Should be from 0-0.5
    public float cooling = 0; // Should be from 0-0.5
    public float lumination = 0; // Should be from 0-0.5 but not neccessarily



    protected void Start()
    {
        
    }

    protected void Update()
    {
        growth += growthRate * Time.deltaTime;
        transform.localScale = Vector3.one * Mathf.Lerp(.5f, 1.7f, Mathf.Clamp01(growth));

        var healthChangePerSecond = 0;//TODO damage and recovery based on zones
        health = Mathf.Clamp01(health + healthChangePerSecond * Time.deltaTime);
        image.color = Color.Lerp(Color.black, Color.white, health);
        if (health <= 0)
            Destroy(gameObject);
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
}