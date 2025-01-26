using UnityEngine;
using UnityEngine.UI;

public class UnlockButton : MonoBehaviour
{
    public Image image;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI priceText;
    public Button button;

    private AbstractUnlock unlock;

    protected void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void Setup(AbstractUnlock unlock)
    {
        this.unlock = unlock;
        if(image)
        {
            if(unlock.icon != null)
            {
                image.sprite = unlock.icon;
                image.color = Color.white;
            }
            else
            {
                image.sprite = null;
                image.color = Color.clear;
            }
        }

        if (nameText)
            nameText.text = unlock.name;

        if (priceText)
            priceText.text = unlock.price + " DNA";

    }

    void Update()
    {
        button.interactable = unlock.price <= StatsSingleton.Instance.Research;
    }

    private void OnClick()
    {
        gameObject.SetActive(false);
        StatsSingleton.Instance.Research -= unlock.price;
        unlock.Unlock();
    }
}


