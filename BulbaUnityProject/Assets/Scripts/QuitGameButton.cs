using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    public Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(Application.Quit);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(Application.Quit);
    }

}
