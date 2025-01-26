using UnityEngine;
using UnityEngine.UI;

public class TemperatureStatUI : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.value = StatsSingleton.Instance.temperature;
    }
}
