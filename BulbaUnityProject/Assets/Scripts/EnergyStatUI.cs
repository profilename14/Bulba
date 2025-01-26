using UnityEngine;

public class EnergyStatUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI energyGenerationText;
    public TMPro.TextMeshProUGUI energyUseText;

    void Update()
    {
        energyGenerationText.text = StatsSingleton.Instance.energyGen.ToString("N1");
        energyUseText.text = StatsSingleton.Instance.energyUse.ToString("N1");
    }
}
