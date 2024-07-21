using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType //아이템 목록 선언
{
    Equipment,
    Etc
}

[System.Serializable]


public class Item
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;
    bool isUsed;
    public bool Use()
    {
        isUsed = false;
        isUsed = true;

        return isUsed;
    }
}
