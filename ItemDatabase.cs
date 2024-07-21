using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }
    public List<Item>itemDB = new List<Item>();

    public GameObject WoodPrefab;
    public Vector3[] pos;

    private void Start()
    {
        {
            //아이템 생성
            for(int i = 0; i < 6; i++)
            {
                GameObject go = Instantiate(WoodPrefab, pos[i], Quaternion.identity);
                go.GetComponent<Wood>().SetItem(itemDB[Random.Range(0, 1)]);
            }
        }
    }

}
