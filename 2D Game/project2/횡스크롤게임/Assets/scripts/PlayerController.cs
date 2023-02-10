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

    /*���̾ �Ǻ��ϱ� ���ؼ� ���̾� ����ũ Ŭ������ �Ҵ��ؾ� ��.*/
    public LayerMask groundLayer; // ������ �� �ִ� ���̾�
    public bool goJump = false; // ���� ���� �÷���
    public bool onGround = false; // ���鿡 �� �ִ� �÷���

    Rigidbody2D rigid;

    Animator animator;
    public string PlayerAni = "PlayerStop";
    public string MoveAni = "Run";
    public string JumpAni = "PlayerJump";
    public string ClearAni = "PlayerClear";
    public string OverAni = "PlayerOver";

    string nowAnime = ""; //���� ��µǴ� �ִϸ��̼��� ����ΰ� ���
    string oldAnime = ""; //���� �ִϸ��̼��� ����ΰ�.

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
        /*���ӽ�����Ʈ �÷����� �ƴ϶�� �� �Ʒ� Ű�Է� Ŀ�ǵ� �۵��Ұ�*/
        if (GameState != "playing")
        {
            return;
        }

        /*���(1)�� ������(-1)�� ����ִ� ���� ����*/
        axisH = Input.GetAxisRaw("Horizontal");

        
        /*���ӿ�����Ʈ�� scaler���� ���� ������ȯ*/
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


        /*���ӽ�����Ʈ �÷����� �ƴ϶�� �� �Ʒ� �۵��Ұ�*/
        if (GameState != "playing")
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position, //�Ǻ���ġ
                                        transform.position - (transform.up * 0.1f), // �Ǻ���ġ���� ���۵Ǵ� ������ ���� ��� �� transform.up�� ��ǥ (0,1,0)
                                        groundLayer); // �׶��� ���̾ �������


        /*�¿��̵�*/
        if (onGround || axisH != 0)
        {
            rigid.velocity = new Vector2(axisH * speed, rigid.velocity.y);
        }

        /*����*/
        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jumpPower);
            rigid.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        /*�ִϸ��̼� ����*/
        if (onGround) // ���ٴڿ� ����ִ� ���
        {
            if (axisH == 0) // �¿� Ű�� �������ʰ� ������ ���� ���
            {
                nowAnime = PlayerAni; // ������ �ִ� �ִϸ��̼�
            }
            else // �� �� Ű �� �� �ϳ��� �����鼭 ������ ���� ���� ���
            {
                nowAnime = MoveAni; // �����̴� �ִϸ��̼�
            }
        }
        else // ���ٴڿ� ������� ���� ���
        {
            nowAnime = JumpAni; //�����ϴ� �ִϸ��̼�
        }


        /*�ִϸ��̼� ��º�*/
        if (nowAnime != oldAnime) // ���� �ִϸ��̼��� ���� �ִϸ��̼��̶� �ٸ� ���
        {
            oldAnime = nowAnime; // ���� �ִϸ��̼ǿ� ���� �ִϸ��̼� ���� �ִ´�.
            animator.Play(nowAnime); // �׸��� �ִϸ��̼��� ����Ѵ�.
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
        /*����Ű�� �������ٴ� �� �Ǻ��ϴ� �ڵ�*/
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

        /*�÷��̾ ���̻� �浹 ������ �� �ϰ��ϰ� ������ ���� �ö󰡴� ���*/
        GetComponent<CapsuleCollider2D>().enabled = false;
        rigid.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public void GameStop()
    { 
        rigid.velocity = new Vector2(0,0);
    }
}
