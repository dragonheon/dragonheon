using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManger : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public void Action(GameObject scanObj)
    {
        scanObject=scanObj;
        talkText.text="�̰��� �̸���"+scanObject.name+"�̶�� �Ѵ�.";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
