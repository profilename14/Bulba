using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button button;
    public int scene = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Starting");
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
