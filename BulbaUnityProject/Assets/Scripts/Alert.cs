using UnityEngine;

public class Alert : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    public void Setup(string warning)
    {
        text.text = warning;
    }

    private void Update()
    {
        var t = Mathf.PingPong(Time.realtimeSinceStartup, 1);
        text.color = Color.Lerp(Color.white, Color.yellow, t);
        text.transform.localScale = Vector3.one * Mathf.Lerp(.95f, 1, t);
    }
}
