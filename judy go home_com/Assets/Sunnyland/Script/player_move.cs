using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_move : MonoBehaviour
{

    public float movePower = 1f; //움직일때 주는 힘
    public float jumpPower = 1f; // 점프할때의 힘
    public int maxHealth = 3; //생명
   public float speed;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer render;
    

    AudioSource Audio;
    public AudioClip jumpSound;
    public AudioClip enemySound;
    public AudioClip coinSound;
    public AudioClip hurtSound;
    public AudioClip dieSound;
    public AudioClip LadderSound;
    

    Vector3 movement;
    bool isJumping = false;
    bool isDie = false;
    bool isUnBeatTime = false;
    bool playerhunt = false;
 

    int health = 3;




    void OnTriggerEnter2D(Collider2D other) //콜라이더박스안에 들어갈때
    {

        if (other.gameObject.layer == 0 && rigid.velocity.y < 0)
            animator.SetBool("isJumping", false);

        if (other.gameObject.tag == "enemy" && !other.isTrigger && rigid.velocity.y < -2f) //적을 밟을때 
        {
            ememy1_move enemy = other.gameObject.GetComponent<ememy1_move>();//다른 클래스에서 가져온 객체
            this.Audio.clip = this.enemySound;
            this.Audio.loop = false;
            this.Audio.Play();

            enemy.Die();//적죽는 함수 호출

            Vector2 killVelocity = new Vector2(0, 2.5f);
            rigid.AddForce(killVelocity, ForceMode2D.Impulse);
            manager.setScore(enemy.score);//스코어 상승

        }
        else if (isUnBeatTime == false && other.gameObject.tag == "enemy" && !other.isTrigger && !(rigid.velocity.y < -2f))//점프하지않은 상태에서 적에게 닿을때
        {

            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x) attackedVelocity = new Vector2(-0.5f, 0.5f); //튕겨나가기
            else attackedVelocity = new Vector2(0.5f, 1f);
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
            health -= 1;//생명한개 감소
            this.Audio.clip = this.hurtSound;
            this.Audio.loop = false;
            this.Audio.Play();
            if (health >= 1)//생명이 1개 이상일때
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");//코루틴 시작
            }
        }


        if (other.gameObject.tag == "Bottom")//바텀태그에 닿으면 생명 0
        {
            health = 0;
        }
        if (other.gameObject.tag == "item")//아이템에 닿으면 스코어 상승
        {
            this.Audio.clip = this.coinSound;
            this.Audio.loop = false;
            this.Audio.Play();
            itemstatus item = other.gameObject.GetComponent<itemstatus>();
            manager.setScore((int)item.value); //스코어 상승

            Destroy(other.gameObject, 0f); //객체파괴
        }
        if (other.gameObject.tag == "door" && manager.getScore() >= 4000 && health == 3) //문에 닿으면 성공씬으로 넘어감
        {
            SceneManager.LoadScene("perfectSuccess");
        }
        else if (other.gameObject.tag == "door")
        {
            SceneManager.LoadScene("Success");
        }
        if (other.tag == "ladder" && Input.GetKey(KeyCode.UpArrow) || other.tag == "ladder" && Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isClimbing", true);
            this.Audio.clip = this.LadderSound;
            this.Audio.loop = false;
            this.Audio.Play();
    }
        else
            animator.SetBool("isClimbing", false);

    }
    IEnumerator UnBeatTime()//무적시간
    {
        
        int countTime = 0;
        while (countTime < 10)//무적시간임을 나타내는 깜빡임
        {
            
            if (countTime % 2 == 0) render.color = new Color32(255, 255, 255, 90);
            else render.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.2f);//0.2초마다 깜빡임
            
            countTime++;
        }
        render.color = new Color32(255, 255, 255, 255);//다시 되돌림
        isUnBeatTime = false;
        
        yield return null;
   
    }
    


    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        render = GetComponent<SpriteRenderer>();
        Audio = gameObject.AddComponent<AudioSource>();
        
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)//생명이 0일때 죽음 함수호출
        {
            if (!isDie)
                Die();
            return;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)//움직임이 없을때 움직이는 애니메이션 끄기
        {
            animator.SetBool("isMoving", false);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)//움직일때 애니메이션 실행
        {
            animator.SetBool("isMoving", true);
            
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isMoving", true);
            
        }
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping"))//점프할때 애니메이션
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            this.Audio.clip = this.jumpSound;
            this.Audio.loop = false;
            this.Audio.Play();
            animator.SetTrigger("doJumping");
        }
        
        

    }
    void FixedUpdate()
    {
        if (health == 0) return;
        Move();//움직임함수
        Jump();//점프함수 
        
    }
    void Move()//움직이기
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()//점프
    {
        if (!isJumping)
        {
            return;
        }
        rigid.velocity = Vector2.zero;
        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        isJumping = false;
    }

    void Die()//죽음
    {
        isDie = true;
        rigid.velocity = Vector2.zero;
        animator.Play("player_die");
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>();
        colls[0].enabled = false;//콜라이더박스 삭제
        colls[1].enabled = false;
        Vector2 dieVelocity = new Vector2(0, 0.1f);
        rigid.AddForce(dieVelocity, ForceMode2D.Impulse);
        this.Audio.clip = this.dieSound;
        this.Audio.loop = false;
        this.Audio.Play();
        
        Invoke("diesence", 0.3f);//지연시간을 줘서 씬넘기기

    }
    void OnGUI()// 생명 텍스트 출력
    {
        int w = Screen.width, h = Screen.height;

        GUILayout.BeginArea(new Rect(0, 0, w, h));
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(15);
       
        GUIStyle style = new GUIStyle();

        style.fontSize = h * 2 / 15;
        style.normal.textColor = Color.red;

        string heart = "";
        for (int i = 0; i < health; i++)
        {
            heart += "♥";
        }
        GUILayout.Label(heart,style);

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
    void diesence()//죽는 씬으로 넘기는 함수
    {
        SceneManager.LoadScene("Die");
    }
   
}

