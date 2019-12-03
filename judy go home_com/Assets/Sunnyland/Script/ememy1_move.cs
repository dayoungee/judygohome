using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ememy1_move : MonoBehaviour {
    public int creatureType;
    public int score;
    public float movePower = 0.5f;
    public float X1;
    public float X2;
  
    GameObject traceTarget;
    Vector3 movement;
    int movementFlag = 0;
    bool isTracing = false;
    bool isDie = false;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other) //플레이어가 진입할때
    {
        if (creatureType == 0)
            return;

        if (other.gameObject.tag == "player")
        {
            traceTarget = other.gameObject;

            StopCoroutine("ChangeMovement");
        }
    }
    void OnTriggerStay2D(Collider2D other) // 범위안에 있을때
    {
        if (creatureType == 0)
            return;
        if (other.gameObject.tag == "player")
        {
            isTracing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (creatureType == 0)
            return;
        if (other.gameObject.tag == "player")
        {
            isTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }


    void Start () {
      
        StartCoroutine("ChangeMovement");//코루틴실행
    }
    void FixedUpdate()
    {
        Move();//움직이기
        
    }
    IEnumerator ChangeMovement()
    {
        
        movementFlag = Random.Range(0, 3);
       
        yield return new WaitForSeconds(1f);
        StartCoroutine("ChangeMovement");
        
        
    }
    
        void Move()//움직이기
        {
           
             Vector3 moveVelocity = Vector3.zero;
            
            string dist = "";
            if (isTracing)
            {
                Vector3 PlayerPos = traceTarget.transform.position;
                if (PlayerPos.x < transform.position.x)
                    dist = "Left";
                else if (PlayerPos.x > transform.position.x)
                    dist = "Right";//플레이어를 따라가게
            }

            else
            {
            if (movementFlag == 1)
                dist = "Right";
            else if (movementFlag == 2)
                dist = "Left";
            }

        if (transform.localPosition.x < X1)
            movementFlag = 1;

        else if (transform.localPosition.x > X2)
            movementFlag = 2;

        if (dist == "Left"||transform.localPosition.x > X2)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (dist == "Right")
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
    

    public void Die()
    {
        StopCoroutine("ChangeMovement");
        isDie = true;

        SpriteRenderer renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        renderer.flipY = true;//거꾸로 뒤집기

        BoxCollider2D coll = gameObject.GetComponent<BoxCollider2D>();
        coll.enabled = false;//콜라이더 없애기

        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        Vector2 dieVelocity = new Vector2(0, 1f);
        rigid.AddForce(dieVelocity, ForceMode2D.Impulse);

        Destroy(gameObject, 5f); //객체 파괴 

    }
}

