using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [System.Serializable]
    public class AnimationSequence
    {
        public int fps;
        public Sprite[] frames;

        private float timeOffset;
        public Sprite GetSprite()
        {
            int frame = Mathf.CeilToInt((Time.time+timeOffset) * fps) % frames.Length;
            return frames[frame];
        }
        public void RestartSequence()
        {
            timeOffset = -Time.time;
        }
    }

    public PlayerController playerController;
    public SpriteRenderer spriteRenderer;

    public AnimationSequence walkSequence;
    public AnimationSequence idleSequence;

    private AnimationSequence activeSequence;

    void Update()
    {
        if(playerController.IsMoving)
        {
            if (activeSequence != walkSequence)
                walkSequence.RestartSequence();

            activeSequence = walkSequence;
        }
        else
        {
            if (activeSequence != idleSequence)
                idleSequence.RestartSequence();

            activeSequence = idleSequence;
        }

        spriteRenderer.sprite = activeSequence.GetSprite();
    }
}
