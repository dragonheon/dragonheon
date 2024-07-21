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

    void Reset() //주의 텍스트 리셋
    {
        ttt.text = " ";
    }
    public void Massage_GetCoin()
    {
        ttt.text = "<#F7FF00>10원을 획득하셨습니다.</color>";
        Invoke("Reset", 1);
    }
    public void Massage_lessSlot()
    {
        ttt.text = "<#FF3B39>인벤토리 확장을 위해선 50코인이 필요합니다.</color>";
        Invoke("Reset", 1);
    }
    public void Massage_lessInventory()
    {
        ttt.text = "<#FF3B39>인벤토리 공간이 부족합니다</color>";
        Invoke("Reset", 1);
    }
    public int SlotCnt //인벤토리 슬롯 수
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);

        }
    }

    void Start() //초기화
    {
        Reset();
        coin = 0;
        slotCnt = 1;
        if (onChangeItem != null)
        {
            onChangeItem.Invoke();
        }
    }

    public bool Additem(Item _item) //아이템 추가
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

    public void RemoveItem(int _index) //아이템 삭제
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();

    }

    private void OnTriggerEnter2D(Collider2D collision) //플레이어와 아이템 충돌시 발생 이벤트
    {
        if(collision.CompareTag("Wood")) //나무와 충돌
        {
            Wood wood = collision.GetComponent<Wood>();
            if(Additem(wood.GetItem()))
            {
                wood.DestroyItem();
            }
        }
    }
}
