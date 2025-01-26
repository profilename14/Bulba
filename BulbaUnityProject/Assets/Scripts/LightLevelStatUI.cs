using UnityEngine;
using UnityEngine.UI;

public class LightLevelStatUI : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.value = StatsSingleton.Instance.lightLevelModifier/2f;
    }
}
