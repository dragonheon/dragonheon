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

    private void Start() //�ʱ�ȭ
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slots>();
        inven.onSlotCountChange += SlotChange;
        inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        inven.SlotCnt++;

    }
    
    private void SlotChange(int val) //���� ������ �����߰�
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

    public void AddSlot() //���� �߰�
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
        text_coin.text = inven.coin.ToString() + "coin"; //��ȭ ǥ��
        if (Input.GetKeyDown(KeyCode.I)) //�κ��丮 ����
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }
    void RedrawSlotUI() //���� ���ΰ�ħ
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
