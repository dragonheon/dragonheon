using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Slots : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public UnityEngine.UI.Image itemIcon;

    public void UpdateSlotUI() //���� ���ΰ�ħ
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }
    public void RemoveSlot() //���� �����
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData) //���� Ŭ��
    {
        bool isUse = item.Use();
        if(isUse)
        {
            Inventory.instance.coin += 10;
            Inventory.instance.Massage_GetCoin();
            Inventory.instance.RemoveItem(slotnum);
        }
    }
}

