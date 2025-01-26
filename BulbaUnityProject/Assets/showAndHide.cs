using System.Collections.Generic;
using UnityEngine;

public class showAndHide : MonoBehaviour
{
    [SerializeField] List<GameObject> userInterface;
    bool isEnabled = false;
    CanvasGroup group;
    [SerializeField] PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isEnabled == false)
            {
                isEnabled = true;
                group.alpha = 1;
                group.interactable = true;
                StatsSingleton.Instance.playerController.canMove = true;
                
            }
            else if (isEnabled == true)
            {
                isEnabled = false;
                group.alpha = 0;
                group.interactable = false;
                StatsSingleton.Instance.playerController.canMove = true;
            }
        }
    }
}
