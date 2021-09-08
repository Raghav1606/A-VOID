using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControllerScript : MonoBehaviour {

    // score and coin text in scene
    public Text coinText;

    // keeping track which level is unlocked
    public bool[] levels;

    // reference to level buttons in scene
    public Button[] levelButtons;
    
    // reference to lock images in scene
    public Image[] lockIcons;

    void Awake()
    {
        Time.timeScale = 1f;
        GameController.instance.gamemode = true;
        GameController.instance.Save();
    }

    // Use this for initialization
    void Start()
    {
        
        InitializeLevelMenu();
    }

    void InitializeLevelMenu()
    {
        coinText.text = "" + GameController.instance.coins;

        levels = GameController.instance.levels;

        for (int i = 0; i < levels.Length; i++)
        {

            if (levels[i])
            {
                lockIcons[i].gameObject.SetActive(false);
            }
            else
            {
                levelButtons[i].interactable = false;
            }

        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void ToLevel1()
    {
        GameController.instance.currentLevel = 0;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel2()
    {
        GameController.instance.currentLevel = 1;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel3()
    {
        GameController.instance.currentLevel = 2;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel4()
    {
        GameController.instance.currentLevel = 3;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel5()
    {
        GameController.instance.currentLevel = 4;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel6()
    {
        GameController.instance.currentLevel = 5;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel7()
    {
        GameController.instance.currentLevel = 6;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel8()
    {
        GameController.instance.currentLevel = 7;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel9()
    {
        GameController.instance.currentLevel = 8;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel10()
    {
        GameController.instance.currentLevel = 9;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel11()
    {
        GameController.instance.currentLevel = 10;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel12()
    {
        GameController.instance.currentLevel = 11;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel13()
    {
        GameController.instance.currentLevel = 12;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel14()
    {
        GameController.instance.currentLevel = 13;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel15()
    {
        GameController.instance.currentLevel = 14;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel16()
    {
        GameController.instance.currentLevel = 15;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel17()
    {
        GameController.instance.currentLevel = 16;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel18()
    {
        GameController.instance.currentLevel = 17;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel19()
    {
        GameController.instance.currentLevel = 18;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel20()
    {
        GameController.instance.currentLevel = 19;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel21()
    {
        GameController.instance.currentLevel = 20;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel22()
    {
        GameController.instance.currentLevel = 21;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel23()
    {
        GameController.instance.currentLevel = 22;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }

    public void ToLevel24()
    {
        GameController.instance.currentLevel = 23;
        GameController.instance.Save();
        SceneManager.LoadScene("Level13-24");
    }
}
