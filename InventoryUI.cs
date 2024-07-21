using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public Slots[] slots;
    public Transform slotHolder;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public TextMeshProUGUI text_coin;

    private void Start() //초기화
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slots>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        inven.SlotCnt++;

    }
    
    private void SlotChange(int val) //슬롯 아이템 내용추가
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;

            if(i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void AddSlot() //슬롯 추가
    {
        if(Inventory.instance.coin >= 50)
        {
            Inventory.instance.coin -= 50;
            inven.SlotCnt++;
        }
        else
        {
            Inventory.instance.Massage_lessSlot();
        }
    }
    private void Update()
    {
        text_coin.text = inven.coin.ToString() + "coin"; //재화 표현
        if (Input.GetKeyDown(KeyCode.I)) //인벤토리 열기
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
    void RedrawSlotUI() //슬롯 새로고침
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }
    }
}
