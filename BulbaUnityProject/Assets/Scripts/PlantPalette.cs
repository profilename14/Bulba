using System.Collections.Generic;
using UnityEngine;

public class PlantPalette : MonoBehaviour
{
    public static PlantPalette Instance {  get; private set; }

    [SerializeField]
    private List<PlantType> startingPlantTypes;
    [SerializeField]
    private Dictionary<PlantType, PlantPaletteOption> plantTypeOptions = new Dictionary<PlantType, PlantPaletteOption>();

    [SerializeField] 
    private PlantPaletteOption paletteOptionTemplate;

    protected void Start()
    {
        Debug.Assert(Instance == null);
        Instance = this;

        if (paletteOptionTemplate.gameObject.scene != default)
        {
            paletteOptionTemplate.gameObject.SetActive(false);
        }

        foreach (var plantType in startingPlantTypes)
        {
            AddPlantType(plantType);
        }
    }

    public void AddPlantType(PlantType plantType)
    {
        if (!plantTypeOptions.ContainsKey(plantType))
        {
            var option = Instantiate(paletteOptionTemplate, paletteOptionTemplate.transform.parent);
            option.Setup(plantType);
            option.gameObject.SetActive(true);
            plantTypeOptions.Add(plantType, option);
        }
    }
}
