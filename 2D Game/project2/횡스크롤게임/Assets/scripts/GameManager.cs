using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {

        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);
    }

    void InactiveImage() {
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
        }
        else if (PlayerController.GameState == "gameOver")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button btNext = nextButton.GetComponent<Button>();
            btNext.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOver;
            PlayerController.GameState = "gameEnd";
        }
        else if (PlayerController.GameState == "playing")
        {
            mainImage.SetActive(true);
        }
    }
}
