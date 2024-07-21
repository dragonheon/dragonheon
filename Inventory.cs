using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public TextMeshProUGUI ttt;

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;


    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int coin;

    void Reset() //���� �ؽ�Ʈ ����
    {
        ttt.text = " ";
    }
    public void Massage_GetCoin()
    {
        ttt.text = "<#F7FF00>10���� ȹ���ϼ̽��ϴ�.</color>";
        Invoke("Reset", 1);
    }
    public void Massage_lessSlot()
    {
        ttt.text = "<#FF3B39>�κ��丮 Ȯ���� ���ؼ� 50������ �ʿ��մϴ�.</color>";
        Invoke("Reset", 1);
    }
    public void Massage_lessInventory()
    {
        ttt.text = "<#FF3B39>�κ��丮 ������ �����մϴ�</color>";
        Invoke("Reset", 1);
    }
    public int SlotCnt //�κ��丮 ���� ��
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);

        }
    }

    void Start() //�ʱ�ȭ
    {
        Reset();
        coin = 0;
        slotCnt = 1;
        if (onChangeItem != null)
        {
            onChangeItem.Invoke();
        }
    }

    public bool Additem(Item _item) //������ �߰�
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            {
                onChangeItem.Invoke();
            }
            return true;
        }
        else
        {
            Massage_lessInventory();
        }
        return false;
    }

    public void RemoveItem(int _index) //������ ����
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();

    }

    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ������ �浹�� �߻� �̺�Ʈ
    {
        if(collision.CompareTag("Wood")) //������ �浹
        {
            Wood wood = collision.GetComponent<Wood>();
            if(Additem(wood.GetItem()))
            {
                wood.DestroyItem();
            }
        }
    }
}
