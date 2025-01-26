using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    public string message;

    public bool onlyOnce = true;

    private bool hasTriggered;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (onlyOnce && hasTriggered)
            return;

        if (other.tag != "Player")
            return;

        if (string.IsNullOrWhiteSpace(message))
            return;

        hasTriggered = true;
        PopupUI.Instance.Show(message);
    }
}
