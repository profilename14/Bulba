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