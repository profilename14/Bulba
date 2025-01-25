using System.Collections.Generic;
using UnityEngine;

public class PlantPalette : MonoBehaviour
{
    [SerializeField] 
    private List<PlantType> plantTypes;

    [SerializeField] 
    private PlantPaletteOption paletteOptionTemplate;

    protected void Start()
    {
        paletteOptionTemplate.gameObject.SetActive(false);

        foreach (var plantType in plantTypes)
        {
            var option = Instantiate(paletteOptionTemplate, paletteOptionTemplate.transform.parent);
            option.Setup(plantType);
            option.gameObject.SetActive(true);
        }
    }

    private void OnValidate()
    {
        if (paletteOptionTemplate && paletteOptionTemplate.gameObject.scene == default)
        {
            paletteOptionTemplate = null;
            Debug.LogError($"{nameof(paletteOptionTemplate)} is a prefab. Expected an in scene template");
        }
    }
}
