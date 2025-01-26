using UnityEngine;
using UnityEngine.EventSystems;

public class PlantingSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static PlantingSlot hoveredPlantingSlot;

    public Plant PlantedPlant { get; private set; }

    public void Plant(PlantType plantType)
    {
        if(PlantedPlant)
            Destroy(PlantedPlant.gameObject);

        PlantedPlant = Instantiate(plantType.plantPrefab, transform);
        PlantedPlant.transform.position -= new Vector3 (0, 12.5f, 0);
        
        PlantedPlant.fertilizerCostPerSecond = plantType.fertilizerCostPerSecond;
        PlantedPlant.DNAProductionPerSecond = plantType.DNAProductionPerSecond;
        PlantedPlant.energyProduction = plantType.energyProduction;
        PlantedPlant.energyConsumption = plantType.energyConsumption;
        PlantedPlant.heating = plantType.heating;
        PlantedPlant.cooling = plantType.cooling;
        PlantedPlant.lumination = plantType.lumination;

    }

    public static bool TryGetHoveredPlantingSlot(out PlantingSlot plantingSlot)
    {
        plantingSlot = hoveredPlantingSlot;
        return hoveredPlantingSlot != null;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        hoveredPlantingSlot = this;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (hoveredPlantingSlot == this)
            hoveredPlantingSlot = null;
    }
}