using UnityEngine;

[CreateAssetMenu]
public class PlantUnlock : AbstractUnlock
{
    [SerializeField]
    public PlantType plantType;

    public override void Unlock()
    {
        PlantPalette.Instance.AddPlantType(plantType);
    }
}


