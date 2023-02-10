using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float axisH;
    public float speed = 2;
    public float vx = 0;

    public float jumpPower = 8;

    /*레이어를 판별하기 위해선 레이어 마스크 클래스를 할당해야 함.*/
    public LayerMask groundLayer; // 착지할 수 있는 레이어
    public bool goJump = false; // 점프 개시 플래그
    public bool onGround = false; // 지면에 서 있는 플래그

    Rigidbody2D rigid;

    Animator animator;
    public string PlayerAni = "PlayerStop";
    public string MoveAni = "Run";
    public string JumpAni = "PlayerJump";
    public string ClearAni = "PlayerClear";
    public string OverAni = "PlayerOver";

    string nowAnime = ""; //현재 출력되는 애니메이션은 어떤것인가 출력
    string oldAnime = ""; //예전 애니메이션은 어떤것인가.

    public static string GameState = "playing";

    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;

        animator = this.GetComponent<Animator>();
        nowAnime = PlayerAni;
        oldAnime = PlayerAni;

        GameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        /*게임스테이트 플레잉이 아니라면 이 아래 키입력 커맨드 작동불가*/
        if (GameState != "playing")
        {
            return;
        }

        /*양수(1)나 음수값(-1)을 뱉어주는 변수 생성*/
        axisH = Input.GetAxisRaw("Horizontal");

        
        /*게임오브젝트의 scaler값을 통해 방향전환*/
        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
            

        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
            
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            Jump();
            
        }
        
        
    }

    private void FixedUpdate()
    {


        /*게임스테이트 플레잉이 아니라면 이 아래 작동불가*/
        if (GameState != "playing")
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position, //피봇위치
                                        transform.position - (transform.up * 0.1f), // 피봇위치에서 시작되는 가상의 선이 닿는 곳 transform.up은 좌표 (0,1,0)
                                        groundLayer); // 그라운드 레이어에 닿았을때


        /*좌우이동*/
        if (onGround || axisH != 0)
        {
            rigid.velocity = new Vector2(axisH * speed, rigid.velocity.y);
        }

        /*점프*/
        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jumpPower);
            rigid.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        /*애니메이션 로직*/
        if (onGround) // 땅바닥에 닿아있는 경우
        {
            if (axisH == 0) // 좌우 키를 누르지않고 가만히 있을 경우
            {
                nowAnime = PlayerAni; // 가만히 있는 애니메이션
            }
            else // 좌 우 키 둘 중 하나를 누르면서 가만히 있지 않을 경우
            {
                nowAnime = MoveAni; // 움직이는 애니메이션
            }
        }
        else // 땅바닥에 닿아있지 않은 경우
        {
            nowAnime = JumpAni; //점프하는 애니메이션
        }


        /*애니메이션 출력부*/
        if (nowAnime != oldAnime) // 기존 애니메이션이 현재 애니메이션이랑 다른 경우
        {
            oldAnime = nowAnime; // 기존 애니메이션에 현재 애니메이션 값을 넣는다.
            animator.Play(nowAnime); // 그리고 애니메이션을 출력한다.
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        if (collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
        if (collision.gameObject.tag == "Scoreitem")
        { 
            itemData item = collision.gameObject.GetComponent<itemData>();
            score = item.value;

            Destroy(collision.gameObject);
        }
    }

    void Jump()
    {
        /*점프키가 눌러졌다는 걸 판별하는 코드*/
        goJump = true;
    }

    void Goal()
    {
        animator.Play(ClearAni);
        GameState = "gameClear";
        GameStop();
    }
    
    public void GameOver()
    {
        animator.Play(OverAni);
        GameState = "gameOver";
        GameStop();

        /*플레이어가 더이상 충돌 감지를 못 하게하고 죽을때 위로 올라가는 모션*/
        GetComponent<CapsuleCollider2D>().enabled = false;
        rigid.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public void GameStop()
    { 
        rigid.velocity = new Vector2(0,0);
    }
}
