using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    public float speed;
    public GameObject Crops;

    float x;
    float y;
    float timer;
    bool isHorizontalMove;
    bool triggerEntered = false;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spr;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        bool xDown = Input.GetButtonDown("Horizontal");
        bool yDown = Input.GetButtonDown("Vertical");
        bool xUp = Input.GetButtonUp("Horizontal");
        bool yUp = Input.GetButtonUp("Vertical");

        if (xDown || yUp)
        {
            isHorizontalMove = true;
            spr.flipX = Input.GetAxisRaw("Horizontal") != -1;
        }   
        else if(xUp || yDown)
        {
            isHorizontalMove = false;
        }

        if (anim.GetInteger("xAxisRaw") != x)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("xAxisRaw", (int)x);

        }
        else if(anim.GetInteger("yAxisRaw") != y)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("yAxisRaw", (int)y);
        }
        else
        {
            anim.SetBool("isChange", false);
        }

        timer += Time.deltaTime;
        if (triggerEntered == false && Input.GetKeyDown(KeyCode.E))
            Instantiate(Crops, spawnPoint.position, spawnPoint.rotation);

    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizontalMove ? new Vector2(x, 0) : new Vector2(0, y);
        rigid.velocity = moveVec * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        triggerEntered = true;
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        triggerEntered = false;
    }
}
