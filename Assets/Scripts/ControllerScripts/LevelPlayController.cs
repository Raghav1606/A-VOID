using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelPlayController : MonoBehaviour {

    public static LevelPlayController instance;
    public GameObject LevelCompletePanel, LevelFailedPanel;
    public Slider timeSlider;
    public int circlesLeft , filledPercentage = 0, targetPercentage, targetupPercentage;
    public int flag = 0, j = -1, flag1 = 0, flag2 = 0, flag3 = 0, playedOK = 0, adflag = 1;
    public float area = 0, currarea = 0;
    public Touch touch;
    public GameObject[] circlemain;
    private Vector3 temp;
    public Text areaBox, circleBox, FinalScoreText, FinalCoinText, LevelTextBox;

    [SerializeField]
    private AudioSource[] FinishingAudios;

    [SerializeField]
    private AudioSource FinishingAudio2;

    void Awake()
    {
        Time.timeScale = 1f;
        adflag = 1;
        GameController.instance.gamemode = true;
        GameController.instance.Save();
        flag2 = 0;
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () {
        j = -1;
        timeSlider.value = 1;

        int currr = GameController.instance.currentLevel + 1;
        LevelTextBox.text = "LEVEL  " + currr ;

        switch(GameController.instance.currentLevel)
        {
            case 0:
                circlesLeft = 10;
                targetPercentage = 35;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 1:
                circlesLeft = 10;
                targetPercentage = 40;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 2:
                circlesLeft = 10;
                targetPercentage = 50;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 3:
                circlesLeft = 10;
                targetPercentage = 55;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 4:
                circlesLeft = 10;
                targetPercentage = 60;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 5:
                circlesLeft = 10;
                targetPercentage = 65;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 6:
                circlesLeft = 8;
                targetPercentage = 65;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 7:
                circlesLeft = 1;
                targetPercentage = 30;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 8:
                circlesLeft = 10;
                targetPercentage = 70;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 9:
                circlesLeft = 9;
                targetPercentage = 75;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 10:
                circlesLeft = 10;
                targetPercentage = 80;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 11:
                circlesLeft = 9;
                targetPercentage = 80;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 12:
                circlesLeft = 1;
                targetPercentage = 32;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 13:
                circlesLeft = 5;
                targetPercentage = 65;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 14:
                circlesLeft = 5;
                targetPercentage =70;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 15:
                circlesLeft = 1;
                targetPercentage = 35;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 16:
                circlesLeft = 6;
                targetPercentage = 60;
                targetupPercentage = 70;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;


            case 17:
                circlesLeft = 5;
                targetPercentage = 60;
                targetupPercentage = 65;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 18:
                circlesLeft = 3;
                targetPercentage = 50;
                targetupPercentage = 55;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 19:
                circlesLeft = 2;
                targetPercentage = 32;
                targetupPercentage = 38;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 20:
                circlesLeft = 1;
                targetPercentage = 20;
                targetupPercentage = 23;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 21:
                circlesLeft = 1;
                targetPercentage = 28;
                targetupPercentage = 30;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 22:
                circlesLeft = 1;
                targetPercentage = 40;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

            case 23:
                circlesLeft = 1;
                targetPercentage = 42;
                targetupPercentage = 100;
                circleBox.text = circlesLeft + " ";
                areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                break;

        }

        for (int v=0;v<circlemain.Length;v++)
        {
            circlemain[v].GetComponent<SpriteRenderer>().sprite = GameController.instance.sprites[GameController.instance.selectedPlayer];
        }
	}
	
	// Update is called once per frame
	void Update () {

        filledPercentage = Mathf.RoundToInt(area * 100.0f / 135.0f);

        if ( ((timeSlider.value == 0 || circlesLeft == -1) && (filledPercentage < targetPercentage )) || filledPercentage > targetupPercentage)
        {
            if (playedOK == 0)
            {
                FinishingAudio2.GetComponent<AudioSource>().Play();
                playedOK = 1;
            }

            if (GameController.instance.canShowAds == true && adflag == 1)
            {
                Debug.Log("11111111111111");
                adflag = 0;
                WatchVideoToEarnExtraCircles();
            }

            LevelFailedPanel.SetActive(true);
            Time.timeScale = 0f;

        
        }

        else if(timeSlider.value != 0 && circlesLeft > -1 && filledPercentage >= targetPercentage && filledPercentage <= targetupPercentage)
        {
            if (playedOK == 0)
            {
                int randomSound = Random.Range(0, FinishingAudios.Length);
                FinishingAudios[randomSound].GetComponent<AudioSource>().Play();
                playedOK = 1;
            }

            LevelCompletePanel.SetActive(true);
            FinalScoreText.text = Mathf.RoundToInt(area * 100.0f / 135.0f) + " % ";

            GameController.instance.Load();

            if (GameController.instance.levelcoinsreceived[GameController.instance.currentLevel] == false)
            {
                GameController.instance.levelcoinsreceived[GameController.instance.currentLevel] = true;
                GameController.instance.coins += 100;
                FinalCoinText.text = "100";
                GameController.instance.levels[GameController.instance.currentLevel + 1] = true;
                GameController.instance.Save();
            }
            
            Time.timeScale = 0f;
        }

        circleBox.text = Mathf.Max(circlesLeft, 0) + " ";
        timeSlider.value -= Time.deltaTime * 0.02f;

        IfTouchEnabled();

        if (circlemain[j].transform.localScale.y >= 1.25f)  // max limit reached
        {
            circlemain[j].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            if (flag == 0)
            {
                flag = 1;
                circlemain[j].gameObject.SetActive(false);
            }
            currarea = 0;
        }
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

                    circlesLeft--;
                    j++;
                    flag = 0;
                    flag1 = 0;
                    currarea = 0;

                    if(circlesLeft == -1)
                    {
                        break;
                    }
                    
                    circlemain[j].transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
                    //circlemain[j].transform.position = new Vector3((touch.position.x - 900f) / 120.0f, (touch.position.y - 600f) / 150.0f, 0);

                    if(circlemain[j].transform.position.y >= timeSlider.transform.position.y)
                    {
                        flag3 = 1;
                    }

                    if(flag3 == 0)
                    {
                        temp = circlemain[j].transform.localScale;
                        temp.x = temp.x + (Time.deltaTime) * 0.2f;
                        temp.y = temp.y + (Time.deltaTime) * 0.2f;
                        currarea = Mathf.PI * (temp.x) * (temp.y) * (16.0f);
                        circlemain[j].transform.localScale = temp;
                    }
                    
                    break;

                /*case TouchPhase.Moved:

                    circlemain[j].transform.position = new Vector3((touch.position.x - 437.5f) / 50.0f, (touch.position.y - 275f) / 50.0f, 0);
                    if (flag1 == 2)
                    {
                        circlemain[j].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                        if (flag == 0)
                        {
                            area += currarea;
                            areaBox.text = Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetPercentage + " %";
                        }
                        flag = 1;
                        currarea = 0;
                    }

                    break;*/

                /*case TouchPhase.Stationary:

                    circlemain[i].transform.position = new Vector3((touch.position.x - 437.5f) / 50.0f, (touch.position.y - 275f) / 50.0f, 0);
                    if (flag1 == 2)
                    {
                        circlemain[i].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                        if (flag == 0)
                        {
                            area += currarea;
                            areaBox.text = Mathf.RoundToInt(area * 100.0f / 135.0f) + "%";
                        }
                        flag = 1;
                        currarea = 0;
                    }

                    break;*/

                case TouchPhase.Ended:
                    flag3 = 0;
                    circlemain[j].gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    if (flag == 0 || flag1 == 2)
                    {
                        area += currarea;
                        areaBox.text = targetPercentage + " % / " + Mathf.RoundToInt(area * 100.0f / 135.0f) + " % / " + targetupPercentage + " %";
                    }
                    currarea = 0;
                    break;
            }

            if(flag1 != 2 && flag3 == 0)
            {
                temp = circlemain[j].transform.localScale;
                temp.x = temp.x + (Time.deltaTime) * 0.2f;
                temp.y = temp.y + (Time.deltaTime) * 0.2f;
                currarea = Mathf.PI * (temp.x) * (temp.y) * (16.0f);
                circlemain[j].transform.localScale = temp;
            }

        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        LevelFailedPanel.SetActive(false);
        LevelCompletePanel.SetActive(false);
        SceneManager.LoadScene("Levels");
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        LevelFailedPanel.SetActive(false);
        LevelCompletePanel.SetActive(false);

        switch (GameController.instance.currentLevel)
        {
            case 0:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 1:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 2:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 3:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 4:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 5:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 6:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 7:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 8:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 9:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 10:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 11:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 12:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 13:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 14:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 15:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 16:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 17:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 18:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 19:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 20:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 21:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 22:
                GameController.instance.currentLevel += 0;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 23:
                SceneManager.LoadScene("Level13-24");
                break;

        }

    }

    public void NextGame()
    {
        Time.timeScale = 1f;
        LevelFailedPanel.SetActive(false);
        LevelCompletePanel.SetActive(false);

        switch(GameController.instance.currentLevel)
        {
            case 0 :
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 1:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 2:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 3:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 4:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 5:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 6:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 7:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 8:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 9:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 10:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 11:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 12:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 13:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 14:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 15:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 16:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 17:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 18:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 19:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 20:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 21:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 22:
                GameController.instance.currentLevel += 1;
                GameController.instance.Save();
                SceneManager.LoadScene("Level13-24");
                break;

            case 23:
                SceneManager.LoadScene("Level13-24");
                break;

        }
        
    }
    
}

// 