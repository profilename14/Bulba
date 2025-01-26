using UnityEngine;
using UnityEngine.UI;

public class ImageSlideShow : MonoBehaviour
{
    public Image image;

    public int fps;
    public Sprite[] frames;

    void Update()
    {
        image.sprite = GetSprite();
    }

    Sprite GetSprite()
    {
        int frame = Mathf.CeilToInt(Time.time * fps) % frames.Length;
        return frames[frame];
    }
}
