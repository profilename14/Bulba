using UnityEngine;

public class ResearchStatUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI quantityText;

    void Update()
    {
        quantityText.text = StatsSingleton.Instance.Research.ToString("N1");
    }
}
