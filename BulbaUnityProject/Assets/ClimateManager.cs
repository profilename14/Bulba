using System.Collections.Generic;
using UnityEngine;

public class ClimateManager : MonoBehaviour
{


    private Collider2D hitbox;

    public bool isWithinCold = false;
    public bool isWithinExtremeCold = false;
    public bool isWithinHeat = false;
    public bool isWithinExtremeHeat = false;
    public bool isWithinDark = false;
    public bool isWithinHighLight  = false;
    public bool isWithinHighNutrition = false;
    public bool isWithinPoison  = false;

    private ClimateMap conditionBitmap = 0; // bitflag containing the conditionBitmaps in each bit as bools. Ex, 3 is in cold and extreme cold. (0011)

    List<ClimateZone> curClimates;

    
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        curClimates = new List<ClimateZone>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D( Collider2D other) {
        Debug.Log("ENTERED");
        ClimateZone climate = other.gameObject.GetComponent<ClimateZone>();
        if (climate != null)
        {
            curClimates.Add(climate);
            SetClimateProperties();
        }
    }

    void OnTriggerExit2D( Collider2D other) {
        ClimateZone climate = other.gameObject.GetComponent<ClimateZone>();
        if (climate != null)
        {
            if (curClimates.Contains(climate))
            {
                curClimates.Remove(climate);
                SetClimateProperties();
            }
        }
    }

    void SetClimateProperties()
    {
        conditionBitmap = 0;

        for (int i = 0; i < curClimates.Count; i++)
        {
            conditionBitmap |= curClimates[i].myClimateMap;
        }

        Debug.Log("Set Climate Properties gave a bitmap of " + conditionBitmap);

        isWithinCold = conditionBitmap.HasFlag(ClimateMap.isCold);
        isWithinExtremeCold = conditionBitmap.HasFlag(ClimateMap.isExtremeCold);
        isWithinHeat = conditionBitmap.HasFlag(ClimateMap.isHeat);
        isWithinExtremeHeat = conditionBitmap.HasFlag(ClimateMap.isExtremeHeat);
        isWithinDark = conditionBitmap.HasFlag(ClimateMap.isDark);
        isWithinHighLight = conditionBitmap.HasFlag(ClimateMap.isHighLight);
        isWithinHighNutrition = conditionBitmap.HasFlag(ClimateMap.isHighNutrition);
        isWithinPoison = conditionBitmap.HasFlag(ClimateMap.isPoison);

        
    }


}
