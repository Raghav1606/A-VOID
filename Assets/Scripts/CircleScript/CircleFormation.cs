using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircleFormation : MonoBehaviour
{
    public int circlesleft = 10;
    public static CircleFormation instance;
    public int flag = 0, i = -1 ,flag1 = 0, flag2 = 0,flag3 = 0, adflag= 1 , playedOK = 0, playAgain = 0;
    public float area = 0, currarea = 0;
    public Touch touch;
    public GameObject[] circlemain;
    private Vector3 temp,finalpos;
    public Text areaBox, circleBox,FinalScoreText,FinalCoinText;
    public Slider timeSlider;
    public GameObject PausePanel, GameOverPanel;
    public ContactPoint2D[] contactpoints;

    [SerializeField]
    private AudioSource[] FinishingAudios;

    void Awake()
    {
        adflag = 1;
        flag2 = 0;
        Time.timeScale = 1f;

        GameController.instance.gamemode = false;
        GameController.instance.Save();
        
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        //Debug.Log(Screen.height);
        i = -1;
        timeSlider.value = 1;

        for (int v = 0; v < circlemain.Length; v++)
        {
            circlemain[v].GetComponent<SpriteRenderer>().sprite = GameController.instance.sprites[GameController.instance.selectedPlayer];
        }
    }

    void Update()
    {
        
        if(circlesleft == -1 || timeSlider.value == 0)  //game over condition
        {
            if(playedOK == 0)
            {
                int randomSound = Random.Range(0, FinishingAudios.Length);
                FinishingAudios[randomSound].GetComponent<AudioSource>().Play();
                playedOK = 1;
            }

            if (GameController.instance.canShowAds == true && adflag == 1)
            {
                adflag = 0;
                WatchVideoToEarnExtraCircles();
            }

            GameOverPanel.SetActive(true);

            FinalScoreText.text = Mathf.RoundToInt(area * 100.0f / 135.0f) + "%" ;
            int T = Mathf.RoundToInt(area * 100.0f / 135.0f) / 10;
            FinalCoinText.text = "" + Mathf.RoundToInt(area * 100.0f / 135.0f) / 10;

            if (GameController.instance.highScore < Mathf.RoundToInt(area * 100.0f / 135.0f))
            {
                GameController.instance.highScore = Mathf.Min(100,Mathf.RoundToInt(area * 100.0f / 135.0f));  
            }

            if(flag2==0)
            {
                GameController.instance.Load();
                int prevcoins = GameController.instance.coins;
                GameController.instance.coins = (T + prevcoins);
                GameController.instance.Save();
                flag2 = 1;
            }
            
            Time.timeScale = 0f;
            
        }

        circleBox.text = Mathf.Max(circlesleft,0) + " ";
        timeSlider.value -= Time.deltaTime * 0.02f;

        IfTouchEnabled();


        if (circlemain[i].transform.localScale.y >= 1.25f)  // max limit reached
        {
            circlemain[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            if (flag == 0)
            {
                circlemain[i].gameObject.SetActive(false);
                flag = 1;
            }
            currarea = 0;
        }

        //flag3 = 0;
    }

    void IfTouchEnabled()
    {

        if (Input.touchCount > 0)
        {
            
            touch = Input.GetTouch(0);

            
                switch (touch.phase)
                {
                    case TouchPhase.Began:

                    /*if (touch.tapCount >= 2)
                    {
                        PausePanel.SetActive(true);
                        Time.timeScale = 0f;
                    }*/

                    circlesleft--;
                    i++;
                    flag = 0;
                    flag1 = 0;
                    currarea = 0;
                    //finalpos = Camera.main.ScreenToWorldPoint(touch.position.x, touch.position.y, 10);
                    circlemain[i].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
                        //circlemain[i].transform.position = new Vector3((touch.position.x -900.0f) / 120.0f , (touch.position.y - 600.0f)/ 150.0f , 0);

                    if(circlemain[i].transform.position.y >= timeSlider.transform.position.y)
                    {
                        flag3 = 1;
                    }

                    if(flag3==0)
                    {
                            

                        temp = circlemain[i].transform.localScale;
                        temp.x = temp.x + (Time.deltaTime) * 0.2f;
                        temp.y = temp.y + (Time.deltaTime) * 0.2f;
                        currarea = Mathf.PI * (temp.x) * (temp.y) * (16.0f);
                        circlemain[i].transform.localScale = temp;
                    }

                    break;
                    
                    case TouchPhase.Ended:

                    flag3 = 0;
                    circlemain[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    if (flag == 0 || flag1 == 2)
                    {
                        area += currarea;
                        areaBox.text = Mathf.RoundToInt(area * 100.0f / 135.0f) + "%";
                    }
                    currarea = 0;
                    break;
                 }

                if(flag1 != 2 && flag3 == 0)
                {
                    temp = circlemain[i].transform.localScale;
                    temp.x = temp.x + (Time.deltaTime) * 0.2f;
                    temp.y = temp.y + (Time.deltaTime) * 0.2f;
                    currarea = Mathf.PI * (temp.x) * (temp.y) * (16.0f);
                    circlemain[i].transform.localScale = temp;
                }
            
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        SceneManager.LoadScene("Mainmenu");
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        flag2 = 0;
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene("Maxim");
    }
}

// size adjustments
// game overpanel and pause button