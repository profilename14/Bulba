using UnityEngine;


[System.Flags]
public enum ClimateMap {
    None = 0,
    isCold = 1<<0,
    isExtremeCold = 1<<1,
    isHeat = 1<<2,
    isExtremeHeat = 1<<3,
    isDark = 1<<4,
    isHighLight = 1<<5,
    isHighNutrition = 1<<6,
    isPoison = 1<<7
}



public class ClimateZone : MonoBehaviour
{
    [SerializeField] public ClimateMap myClimateMap;

    void Awake() {

    }
}
