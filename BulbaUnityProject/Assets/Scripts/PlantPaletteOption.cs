using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantPaletteOption : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;
    [SerializeField]
    private Image image;

    private PlantType plantType;

    [SerializeField]
    private DraggedIcon draggedIconPrefab;

    private DraggedIcon draggedIcon;


    [SerializeField] public float fertilizerCostPerSecond = 0;
    [SerializeField] public float DNAProductionPerSecond = 0;
    [SerializeField] public float energyProduction = 0;
    [SerializeField] public float energyConsumption = 0;
    [SerializeField] public float heating = 0; // Should be from 0-0.5
    [SerializeField] public float cooling = 0; // Should be from 0-0.5
    [SerializeField] public float lumination = 0; // Should be from 0-0.5 but not neccessarily


    public void Setup(PlantType plantType)
    {
        this.plantType = plantType;
        if (nameText)
            nameText.text = plantType.name;

        if (image)
        {
            image.sprite = plantType.sprite;
            image.color = Color.white;
        }
        else
        {
            image.sprite = null;
            image.color = Color.clear;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(draggedIcon != null)
            Destroy(draggedIcon);

        draggedIcon = Instantiate(draggedIconPrefab, transform.root);
        draggedIcon.Image.sprite = plantType.sprite;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        draggedIcon.transform.position = eventData.position;
        if (PlantingSlot.TryGetHoveredPlantingSlot(out var hoveredPlantingSlot))
        {
            draggedIcon.Image.color = Color.white;
        }
        else
        {
            draggedIcon.Image.color = Color.gray;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(PlantingSlot.TryGetHoveredPlantingSlot(out var hoveredPlantingSlot))
        {
            hoveredPlantingSlot.Plant(plantType);
        }
        Destroy(draggedIcon.gameObject);
    }
}
