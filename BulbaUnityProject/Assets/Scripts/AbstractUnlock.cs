using UnityEngine;

public abstract class AbstractUnlock : ScriptableObject
{
    public int price;
    public Sprite icon;

    public abstract void Unlock();
}


