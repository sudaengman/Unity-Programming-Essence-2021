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
    public GameObject restartButton; // ����Ÿ���� Button �̶���ص���
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
        /*�÷��̾� ��Ʈ�ѷ� Ŭ������ GameState������ �� �� �ִ� static �����̱� ������*/
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
