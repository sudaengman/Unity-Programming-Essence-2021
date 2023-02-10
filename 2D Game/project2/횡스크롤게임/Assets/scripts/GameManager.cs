using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOver;
    public Sprite gameClear;
    public GameObject panel;
    public GameObject restartButton; // ����Ÿ���� Button �̶���ص���
    public GameObject nextButton;

    Image titleImage;

    string oldGameState;

    public GameObject timeBar;
    public GameObject timeText;

    /*����*/
    TimeController timeCnt;         
    public GameObject scoreText;    //���� �ؽ�Ʈ
    public static int totalScore;   //���� ����  //�� ����ƽ���� �ؾ��ϳ�? ���� ������� ��� ���� ������ �Ѱ��ϱ� ����
    public int stageScore = 0;      //�������� ����

    // Start is called before the first frame update
    void Start()
    {

        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        int score = stageScore + totalScore;
        scoreText.GetComponent<Text>().text = score.ToString();
    }

    void InactiveImage() 
    {
        mainImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*�÷��̾� ��Ʈ�ѷ� Ŭ������ GameState������ �� �� �ִ� static �����̱� ������*/
        if (PlayerController.GameState == "gameClear")
        {
            mainImage.SetActive(true);
            panel.SetActive(false);

            Button btRestart = restartButton.GetComponent<Button>();
            btRestart.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClear;
            PlayerController.GameState = "gameEnd";


            /*���ӿ����� �Ǹ� �ð� �帣�� UI�� �����.*/
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;

                int time = (int)timeCnt.displayTime;
                totalScore += time + 10;
            }

            totalScore += stageScore;
            stageScore = 0;
            UpdateScore();
        }
        else if (PlayerController.GameState == "gameOver")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button btNext = nextButton.GetComponent<Button>();
            btNext.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOver;
            PlayerController.GameState = "gameEnd";

            /*���ӿ����� �Ǹ� �ð� �帣�� UI�� �����.*/
            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }
        }
        else if (PlayerController.GameState == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    int time = (int)timeCnt.displayTime;
                    timeText.GetComponent<Text>().text = time.ToString();

                    if (time == 0)
                    {
                        playerController.GameOver();
                    }
                }
            }

            if (playerController.score != 0)
            {
                stageScore += (int)playerController.score;
                playerController.score = 0;
                UpdateScore();
            }

        }
    }
}
