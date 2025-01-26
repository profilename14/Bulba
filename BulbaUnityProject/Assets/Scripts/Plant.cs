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


    [SerializeField] public float fertilizerCostPerSecond = 0;
    [SerializeField] public float DNAProductionPerSecond = 0;
    [SerializeField] public float energyProduction = 0;
    [SerializeField] public float energyConsumption = 0;
    [SerializeField] public float heating = 0; // Should be from 0-0.5
    [SerializeField] public float cooling = 0; // Should be from 0-0.5
    [SerializeField] public float lumination = 0; // Should be from 0-0.5 but not neccessarily



    protected void Start()
    {
        
    }

    protected void Update()
    {
        growth += growthRate * Time.deltaTime;
        transform.localScale = Vector3.one * Mathf.Lerp(.25f, 1, Mathf.Clamp01(growth));

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