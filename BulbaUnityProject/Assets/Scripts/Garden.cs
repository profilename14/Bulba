using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    public IEnumerable<PlantingSlot> PlantingSlots => plantingSlots;

    private PlantingSlot[] plantingSlots;

    [SerializeField]
    private PlantingSlot plantingSlotTemplate;

    [SerializeField]
    private int plantingSlotCount;

    protected void Start()
    {
        plantingSlotTemplate.gameObject.SetActive(false);

        plantingSlots = new PlantingSlot[plantingSlotCount];
        for (int i = 0; i < plantingSlotCount; i++)
        {
            plantingSlots[i] = Instantiate(plantingSlotTemplate, plantingSlotTemplate.transform.parent);
            plantingSlots[i].gameObject.SetActive(true);
        }
    }

    private void OnValidate()
    {
        if (plantingSlotTemplate && plantingSlotTemplate.gameObject.scene == default)
        {
            plantingSlotTemplate = null;
            Debug.LogError($"{nameof(plantingSlotTemplate)} is a prefab. Expected an in scene template");
        }
    }
}
