using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TimePauser timePauser;

    public bool Visible
    {
        get => visible;
        set
        {
            visible = value;
            timePauser.enabled = value;
            canvasGroup.enabled = !value;
        }
    }
    bool visible;

    void Start()
    {
        Visible = Visible;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            Visible = !Visible;
        }
    }

    public void GoToMainMenu()
        => SceneManager.LoadScene(0, LoadSceneMode.Single);

    public void Close()
        => Visible = false;
}
