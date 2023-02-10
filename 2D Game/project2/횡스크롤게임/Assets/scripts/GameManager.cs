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
    public GameObject restartButton; // 변수타입을 Button 이라고해도됨
    public GameObject nextButton;

    Image titleImage;

    string oldGameState;

    public GameObject timeBar;
    public GameObject timeText;

    /*점수*/
    TimeController timeCnt;         
    public GameObject scoreText;    //점수 텍스트
    public static int totalScore;   //점수 종합  //왜 스테틱으로 해야하나? 씬과 상관없이 모든 점수 총합을 총괄하기 위해
    public int stageScore = 0;      //스테이지 점수

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
        /*플레이어 컨트롤러 클래스에 GameState변수를 쓸 수 있다 static 변수이기 떄문에*/
        if (PlayerController.GameState == "gameClear")
        {
            mainImage.SetActive(true);
            panel.SetActive(false);

            Button btRestart = restartButton.GetComponent<Button>();
            btRestart.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClear;
            PlayerController.GameState = "gameEnd";


            /*게임오버가 되면 시간 흐르는 UI를 멈춘다.*/
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

            /*게임오버가 되면 시간 흐르는 UI를 멈춘다.*/
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
