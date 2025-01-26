using System;
using System.Collections.Generic;
using UnityEngine;

public class ClimateAlerts : MonoBehaviour
{
    [SerializeField] Alert climateAlertTemplate;

    Dictionary<ClimateMap, Alert> climateAlerts = new Dictionary<ClimateMap, Alert>();
    Alert lowEnergyAlert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (climateAlertTemplate.gameObject.scene != default)
            climateAlertTemplate.gameObject.SetActive(false);

        foreach (ClimateMap climateMap in Enum.GetValues(typeof(ClimateMap)))
        {
            if(climateMap != ClimateMap.None)
            {
                var alert = CreateAlert(GetClimateWarning(climateMap));
                climateAlerts.Add(climateMap, alert);
            }
        }

        lowEnergyAlert = CreateAlert("Not Enough Energy:\nEnergy Plants Needed");
    }

    private Alert CreateAlert(string message)
    {
        var alert = Instantiate(climateAlertTemplate, climateAlertTemplate.transform.parent);
        alert.Setup(message);
        alert.gameObject.SetActive(true);
        return alert;
    }

    // Update is called once per frame
    void Update()
    {
        var stats = StatsSingleton.Instance;
        var currentClimates = stats.climateManager.CurrentClimates;
        foreach ((var climate, var alert) in climateAlerts)
        {
            alert.gameObject.SetActive(currentClimates.HasFlag(climate));
        }
        lowEnergyAlert.gameObject.SetActive(stats.energyGen < stats.energyUse);
    }

    private string GetClimateWarning(ClimateMap climate)
    {
        return climate switch
        {
            ClimateMap.isExtremeCold => "Extreme Cold Detected:\nPlants May Die",
            ClimateMap.isCold => "Cold Detected:\nPlants May Die",
            ClimateMap.isHeat => "Heat Detected:\nPlants May Die",
            ClimateMap.isExtremeHeat => "Extreme Heat Detected:\nPlants May Die",
            ClimateMap.isDark => "Reduced Light:\nProduction Reduced",
            ClimateMap.isHighLight => "High Light:\nProduction Accelerated",
            ClimateMap.isHighNutrition => "High Nutrition:\nEfficient Fertilizer Use",
            ClimateMap.isPoison => "Poison Detected:\nPlants May Die",
            _ => ""
        };
    }
}
