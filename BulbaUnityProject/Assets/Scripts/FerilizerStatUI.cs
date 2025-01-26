using UnityEngine;

public class FertilizerStatUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI quantityText;

    void Update()
    {
        quantityText.text = StatsSingleton.Instance.fertilizer.ToString("N1");
    }
}
