using System.Collections.Generic;
using UnityEngine;

public class UnlocksUI : MonoBehaviour
{
    [SerializeField]
    private List<AbstractUnlock> startingUnlocks;


    [SerializeField]
    private UnlockButton unlockButtonTemplate;

    Dictionary<AbstractUnlock, UnlockButton> unlockButtons = new Dictionary<AbstractUnlock, UnlockButton>();

    private void Start()
    {
        if (unlockButtonTemplate && unlockButtonTemplate.gameObject.scene == default)
        {
            unlockButtonTemplate.gameObject.SetActive(false);
        }
        foreach(AbstractUnlock unlock in startingUnlocks)
        {
            AddUnlock(unlock);
        }
    }

    public void AddUnlock(AbstractUnlock unlock)
    {
        if (!unlockButtons.ContainsKey(unlock))
        {
            var button = Instantiate(unlockButtonTemplate, unlockButtonTemplate.transform.parent);
            button.Setup(unlock);
            button.gameObject.SetActive(true);
            unlockButtons.Add(unlock, button);
        }
    }
}
