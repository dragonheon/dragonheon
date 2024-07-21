using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item) //������ �����Է�
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = item.itemImage;

    }
    public Item GetItem() //������ ȹ��
    {
        return item;
    }
    public void DestroyItem() //������ �ı�
    {
        Destroy(gameObject);
    }

}
