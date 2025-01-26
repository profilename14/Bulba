using UnityEngine;

[CreateAssetMenu]
public class PlantType : ScriptableObject
{
    public Sprite sprite;
    public Plant plantPrefab;
    public float fertilizerCostPerSecond = 0;
    public float DNAProductionPerSecond = 0;
    public float energyProduction = 0;
    public float energyConsumption = 0;
    public float heating = 0; // Should be from 0-0.5
    public float cooling = 0; // Should be from 0-0.5
    public float lumination = 0; // Should be from 0-0.5 but not neccessarily
}
