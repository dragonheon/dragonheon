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
        talkText.text="이것의 이름은"+scanObject.name+"이라고 한다.";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
