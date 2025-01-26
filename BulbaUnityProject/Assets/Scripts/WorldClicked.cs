using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorldClicked : Button
{
    public static Action OnClick;

    protected override void Start()
    {
        onClick.AddListener(SignalClick);
    }
    void SignalClick()
    {
        OnClick?.Invoke();
    }
}
