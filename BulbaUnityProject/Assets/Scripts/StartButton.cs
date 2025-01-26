using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Starting");
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
