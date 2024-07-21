using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item) //아이템 정보입력
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;

    }
    public Item GetItem() //아이템 획득
    {
        return item;
    }
    public void DestroyItem() //아이템 파괴
    {
        Destroy(gameObject);
    }

}
