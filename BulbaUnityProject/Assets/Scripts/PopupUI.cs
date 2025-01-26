using UnityEngine;

public class PopupUI : MonoBehaviour
{
    public static PopupUI Instance => (instance != null) ? instance : (instance = FindAnyObjectByType<PopupUI>(FindObjectsInactive.Include));
    private static PopupUI instance;

    public TMPro.TextMeshProUGUI text;

    bool initialized = false;

    void Start()
    {
        InitIfNeeded();
    }
    public void Show(string message) 
    {
        InitIfNeeded();
        text.text = message;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void InitIfNeeded()
    {
        if(!initialized)
        {
            gameObject.SetActive(false);
            initialized = true;
        }
    }
}
