using Unity.VisualScripting;
using System.Collections.Generic;
using UnityEngine;

public class StatsSingleton : MonoBehaviour {
    private static StatsSingleton _instance;

    public static StatsSingleton Instance { get { return _instance; } }

    public float fertilizer = 200; // Consumed over time by most plants, also used to grow new ones. Collected by moving.
    public float Research = 0; // Used to unlock new plants. Generated by plants and found occasionally by moving.
    public float DNA = 0; // Used to modify one plant into another. Get out of jail free resource if your low on fertilizer.
    public float energyUse = 0; // If this is higher than energy gen, plants start to wither.
    public float baseEnergyUse = 2; // This much energy gen is needed to move
    public float energyGen = 0; // If lower than the baseline energy gen, you can't move (but no damage over time)
    public float baseLightLevelModifier = 1; // what light level modifier will move toward over time.
    public float lightLevelModifier = 1; // 1 = neutral, -0.5 in darkness and +1.5 in light.
    public float baseFertilizerModifier = 1; // what fertilizer mod will move to over time
    public float fertilizerModifier = 1; // this multiplies the amount consumed over time. 0.5 in nutritous areas, 1.5 in poison.
    public float baseTemperature = 0.5f; // what temperature will gradually move toward over time
    public float temperature = 0.5f; // 0.5 = neutral, 0 = coldest, 1 = warmest
    [SerializeField] public ClimateManager climateManager;
    [SerializeField] public PlayerController playerController;

    [SerializeField] public Garden garden;
    private List<Plant> curPlants;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        curPlants = new List<Plant>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        UpdateExternalVariables(climateManager);
    }
    
    private void UpdateExternalVariables(ClimateManager climateManager)
    {
        baseTemperature = 0.5f;
        if (climateManager.isWithinExtremeCold) {
            baseTemperature -= 0.5f;
        }
        else if (climateManager.isWithinCold) {
            baseTemperature -= 0.25f;
        }

        if (climateManager.isWithinExtremeHeat) {
            baseTemperature += 0.5f;
        }
        else if (climateManager.isWithinHeat) {
            baseTemperature += 0.25f;
        }

        baseLightLevelModifier = 1f;
        if (climateManager.isWithinHighLight)
            baseLightLevelModifier += 0.5f;
        if (climateManager.isWithinDark)
            baseLightLevelModifier -= 0.25f;

        baseFertilizerModifier = 1f;
        if (climateManager.isWithinHighNutrition)
            baseFertilizerModifier -= 0.5f;
        if (climateManager.isWithinPoison)
            baseFertilizerModifier += 0.5f;

        UpdatePlantList();

        UpdateExternalPlants();

        UpdatePlants();

        UpdateExternals();
        
    }

    void UpdatePlantList()
    {
        curPlants.Clear();
        foreach (PlantingSlot slot in garden.PlantingSlots)
        {
            if (slot.PlantedPlant != null)
            {
                curPlants.Add(slot.PlantedPlant);
            }
        }
    }

    void UpdateExternalPlants()
    {
        energyGen = 0;
        energyUse = baseEnergyUse;
        foreach (Plant plant in curPlants)
        {
            if (plant.FullyGrown)
            {
                baseTemperature += plant.heating;
                baseTemperature -= plant.cooling;
                lightLevelModifier += plant.lumination;
                energyGen += plant.energyProduction * lightLevelModifier;
                energyUse += plant.energyConsumption;
            }
            

        }
    }

    void UpdatePlants()
    {
        foreach (Plant plant in curPlants)
        {
            if (fertilizer > plant.fertilizerCostPerSecond )
            {
                fertilizer -= plant.fertilizerCostPerSecond * Time.deltaTime * fertilizerModifier;
            }
            else
            {
                plant.SetHealth(plant.Health - Time.deltaTime * plant.growthRate);
                if (playerController)
                {
                    Destroy(playerController.gameObject);
                }
                
            }

            if (energyUse - 2 > energyGen)
            {

            }

            if (temperature > 0.7f || temperature < 0.3f)
            {
                plant.SetHealth(plant.Health - Time.deltaTime * plant.growthRate);
            }

            if (plant.Health < 1)
            {
                plant.SetHealth(plant.Health + Time.deltaTime * plant.growthRate * 0.35f);
            }
                
        }
        
    }

    void UpdateExternals()
    {
        // TODO smoothing curve

        temperature = temperature + (baseTemperature - temperature) * Time.deltaTime * 0.33f;
        lightLevelModifier = lightLevelModifier + (baseLightLevelModifier - lightLevelModifier) * Time.deltaTime * 0.33f;
        fertilizerModifier = fertilizerModifier + (baseFertilizerModifier - fertilizerModifier) * Time.deltaTime * 0.33f;
    }
}