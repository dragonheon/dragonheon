using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    float timer;
    public Sprite sp0, sp1, sp2, sp3, sp4, sp5, sp6, sp7;
    bool triggerEntered = false;
    int resource = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
            GetComponent<SpriteRenderer>().sprite = sp0;
        if (timer >= 2)
            GetComponent<SpriteRenderer>().sprite = sp1;
        if (timer >= 3)
            GetComponent<SpriteRenderer>().sprite = sp2;
        if (timer >= 4)
            GetComponent<SpriteRenderer>().sprite = sp3;
        if (timer >= 5)
            GetComponent<SpriteRenderer>().sprite = sp4;
        if (timer >= 6)
            GetComponent<SpriteRenderer>().sprite = sp5;
        if (timer >= 7)
            GetComponent<SpriteRenderer>().sprite = sp6;
        if (timer >= 8)
            GetComponent<SpriteRenderer>().sprite = sp7;

        if (timer >= 8 && triggerEntered == true && Input.GetKeyDown(KeyCode.E))
            Destroy(this.gameObject);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        triggerEntered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        triggerEntered = false;
    }

    void CropGrowing()
    {

    }
}